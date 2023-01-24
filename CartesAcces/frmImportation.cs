using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using CarteAcces;
using CartesAcces.Properties;

namespace CartesAcces
{
    public partial class frmImportation : Form
    {
        public frmImportation()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
            ControlSize.SetSizeTextControl(this);
            lblDateListeEleve.Text = ReadCSV.getDateFile();
            lblEdtEleve.Text = PdfGs.getDateFile();
            lblPhotoEleve.Text = Photo.getDatePhotos();
        }

        // ### Controls ###

        private void btnImporterEleves_Click(object sender, EventArgs e)
        {
            Globale._cheminTexte = Chemin.setCheminImportationFichierExcel();
            if (Globale._cheminTexte.Length > 0)
            {
                Globale._cas = 2;
                var frmWait = new barDeProgression();
                frmWait.StartPosition = FormStartPosition.Manual;
                frmWait.Location = new Point(0, 0);
                frmWait.Show();
                frmWait.TopMost = true;
                lblDateImport.Text = Settings.Default.DateImport;
            }
        }   

        private void btnImportEDT_Click(object sender, EventArgs e)
        {
            var frmSelectSection = new frmSelectNiveau();
            frmSelectSection.StartPosition = FormStartPosition.CenterScreen;
            frmSelectSection.Show();
            Globale._cheminPdf = Chemin.setCheminImportationFichierPdf();
            Globale._cas = 3;
            var frmWait = new barDeProgression();
            frmWait.StartPosition = FormStartPosition.Manual;
            frmWait.Location = new Point(0, 0);
            frmWait.Show();
            frmWait.TopMost = true;
            lblEdtEleve.Text = Settings.Default.DateImport;
        }



        private void btnImportPhoto_Click(object sender, EventArgs e)
        {
            Globale._cheminPhoto = Chemin.setPathImportFolder();
            Globale._cas = 4;
            var frmWait = new barDeProgression();
            frmWait.StartPosition = FormStartPosition.Manual;
            frmWait.Location = new Point(0, 0);
            frmWait.Show();
            frmWait.TopMost = true;
            lblPhotoEleve.Text = Settings.Default.DateImport;

        }

        private void frmParametres_Load(object sender, EventArgs e)
        {
            var time = new Timer(this);
        }


    }
}