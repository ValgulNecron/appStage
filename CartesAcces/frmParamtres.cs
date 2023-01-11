using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Rectangle = System.Drawing.Rectangle;

namespace CartesAcces
{
    public partial class frmParametres : Form
    {
        // -- DLL et procédure nécéssaires pour le module d'importation du fichier PDF --
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public frmParametres()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
            initDataGrid();
            lblDateImport.Text = Properties.Settings.Default.DateImport;
        }

        // -- Initialisation de la grille contenant la liste des élèves
        public void initDataGrid()
        {
            DataGridParametres.Columns.Clear();
            DataGridParametres.DataSource = null;
            DataGridParametres.DataSource = Globale.listeEleve;
        }

        public void importElevesBis()
        {
            string sourcePath = txtPathEleve.Text;
            string destinationPath = "./importEleve.csv";
            try
            {
                if (File.Exists(destinationPath))
                {
                    File.Delete(destinationPath);
                }

                File.Copy(sourcePath, destinationPath);
                MessageBox.Show("Import Réussi");
                ReadCSV.setLesEleves(destinationPath);
                Eleve.setLesClasses();

                initDataGrid();
            }
            catch
            {
                MessageBox.Show("Import Echoué");
            }
        }

        public void importEDT()
        {
            List<string> listeExtractPDF = new List<string>();
            string sFilePath = txtPathEDT.Text;

            // -- Message d'avertissement / prévention pour le bon déroulement du programme --
            MessageBox.Show("Durant cette manipulation, merci de ne pas toucher a la souris.." + Environment.NewLine + "Un message vous indiquera lorsque l'importation sera terminée");

            // -- Nettoyage du presse papier --
            Clipboard.Clear();

            // -- Nouvel objet process --
            Process Adope = new Process();

            // -- Le process lancera le fichier pdf ciblé --
            Adope.StartInfo.FileName = sFilePath;
            Adope.StartInfo.Arguments = sFilePath;

            // -- Ouverture du fichier et mise en avant plan --
            Adope.Start();
            IntPtr s = Adope.MainWindowHandle;
            SetForegroundWindow(s);

            // -- L'application attendra 3s avant de passer a la suite --
            System.Threading.Thread.Sleep(3000);

            // -- Selection de tout le text de la page PDF --
            SendKeys.SendWait("^(a)");

            // -- 3s le temps que la selection se fasse --
            System.Threading.Thread.Sleep(3000);

            // -- Copie du text selectionné dans le presse papier --
            SendKeys.SendWait("^(c)");

            // -- 3s le temps de la copie .. --
            System.Threading.Thread.Sleep(5000);

            // -- Stockage de la copie dans une variable et on nettoie le presspapier --
            string textPDF = Clipboard.GetText();
            Clipboard.Clear();

            // !! Recherche des lignes qui nous interesse !!

            // -- La ligne s'arrete lorsqu'il y a un saut --
            int posFin = textPDF.IndexOf("\r\n");

            // -- On commence au premier caractère de la chaine --
            int posDepart = 0;

            // -- Tant qu'on a pas attein la fin de la variable --
            while (posFin != -1)
            {
                // -- Toujours vrai sauf si erreur --
                if (posDepart >= 0)
                {
                    // -- Si la ligne contient la mention "Elève" .. -- 
                    if (textPDF.Substring(posDepart, 6).Contains("Elève"))
                    {
                        // -- .. Alors on affecte cette ligne a la liste --
                        listeExtractPDF.Add(textPDF.Substring(posDepart + 1, posFin - posDepart - 1));
                    }
                    // -- La position de départ se place au début de la ligne suivante --
                    posDepart = posFin + 1;
                    // -- La position de fin se place au saut de ligne de la ligne suivante --
                    posFin = textPDF.IndexOf("\r\n", posDepart + 1);
                }
            }

            // !! Comptage du nombre de page du fichier !!

            // -- Initialisation --
            int pages = 0;

            using (StreamReader sr = new StreamReader(File.OpenRead(sFilePath)))
            {

                Regex regex = new Regex(@"/Type\s*/Page[^s]");
                MatchCollection matches = regex.Matches(sr.ReadToEnd());

                pages = matches.Count;
            }

            // !! Captures de chaques pages du PDF !!
            // -- Pour elever la selection, on actualise la page --
            SendKeys.SendWait("{F5}");

            // -- 3s le temps de l'actualisation .. --
            System.Threading.Thread.Sleep(5000);

            // -- Au cas ou le fichier pdf ne soit pas ouvert directement sur la premiere page, on remonte tout en haut --
            for (int j = 0; j < pages; j++)
            {
                SendKeys.SendWait("{LEFT}");
            }

            // -- Pour trier les captures en fonction de niveau de l'élève --
            string folder = "";
            if (txtPathEDT.Text.Contains("3EME"))
            {
                folder = "3EME";
            }
            else if (txtPathEDT.Text.Contains("4EME"))
            {
                folder = "4EME";
            }
            else if (txtPathEDT.Text.Contains("5EME"))
            {
                folder = "5EME";
            }
            else
            {
                folder = "6EME";
            }

            // -- Nettoyage des dossiers avant enregistrement des captures --
            DirectoryInfo directory = new DirectoryInfo(Chemin.getFilePath("FichiersEDT\\" + folder));

            foreach (var file in directory.GetFiles())
            {
                file.Delete();
            }

            // -- Captures --

            // -- Pour chaques pages du pdf --
            for (int i = 0; i < pages; i++)
            {
                // -- Rectangle pour determiner la résolution de l'écran de l'utilisateur --
                Rectangle resolution = Screen.PrimaryScreen.Bounds;

                // -- Nouveau bitmap, reprennant les dimensions de l'écran --
                Bitmap captureBitmap = new Bitmap(resolution.Width, resolution.Height, PixelFormat.Format32bppArgb);

                // -- Création d'un rectangle contenu une capture de l'écran actif --

                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
                // -- Nouvel objet Graphics --
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                // -- Copie de la capture dans le rectangle --
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

                /* Si jamais il y a un "/" dans la chaine de caractère servant a renommer le fichier
                 * le programme plantera car ce n'est pas un caractère autorisé par Windows, il faut donc l'enlever..
                 */
                if (listeExtractPDF[i].Contains("/"))
                {
                    listeExtractPDF[i] = listeExtractPDF[i].Substring(0, listeExtractPDF[i].IndexOf("/")) + listeExtractPDF[i].Substring(listeExtractPDF[i].IndexOf("/") + 1);
                }

                // -- Destination du fichier --
                string FileDest = Chemin.getFilePath("FichiersEDT");
                FileDest = FileDest + folder + "\\" + listeExtractPDF[i] + ".png";

                // -- Enregistrement sous format PNG --
                captureBitmap.Save(FileDest, ImageFormat.Png);

                // -- Page suivante --
                SendKeys.SendWait("{RIGHT}");

                // -- 0.3s avant de reboucler --
                System.Threading.Thread.Sleep(1000);
            }

            MessageBox.Show("Import réussie !", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

        }

        // -- Importation des photo des élèves --
        public void importPhoto()
        {

            DirectoryInfo directory = new DirectoryInfo(txtPathPhoto.Text);

            foreach (var dir in directory.GetDirectories())
            {
                foreach (var file in dir.GetFiles())
                {
                    string sFilePath = Chemin.getFilePath("FichiersPHOTO");

                    Image img = Image.FromFile(file.FullName);
                    string nom = file.Name;

                    img.Save(sFilePath + nom, System.Drawing.Imaging.ImageFormat.Png);
                }
            }

            MessageBox.Show("Import réussie !");
        }

        // -- La liste des élève se met a jour a chaques saisies de l'utilisateur --
        public void rechercheDataGrid()
        {
            List<Eleve> listeRecherche = new List<Eleve>();

            initDataGrid();

            foreach (DataGridViewRow row in DataGridParametres.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Value.ToString().Contains(txtRechercheDataGrid.Text))
                    {
                        Eleve eleve = new Eleve();

                        eleve.NomEleve = row.Cells[0].Value.ToString();
                        eleve.PrenomEleve = row.Cells[1].Value.ToString();
                        eleve.ClasseEleve = row.Cells[2].Value.ToString();
                        eleve.RegimeEleve = row.Cells[3].Value.ToString();
                        eleve.OptionUnEleve = row.Cells[4].Value.ToString();
                        eleve.OptionDeuxEleve = row.Cells[5].Value.ToString();
                        eleve.OptionTroisEleve = row.Cells[6].Value.ToString();
                        eleve.OptionQuatreEleve = row.Cells[7].Value.ToString();
                        eleve.MefEleve = row.Cells[8].Value.ToString();

                        listeRecherche.Add(eleve);
                    }
                }
            }

            if (listeRecherche.Count() == 0)
            {
                MessageBox.Show("Unable to find " + txtRechercheDataGrid.Text, "Not Found");
                return;
            }
            else if (txtRechercheDataGrid.Text == "")
            {
                initDataGrid();
                listeRecherche.Clear();
            }
            else
            {
                DataGridParametres.Columns.Clear();
                DataGridParametres.DataSource = null;
                DataGridParametres.DataSource = listeRecherche;
            }
        }

        // -- Pour la photo uniques --
        public string getImportPath()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Jpeg Files Only | *.jpg";
                ofd.Title = "Selectionner une photo";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return ofd.FileName;
                }
                else
                {
                    return "null";
                }
            }
        }

        // ### Controls ###

        private void btnImporterEleves_Click(object sender, EventArgs e)
        {
            txtPathEleve.Text = Chemin.setPathImportFileEXCEL();
            if (txtPathEleve.Text.Length > 0)
            {
                btnValiderEleve.Enabled = true;
            }
        }

        private void btnValiderEleve_Click(object sender, EventArgs e)
        {
            labelV.Show();
            importElevesBis();
            lblDateImport.Text = Properties.Settings.Default.DateImport;
            labelV.Hide();
        }

        private void btnImportEDT_Click(object sender, EventArgs e)
        {
            Chemin.setPathImportFilePDF();
           
        }

        private void btnValiderEDT_Click(object sender, EventArgs e)
        {
            importEDT();
        }

        private void btnImportPhoto_Click(object sender, EventArgs e)
        {
            Chemin.setPathImportFolder();
        }

        private void btnValiderPhoto_Click(object sender, EventArgs e)
        {
            importPhoto();
        }

        private void btnAjoutEleve_Click(object sender, EventArgs e)
        {

        }

        private void btnModifClasse_Click(object sender, EventArgs e)
        {

        }

        private void btnSupprEleve_Click(object sender, EventArgs e)
        {

        }

        private void txtRechercheDataGrid_TextChanged(object sender, EventArgs e)
        {
            rechercheDataGrid();
        }

        private void DataGridParametres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmParametres_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnImportPhotoUnique_Click(object sender, EventArgs e)
        {
            string path = getImportPath();

            if (path == "null")
            {
                MessageBox.Show("Fichier invalide !");
                return;
            }

            frmImportPhotoUnique frm = new frmImportPhotoUnique();

            //Photo.setLaPhoto(path, );

            frm.Show();
        }
    }
}
