    using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartesAcces
{
    public static class Securite
    {
        public static string PathFolder { get; set; } = "./data/";

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
            if (motDePasse.Length <= 12)
            {
                return false;
            }

            bool majuscule = false;
            bool minuscule = false;
            bool chiffre = false;
            bool caractereSpecial = false;
            foreach (char c in motDePasse)
            {
                if (c >= 'A' && c <= 'Z')
                    majuscule = true;
                else if (c >= 'a' && c <= 'z')
                    minuscule = true;
                else if (c >= '0' && c <= '9')
                    chiffre = true;
                else
                    caractereSpecial = true;

                if (majuscule && minuscule && chiffre && caractereSpecial) return true;
            }
            return false;
        }

        /*
         * Chiffre le dossier data
         */
        public static void chiffrerDossier()
        {
            var directory = new DirectoryInfo(PathFolder);
            foreach (var dir in directory.GetDirectories())
            {
                foreach (var file in dir.GetFiles())
                {
                    chiffrerFichier(file.FullName, file.FullName + ".enc", Globale.MotsDePasseChifffrement);
                    file.Delete();
                }

                foreach (var dir2 in dir.GetDirectories())
                {
                    foreach (var file in dir2.GetFiles())
                    {
                        chiffrerFichier(file.FullName, file.FullName + ".enc", Globale.MotsDePasseChifffrement);
                        file.Delete();
                    }
                }
            }

            MessageBox.Show("Chiffrement terminé");
        }

        /*
         * Chiffre un fichier
         * @param inputFile : chemin du fichier à chiffrer
         * @param outputFile : chemin du fichier chiffré
         * @param password : mot de passe pour le chiffrement
         */
        public static void chiffrerFichier(string inputFile, string outputFile, string password)
        {
            var salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            var keyGenerator = new Rfc2898DeriveBytes(passwordBytes, salt, 1000);
            var key = keyGenerator.GetBytes(32);
            var iv = keyGenerator.GetBytes(16);

            using (var aes = new AesManaged())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;

                using (var inputFileStream = new FileStream(inputFile, FileMode.Open))
                using (var outputFileStream = new FileStream(outputFile, FileMode.Create))
                using (var cryptoStream = new CryptoStream(outputFileStream, aes.CreateEncryptor(key, iv),
                           CryptoStreamMode.Write))
                {
                    outputFileStream.Write(salt, 0, salt.Length);
                    outputFileStream.Write(iv, 0, iv.Length);

                    var buffer = new byte[4096];
                    int bytesRead;

                    while ((bytesRead = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
                        cryptoStream.Write(buffer, 0, bytesRead);
                }
            }
        }

        public static void dechiffrerDossier()
        {
            var directory = new DirectoryInfo(PathFolder);

            foreach (var dir in directory.GetDirectories())
            {
                foreach (var file in dir.GetFiles())
                {   
                    string output = file.FullName.Substring(0, file.FullName.Length - 4);
                    string extension = file.FullName.Substring(file.FullName.Length - 4, 4);
                    if (extension == ".enc")
                    {
                        dechiffrerFichier(file.FullName, output, Globale.MotsDePasseChifffrement);
                        file.Delete();
                    }
                }

                foreach (var dir2 in dir.GetDirectories())
                {
                    foreach (var file in dir2.GetFiles())
                    {
                        string output = file.FullName.Substring(0, file.FullName.Length - 4);
                        string extension = file.FullName.Substring(file.FullName.Length - 4, 4);
                        if (extension == ".enc")
                        {
                            dechiffrerFichier(file.FullName, output, Globale.MotsDePasseChifffrement);
                            file.Delete();
                        }
                    }
                }
            }

            MessageBox.Show("Déchiffrement terminé");
        }

        public static void dechiffrerFichier(string inputFile, string outputFile, string password)
        {
            var salt = new byte[16];
            var iv = new byte[16];
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            using (var inputFileStream = new FileStream(inputFile, FileMode.Open))
            using (var outputFileStream = new FileStream(outputFile, FileMode.Create))
            {
                inputFileStream.Read(salt, 0, salt.Length);
                inputFileStream.Read(iv, 0, iv.Length);

                var keyGenerator = new Rfc2898DeriveBytes(passwordBytes, salt, 1000);
                var key = keyGenerator.GetBytes(32);

                using (var aes = new AesManaged())
                {
                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Mode = CipherMode.CBC;

                    using (var cryptoStream = new CryptoStream(inputFileStream, aes.CreateDecryptor(key, iv),
                               CryptoStreamMode.Read))
                    {
                        var buffer = new byte[4096];
                        int bytesRead;

                        while ((bytesRead = cryptoStream.Read(buffer, 0, buffer.Length)) > 0)
                            outputFileStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}