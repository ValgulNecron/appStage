using System.Windows.Forms;

namespace CartesAcces
{
    public static class Chemin
    {
        /// <summary>
        /// 
        /// </summary>
        public static string CheminListeEleve { get; set; } = "./data/ImportListeEleve/ImportEleve.csv";
        /// <summary>
        /// 
        /// </summary>
        public static string CheminDossierListeEleve { get; set; } = "./data/ImportListeEleve/";
        /// <summary>
        /// 
        /// </summary>
        public static string CheminPhotoEleve { get; set; } = "./data/ElevesPhoto/";
        /// <summary>
        /// 
        /// </summary>
        public static string CheminEdtClassique { get; set; } = "./data/FichierEdtClasse";
        /// <summary>
        /// 
        /// </summary>
        public static string CheminFaceCarte { get; set; } = "./data/FichierCartesFace/";

        /// <summary>
        /// 
        /// </summary>
        public static string CheminEdtPerso { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        public static string CheminEdt { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string SetCheminImportationFichierExcel()
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string SetCheminImportationFichierPdf()
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string SetCheminImportationDossier()
        {
            var diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == DialogResult.OK) return diag.SelectedPath;
            return "failed";
        }
    }
}