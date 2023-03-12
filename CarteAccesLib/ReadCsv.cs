using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CartesAcces;

namespace CarteAccesLib
{
    /// <summary>
    /// Cette classe permet de lire un fichier CSV
    /// </summary>
    public static class ReadCsv
    {
        /// <summary>
        /// Cette fonction permet d'obtenir les données d'une colonne d'un fichier CSV
        /// </summary>
        /// <param name="pathCsv"></param>
        /// <param name="numColonne"></param>
        /// <returns></returns>
        public static List<string> GetDataFromCsv(string pathCsv, int numColonne)
        {
            var list = new List<string>();

            using (var reader = new StreamReader(pathCsv, Encoding.GetEncoding("ISO-8859-1")))
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

        /// <summary>
        /// Cette fonction permet d'obtenir le nombre de ligne d'un fichier CSV
        /// </summary>
        /// <param name="pathCsv"></param>
        /// <returns></returns>
        public static int GetNumberOfLines(string pathCsv)
        {
            return File.ReadAllLines(pathCsv).Length - 1;
        }

        /// <summary>
        /// Cette fonction permet de créer la liste des élèves
        /// </summary>
        /// <param name="sFilePath"></param>
        public static void SetLesEleves(string sFilePath)
        {
            //string sFilePath = ""; // chemin vers le fichier csv
            try
            {
                var listeProvisoire = new List<Eleve>();
                var rowCount = GetNumberOfLines(sFilePath);

                for (var i = 1; i <= rowCount; i++)
                {
                    var classe = RectifClasse(GetDataFromCsv(sFilePath, 6)[i]);
                    var unEleve = new Eleve();
                    unEleve.NumEleve = i;
                    unEleve.NomEleve = GetDataFromCsv(sFilePath, 0)[i];
                    unEleve.PrenomEleve = GetDataFromCsv(sFilePath, 1)[i];
                    unEleve.ClasseEleve = classe;
                    unEleve.RegimeEleve = GetDataFromCsv(sFilePath, 14)[i];
                    unEleve.OptionUnEleve = GetDataFromCsv(sFilePath, 7)[i];
                    unEleve.OptionDeuxEleve = GetDataFromCsv(sFilePath, 8)[i];
                    unEleve.OptionTroisEleve = GetDataFromCsv(sFilePath, 9)[i];
                    unEleve.OptionQuatreEleve = GetDataFromCsv(sFilePath, 10)[i];
                    unEleve.MefEleve = GetDataFromCsv(sFilePath, 5)[i];

                    listeProvisoire.Add(unEleve);
                    Globale.ListeElevesString.Add(unEleve.NomEleve + " " + unEleve.PrenomEleve + " " +
                                                  unEleve.ClasseEleve);
                }

                Globale.ListeEleve = listeProvisoire.OrderBy(o => o.ClasseEleve).ThenBy(o => o.NomEleve).ToList();
            }
            catch
            {
                MessageBox.Show(new Form {TopMost = true},
                    "Pas de liste importée, afin de pouvoir créer des carte merci d'importer le fichier Excel");
            }
        }

        /// <summary>
        /// Cette fonction permet de rectifier la classe
        /// </summary>
        /// <param name="classe"></param>
        /// <returns></returns>
        public static string RectifClasse(string classe)
        {
            var index = classe.IndexOf('"');
            var classeRectif = classe.Substring(index + 1, classe.Length - 3);

            return classeRectif;
        }

        /// <summary>
        /// Cette fonction permet d'obtenir la date de création du fichier CSV
        /// </summary>
        /// <returns></returns>
        public static string GetDateFile()
        {
            try
            {
                var dateFile = "Aucune Importation";

                if (File.Exists(Chemin.CheminListeEleve))
                    dateFile = File.GetCreationTime(Chemin.CheminListeEleve).ToString();

                return dateFile;
            }
            catch (Exception err)
            {
                MessageBox.Show("aaa + " + err.Message);
            }

            return null;
        }
    }
}