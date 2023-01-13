using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CartesAcces
{
    public static class Configuration
    {
        public static bool verifExistenceConfig()
        {
            if (File.Exists("./.config"))
            {
                return true;
            }
            return false;
        }

        public static void creerConfig()
        {
            File.Create("./.config");
        }

        public static string getValue(string key)
        {
            if (verifExistenceConfig())
            {
                string value = "";
                
                
                
                if (value == "")
                {
                    throw new ArgumentException("Clé invalide");
                }
                return value;
            }
            throw new ApplicationException("Aucun fichier de configuration");
        }

        public static void saveConfig(string value, string key)
        {
            string filePath = "./.config";
            string[] lines = File.ReadAllLines(filePath);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string line in lines)
                {
                    string pattern = "^" + key + "=";
                    if (!(Regex.IsMatch(line, pattern)))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}