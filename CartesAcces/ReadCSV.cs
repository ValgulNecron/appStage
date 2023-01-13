using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CartesAcces
{
    public static class ReadCSV
    {
        public static List<string> getDataFromCSV(string pathCSV, int numColonne)
        {
            List<string> list = new List<string>();

            using (var reader = new StreamReader(pathCSV))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    list.Add(values[numColonne]);
                }
            }
            return list;
        }

        public static int getNumberOfLines(string pathCSV)
        {
            return File.ReadAllLines(pathCSV).Length - 1;
        }
        
        public static void setLesEleves(string sFilePath)
        {
            //string sFilePath = ""; // chemin vers le fichier csv
            try
            {
                List<Eleve> listeProvisoire = new List<Eleve>();
                int rowCount = ReadCSV.getNumberOfLines(sFilePath);

                for (int i = 1; i <= rowCount; i++)
                {
                    string classe = rectifClasse(ReadCSV.getDataFromCSV(sFilePath, 6)[i]);
                    Eleve unEleve = new Eleve();
                    unEleve.NomEleve = ReadCSV.getDataFromCSV(sFilePath, 0)[i];
                    unEleve.PrenomEleve = ReadCSV.getDataFromCSV(sFilePath, 1)[i];
                    unEleve.ClasseEleve = classe;
                    unEleve.RegimeEleve = "failed";
                    unEleve.OptionUnEleve = ReadCSV.getDataFromCSV(sFilePath, 7)[i];
                    unEleve.OptionDeuxEleve = ReadCSV.getDataFromCSV(sFilePath, 8)[i];
                    unEleve.OptionTroisEleve = ReadCSV.getDataFromCSV(sFilePath, 9)[i];
                    unEleve.OptionQuatreEleve = ReadCSV.getDataFromCSV(sFilePath, 10)[i];
                    unEleve.MefEleve = ReadCSV.getDataFromCSV(sFilePath, 5)[i];

                    listeProvisoire.Add(unEleve);
                }

                Globale.listeEleve = listeProvisoire.OrderBy(o => o.ClasseEleve).ThenBy(o => o.NomEleve).ToList();
            }
            catch
            {
                MessageBox.Show(
                    "Pas de liste importée, afin de pouvoir créer des carte merci d'importer le fichier Excel");
            }

        }

        public static string rectifClasse(string classe)
        {
            int index = classe.IndexOf('"');
            string classeRectif = classe.Substring(index + 1, classe.Length - 3);

            return classeRectif;
        }
        
    }
}