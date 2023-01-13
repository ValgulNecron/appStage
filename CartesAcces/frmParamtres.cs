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
using iText.Layout.Element;
using iText.Kernel.Pdf.Xobject;
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
            ControlSize.SetSizeTextControl(this);
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
            string destinationPath = Chemin.pathListeEleve;
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

        // -- Importation des photo des élèves --
        public void importPhoto()
        {

            DirectoryInfo directory = new DirectoryInfo(txtPathPhoto.Text);

            foreach (var dir in directory.GetDirectories())
            {
                foreach (var file in dir.GetFiles())
                {
                    string sFilePath = Chemin.getFilePath("FichiersPHOTO");

                    System.Drawing.Image img = System.Drawing.Image.FromFile(file.FullName);
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
            txtPathEDT.Text = Chemin.setPathImportFilePDF();
            btnValiderEDT.Enabled = true;
        }

        private void btnValiderEDT_Click(object sender, EventArgs e)
        {
            //importEDT();
            PdfGs.getImageFromPdf(txtPathEDT.Text);
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
            Timer time = new Timer(this);
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
