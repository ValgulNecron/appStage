using System.Windows.Forms;

namespace CartesAcces
{
    public static class Chemin
    {
        public static string CheminListeEleve { get; set; } = "./data/ImportListeEleve/ImportEleve.csv";
        public static string CheminDossierListeEleve { get; set; } = "./data/ImportListeEleve/";
        public static string CheminPhotoEleve { get; set; } = "./data/ElevesPhoto/";
        public static string CheminEdtClassique { get; set; } = "./data/FichierEdtClasse";
        public static string CheminFaceCarte { get; set; } = "./data/FichierCartesFace/";

        public static string CheminEdtPerso { get; set; } = "";
        
        public static string CheminEdt { get; set; } = "";

        public static string setCheminImportationFaceCarte()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files Only | *.png; *.jpg";
                ofd.Title = "Choose the File";
                if (ofd.ShowDialog() == DialogResult.OK) return ofd.FileName;
                return "failed";
            }
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