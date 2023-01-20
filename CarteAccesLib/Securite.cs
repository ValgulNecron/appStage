using System;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CartesAcces
{
    public static class Securite
    {
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
            string path = "./data/";
            var directory = new DirectoryInfo(path);

            foreach (var file in directory.GetFiles())
            {
                chiffrerFichier(file.FullName);
            }

            foreach (var dir in directory.GetDirectories())
            {
                foreach (var file in dir.GetFiles())
                {
                    chiffrerFichier(file.FullName);
                }

                foreach (var dir2 in directory.GetDirectories())
                {
                    foreach (var file in dir2.GetFiles())
                    {
                        chiffrerFichier(file.FullName);
                    }
                }
            }
        }

        public static void chiffrerFichier(string path)
        {
            string key =
                "ZwBVpb+qYeql6q41b6dyURW0BHppqZUSmwubby+r97NWufLDmoZkCCRB/ucE9pSAtEtXXX55QTebr5OTPhFgIKHNrxOEox5cXZ7aVqpbukvqk3dQX8+uevtPFYvxr/WIgfRhuoL0vW6O1fSka9BZaQz/Pdjh7rSt/8M80rrYZNGzV6LkM7GXes/YCdo5rrt4+wLe+rssvqjhnGQayjROYeKEae5EpZEDT4UXU/HLW759nA5sHRhVXuQtDg0OYWWi";
            byte[] iv = new byte[16] {0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0};
            byte[] keyBytes = Convert.FromBase64String(key);
            MessageBox.Show(keyBytes.Length.ToString());
            using (FileStream inputStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                // Open the file in write mode
                using (FileStream outputStream = new FileStream(path + ".enc", FileMode.Create, FileAccess.Write))
                {
                    // Create a new RijndaelManaged object
                    using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
                    {
                        aes.KeySize = 192;
                        aes.BlockSize = 128;
                        aes.Padding = PaddingMode.PKCS7;
                        // Set the key and IV
                        aes.Key = keyBytes;
                        aes.IV = iv;

                        // Create a new encryptor
                        ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                        // Create a new CryptoStream
                        using (CryptoStream cryptoStream =
                               new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                        {
                            // Encrypt the file
                            inputStream.CopyTo(cryptoStream);
                        }
                    }
                }
            }
        }

        public static void dechiffrerDossier()  
        {
            string path = "./data/";
            var directory = new DirectoryInfo(path);DeriveKey(password)

            foreach (var file in directory.GetFiles())
            {
                dechiffrerFichier(file.FullName);
            }

            foreach (var dir in directory.GetDirectories())
            {
                foreach (var file in dir.GetFiles())
                {
                    dechiffrerFichier(file.FullName);
                }

                foreach (var dir2 in directory.GetDirectories())
                {
                    foreach (var file in dir2.GetFiles())
                    {
                        dechiffrerFichier(file.FullName);
                    }
                }
            }
        }

        private static void dechiffrerFichier(string path)
        {
            string key = "ZwBVpb+qYeql6q41b6dyURW0BHppqZUSmwubby+r97NWufLDmoZkCCRB/ucE9pSAtEtXXX55QTebr5OTPhFgIKHNrxOEox5cXZ7aVqpbukvqk3dQX8+uevtPFYvxr/WIgfRhuoL0vW6O1fSka9BZaQz/Pdjh7rSt/8M80rrYZNGzV6LkM7GXes/YCdo5rrt4+wLe+rssvqjhnGQayjROYeKEae5EpZEDT4UXU/HLW759nA5sHRhVXuQtDg0OYWWi";
            byte[] iv = new byte[16] {0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0};
            byte[] keyBytes = Convert.FromBase64String(key);
            // Open the file in read mode
            using (FileStream inputStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (FileStream outputStream = new FileStream(path.Replace(".enc", ""), FileMode.Create, FileAccess.Write))
                {
                    using (RijndaelManaged aes = new RijndaelManaged())
                    {
                        aes.Key = keyBytes;
                        aes.IV = iv;

                        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                        using (CryptoStream cryptoStream = new CryptoStream(inputStream, decryptor, CryptoStreamMode.Read))
                        {
                            cryptoStream.CopyTo(outputStream);
                        }
                    }
                }
            }
        }
    }
}
