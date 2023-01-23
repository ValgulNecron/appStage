using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
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
            lblDateListeEleve.Text = ReadCSV.getDateFile();
            lblEdtEleve.Text = PdfGs.getDateFile();
            lblPhotoEleve.Text = Edition.getDatePhotos();
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
            ThreadStart threadDelegate = new ThreadStart(getPdf);
            Thread thread = new Thread(threadDelegate);
            thread.Start();
        }

        private void getPdf()
        {
            PdfGs.getImageFromPdf(txtPathEDT.Text, Globale._classe);
            PdfGs.renameEdt(txtPathEDT.Text);
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

        private void frmParametres_Load(object sender, EventArgs e)
        {
            var time = new Timer(this);
        }
    }
}