using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using CartesAcces;

namespace CarteAccesLib
{
    /// <summary>
    /// Classe de sécurité pour la gestion de la sécurité du système
    /// </summary>
    public static class Securite
    {
        /// <summary>
        /// Chemin du dossier de données
        /// </summary>
        public static string PathFolder { get; set; } = "./data/";

        /// <summary>
        /// Crée un hash unique à partir d'un mot de passe et d'un sel
        /// </summary>
        /// <param name="motDePasse">Le mot de passe à hasher</param>
        /// <returns>Le hash du mot de passe</returns>
        public static string CreationHash(string motDePasse)
        {
            // On crée un sel qui permettra au hash d'être unique même si le mot de passe est le même
            var salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);

            // On crée le hash du mot de passe avec le sel
            var pbkdf2 = new Rfc2898DeriveBytes(motDePasse, salt, 100000);
            var hash = pbkdf2.GetBytes(20);

            // On concatène le hash et le sel pour avoir un hash unique
            var hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // On retourne le hash sous forme de string encodé en base64 
            var savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        /// <summary>
        /// Vérifie si le hash d'un mot de passe entré correspond au hash d'un mot de passe enregistré
        /// </summary>
        /// <param name="motDePasse">Le mot de passe entré</param>
        /// <param name="savedPasswordHash">Le hash du mot de passe enregistré</param>
        /// <returns>True si le mot de passe est correct, sinon lance une exception UnauthorizedAccessException</returns>
        /// <exception cref="UnauthorizedAccessException">Lance une exception si le hash du mot de passe est différent du hash enregistré</exception>
        public static bool VerificationHash(string motDePasse, string savedPasswordHash)
        {
            // On récupère le hash et le sel du mot de passe enregistré
            var hashBytes = Convert.FromBase64String(savedPasswordHash);
            var salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // On recrée le hash du mot de passe entré avec le sel du mot de passe enregistré
            var pbkdf2 = new Rfc2898DeriveBytes(motDePasse, salt, 100000);
            var hash = pbkdf2.GetBytes(20);

            // On compare le hash du mot de passe entré avec le hash du mot de passe enregistré
            for (var i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    // Si le hash est différent, on lance une erreur
                    throw new UnauthorizedAccessException();
            return true;
        }

        /// <summary>
        /// V///érifie si un mot de passe respecte les prérequis suivants:
        ///- au moins 12 caractères
        ///- au moins une majuscule, une minuscule, un chiffre et un caractère spécial
        /// </summary>
        /// <param name="motDePasse">Le mot de passe à vérifier</param>
        /// <returns>True si le mot de passe respecte les prérequis, False sinon</returns>
        public static bool ValidationPrerequisMdp(string motDePasse)
        {
            if (string.IsNullOrEmpty(motDePasse)) return false;
            if (motDePasse.Length < 12) return false;

            var majuscule = false;
            var minuscule = false;
            var chiffre = false;
            var caractereSpecial = false;
            foreach (var c in motDePasse)
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


        /// <summary>
        /// Chiffre le dossier "data" en utilisant le mot de passe de chiffrement
        /// </summary>
        public static void ChiffrerDossier()
        {
            if (!Directory.Exists(PathFolder))
            {
                MessageBox.Show("Le dossier data n'existe pas");
                return;
            }

            if (Globale.MotsDePasseChifffrement == null && Globale.MotsDePasseChifffrement == "")
            {
                MessageBox.Show("Le mot de passe de chiffrement n'est pas renseigné");
                return;
            }

            var directory = new DirectoryInfo(PathFolder);
            foreach (var dir in directory.GetDirectories())
            {
                foreach (var file in dir.GetFiles())
                {
                    ChiffrerFichier(file.FullName, file.FullName + ".enc", Globale.MotsDePasseChifffrement);
                        file.Delete();
                }

                foreach (var dir2 in dir.GetDirectories())
                {
                    foreach (var file in dir2.GetFiles())
                    {
                        ChiffrerFichier(file.FullName, file.FullName + ".enc", Globale.MotsDePasseChifffrement);
                            file.Delete();
                    }
                }
            }
        }
        
        /// <summary>
        /// Chiffre un fichier en utilisant un mot de passe de chiffrement
        /// </summary>
        /// <param name="inputFile">Le fichier à chiffrer</param>
        /// <param name="outputFile">Le nom du fichier chiffré</param>
        /// <param name="password">Le mot de passe de chiffrement</param>
        public static void ChiffrerFichier(string inputFile, string outputFile, string password)
        {
            var file = new FileInfo(inputFile);
            var extension = file.FullName.Substring(file.FullName.Length - 4, 4);
            if (extension == ".enc")
            {
                return;
            }

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

        /// <summary>
        /// Déchiffre le dossier "data" en utilisant le mot de passe de chiffrement
        /// </summary>
        public static void DechiffrerDossier()
        {
            var directory = new DirectoryInfo(PathFolder);

            foreach (var dir in directory.GetDirectories())
            {
                foreach (var file in dir.GetFiles())
                {
                    var output = file.FullName.Substring(0, file.FullName.Length - 4);
                    var extension = file.FullName.Substring(file.FullName.Length - 4, 4);
                    if (extension == ".enc")
                    {
                        DechiffrerFichier(file.FullName, output, Globale.MotsDePasseChifffrement);
                        file.Delete();
                    }
                }

                foreach (var dir2 in dir.GetDirectories())
                {
                    foreach (var file in dir2.GetFiles())
                    {
                        var output = file.FullName.Substring(0, file.FullName.Length - 4);
                        var extension = file.FullName.Substring(file.FullName.Length - 4, 4);
                        if (extension == ".enc")
                        {
                            DechiffrerFichier(file.FullName, output, Globale.MotsDePasseChifffrement);
                            file.Delete();
                        }
                    }
                }
            }

            MessageBox.Show(new Form {TopLevel = true, TopMost = true}, "Déchiffrement terminé");
        }

        /// <summary>
        /// Déchiffre un fichier en utilisant un mot de passe de chiffrement
        /// </summary>
        /// <param name="inputFile">Le fichier chiffré</param>
        /// <param name="outputFile">Le nom du fichier déchiffré</param>
        /// <param name="password">Le mot de passe de chiffrement</param>
        public static void DechiffrerFichier(string inputFile, string outputFile, string password)
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