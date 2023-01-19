using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CartesAcces.Properties;

namespace CartesAcces
{
    public partial class frmParametres : Form
    {
        public frmParametres()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
            ControlSize.SetSizeTextControl(this);
            initDataGrid();
            lblDateImport.Text = Settings.Default.DateImport;
        }

        // -- Initialisation de la grille contenant la liste des élèves
        public void initDataGrid()
        {
            DataGridParametres.Columns.Clear();
            DataGridParametres.DataSource = null;
            DataGridParametres.DataSource = Globale.listeEleve;
        }

        public void importEleves()
        {
            var sourcePath = txtPathEleve.Text;
            var destinationPath = Chemin.pathListeEleve;
            try
            {
                if (File.Exists(destinationPath)) File.Delete(destinationPath);

                Directory.CreateDirectory(Chemin.pathFolderListeEleve);

                File.Copy(sourcePath, destinationPath);
                ReadCSV.setLesEleves(destinationPath);
                Eleve.setLesClasses();

                initDataGrid();
                MessageBox.Show("Import Réussi");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        // -- Importation des photo des élèves --
        public void importPhoto()
        {
            var sourcePath = txtPathPhoto.Text;
            var destinationPath = Chemin.pathPhotoEleve;

            try
            {
                Directory.CreateDirectory(destinationPath);

                var directory = new DirectoryInfo(sourcePath);


                    foreach (var file in directory.GetFiles())
                    {
                        var img = Image.FromFile(file.FullName);
                        var nom = file.Name;

                        img.Save(destinationPath + nom, ImageFormat.Png);
                    }
     


                MessageBox.Show("Import réussie !");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        // -- La liste des élève se met a jour a chaques saisies de l'utilisateur --
        public void rechercheDataGrid()
        {
            var listeRecherche = new List<Eleve>();

            initDataGrid();

            foreach (DataGridViewRow row in DataGridParametres.Rows)
                for (var i = 0; i < row.Cells.Count; i++)
                    if (row.Cells[i].Value.ToString().Contains(txtRechercheDataGrid.Text))
                    {
                        var eleve = new Eleve();

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

            if (listeRecherche.Count() == 0)
            {
                MessageBox.Show("Unable to find " + txtRechercheDataGrid.Text, "Not Found");
                return;
            }

            if (txtRechercheDataGrid.Text == "")
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
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Jpeg Files Only | *.jpg";
                ofd.Title = "Selectionner une photo";
                if (ofd.ShowDialog() == DialogResult.OK)
                    return ofd.FileName;
                return "null";
            }
        }

        // ### Controls ###

        private void btnImporterEleves_Click(object sender, EventArgs e)
        {
            txtPathEleve.Text = Chemin.setPathImportFileEXCEL();
            if (txtPathEleve.Text.Length > 0) btnValiderEleve.Enabled = true;
        }

        private void btnValiderEleve_Click(object sender, EventArgs e)
        {
            labelV.Show();
            importEleves();
            lblDateImport.Text = Settings.Default.DateImport;
            labelV.Hide();
        }

        private void btnImportEDT_Click(object sender, EventArgs e)
        {
            txtPathEDT.Text = Chemin.setPathImportFilePDF();
            var frmSelectSection = new frmSelectSection();
            //frmSelectSection.Top = new frmParametres().Top;
            frmSelectSection.StartPosition = FormStartPosition.CenterScreen;
            frmSelectSection.Show();
            btnValiderEDT.Enabled = true;
        }

        private void btnValiderEDT_Click(object sender, EventArgs e)
        {
            //importEDT();
            PdfGs.getImageFromPdf(txtPathEDT.Text, Globale._classe);
        }

        private void btnImportPhoto_Click(object sender, EventArgs e)
        {

          txtPathPhoto.Text = Chemin.setPathImportFolder();
          btnValiderPhoto.Enabled = true;
         

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
            var time = new Timer(this);
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void btnImportPhotoUnique_Click(object sender, EventArgs e)
        {
            var path = getImportPath();

            if (path == "null")
            {
                MessageBox.Show("Fichier invalide !");
                return;
            }

            var frm = new frmImportPhotoUnique();

            //Photo.setLaPhoto(path, );

            frm.Show();
        }
    }
}