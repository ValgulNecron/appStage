using System;
using System.IO;
using System.Windows.Forms;

namespace CartesAcces
{
    public static class Chemin
    {
        public static string cheminListeEleve = "./data/ImportListeEleve/ImportEleve.csv";
        public static string cheminDossierListeEleve = "./data/ImportListeEleve/";
        public static string cheminPhotoEleve = "./data/ElevesPhoto/";

        public static string cheminEdt = "";

        public static string setCheminImportationEdtClassique()
        {
            var diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == DialogResult.OK) return diag.SelectedPath;
            return "failed";
        }

        // -- Permet a l'utilisateur de donner le chemin du fichier excel a importer --
        public static string setCheminImportationFichierExcel()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV Files Only | *.csv";
                ofd.Title = "Choose the File";
                if (ofd.ShowDialog() == DialogResult.OK) return ofd.FileName;
                return "failed";
            }
        }

        // -- Permet a l'utilisateur de donner le chemin du fichier PDF a importer --
        public static string setCheminImportationFichierPdf()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "PDF Files Only | *.pdf; *.PDF";
                ofd.Title = "Choose the File";
                if (ofd.ShowDialog() == DialogResult.OK) return ofd.FileName;
                return "failed";
            }
        }

        // -- Permet a l'utilisateur de donner le chemin du dossier de photo a importer
        public static string setCheminImportationDossier()
        {
            var diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == DialogResult.OK) return diag.SelectedPath;
            return "failed";
        }
    }
}