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
            if (motDePasse.Length >= 12)
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
                {
                    majuscule = true;
                }
                else if (c >= 'a' && c <= 'z')
                {
                    minuscule = true;
                }
                else if (c >= '0' && c <= '9')
                {
                    chiffre = true;
                }
                else
                {
                    caractereSpecial = true;
                }
            }
            if (majuscule && minuscule && chiffre && caractereSpecial)
            {
                return true;
            }

            return false;
        }
    }
}