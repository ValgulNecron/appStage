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

        // ### Controls ###

        private void btnImporterEleves_Click(object sender, EventArgs e)
        {
            txtPathEleve.Text = Chemin.setPathImportFileEXCEL();
            if (txtPathEleve.Text.Length > 0) btnValiderEleve.Enabled = true;
        }

        private void btnValiderEleve_Click(object sender, EventArgs e)
        {
            labelV.Show();
            Edition.importEleves(txtPathEleve.Text);
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
            ThreadStart threadDelegate = getPdf;
            var thread = new Thread(threadDelegate);
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
            Edition.importPhoto(txtPathPhoto.Text);
        }

        private void frmParametres_Load(object sender, EventArgs e)
        {
            var time = new Timer(this);
        }
    }
}