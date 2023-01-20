using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartesAcces
{
    public static class Securite
    {
        public static string pathFolder = "./data/";
        
        public static string creationHash(string motDePasse)
        {
            //on crée le sel qui permettra au mot de passe d'avoir un hash unique et différent à chaque fois meme si le mot de passe est le meme
            var salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);

            //on cree le hash du mot de passe avec le sel 
            var pbkdf2 = new Rfc2898DeriveBytes(motDePasse, salt, 100000);
            var hash = pbkdf2.GetBytes(20);

            //on concatene le hash et le sel pour avoir un hash unique 
            var hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            //on retourne le hash sous forme string encoder en base64 
            var savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        public static bool verificationHash(string motDePasse, string savedPasswordHash)
        {
            //on recupere le hash et le sel du mot de passe enregistréw
            var hashBytes = Convert.FromBase64String(savedPasswordHash);
            var salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            //on recree le hash du mot de passe entré avec le sel du mot dhashBytese passe enregistré
            var pbkdf2 = new Rfc2898DeriveBytes(motDePasse, salt, 100000);
            var hash = pbkdf2.GetBytes(20);

            //on compare le hash du mot de passe entré avec le hash du mot de passe enregistré
            for (var i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    //si le hash est different on envoie une erreur
                    throw new UnauthorizedAccessException();
            return true;
        }

        public static bool validationPrerequisMdp(string motDePasse)
        {
            if (motDePasse.Length < 12)
                return false;

            if (!Regex.IsMatch(motDePasse, @"[a-z]"))
                return false;

            if (!Regex.IsMatch(motDePasse, @"[A-Z]"))
                return false;

            if (!Regex.IsMatch(motDePasse, @"[0-9]"))
                return false;

            if (!Regex.IsMatch(motDePasse, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-~\\]"))
                return false;

            return true;
        }

        public static void chiffrerDossier()
        {
            var directory = new DirectoryInfo(pathFolder);

            foreach (var file in directory.GetFiles())
            {
                Task.Run(() => { chiffrerFichier(file.FullName); });
            }
            
            foreach (var dir in directory.GetDirectories())
            {
                foreach (var file in dir.GetFiles())
                {
                    Task.Run(() => { chiffrerFichier(file.FullName); });
                }
                foreach (var dir2 in dir.GetDirectories())
                {
                    foreach (var file in dir2.GetFiles())
                    {
                        Task.Run(() => { chiffrerFichier(file.FullName); });
                    }
                }
                
            }
            MessageBox.Show("Chiffrement terminé");
        }

        public static void chiffrerFichier(string path)
        {
            var key = "y0xBpGcEUuu0GjCxUuTiin1BUZyd5Xge8QHofsKH59A=";
            var iv = new byte[16] {0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0};
            var keyBytes = Convert.FromBase64String(key);
            var extension = Path.GetExtension(path);
            if (extension != "enc")
            using (var inputStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (var outputStream = new FileStream(path + ".enc", FileMode.Create, FileAccess.Write))
                {
                    using (var aes = new AesCryptoServiceProvider())
                    {
                        aes.KeySize = 256;
                        aes.BlockSize = 128;
                        aes.Padding = PaddingMode.PKCS7;

                        aes.Key = keyBytes;
                        aes.IV = iv;

                        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                        using (var cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                        {
                            inputStream.CopyTo(cryptoStream);
                        }

                        outputStream.Close();
                    }
                }
                inputStream.Close();
                if(File.Exists(path))
                    File.Delete(path);
            }
        }

        public static void dechiffrerDossier()
        {
            var directory = new DirectoryInfo(pathFolder);

            foreach (var file in directory.GetFiles())
            {
                Task.Run(() => { dechiffrerFichier(file.FullName); });
            }
            
            foreach (var dir in directory.GetDirectories())
            {
                foreach (var file in dir.GetFiles())
                {
                    Task.Run(() => { dechiffrerFichier(file.FullName); });
                }
                foreach (var dir2 in dir.GetDirectories())
                {
                    foreach (var file in dir2.GetFiles())
                    {
                        Task.Run(() => { dechiffrerFichier(file.FullName); });
                    }
                }
                
            }
            MessageBox.Show("Dossier déchiffré");
        }

        public static void dechiffrerFichier(string path)
        {
            var key = "y0xBpGcEUuu0GjCxUuTiin1BUZyd5Xge8QHofsKH59A=";
            var iv = new byte[16] {0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0};
            var keyBytes = Convert.FromBase64String(key);
            var extension = Path.GetExtension(path);
            using (var inputStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (var outputStream =new FileStream(path.Replace(".enc", ""), FileMode.Create, FileAccess.Write))
                {
                    using (var aes = new RijndaelManaged())
                    {
                        aes.Key = keyBytes;
                        aes.IV = iv;

                        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                        using (var cryptoStream = new CryptoStream(inputStream, decryptor, CryptoStreamMode.Read))
                        {
                            cryptoStream.CopyTo(outputStream);
                        }
                    }

                    outputStream.Close();if(File.Exists(path))
                        File.Delete(path);
                }
                if(File.Exists(path))
                    File.Delete(path);
                inputStream.Close();
            }
        }
    }
}