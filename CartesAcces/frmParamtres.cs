﻿using System;
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
            Globale._textPath = Chemin.setPathImportFileEXCEL();
            if (Globale._textPath.Length > 0)
            {
                labelV.Show();
                Globale._cas = 2;
                var frmWait = new progressBarForm();
                frmWait.StartPosition = FormStartPosition.Manual;
                frmWait.Location = new Point(0, 0);
                frmWait.Show();
                frmWait.TopMost = true;
                lblDateImport.Text = Settings.Default.DateImport;
                labelV.Hide();
            }
        }   

        private void btnValiderEleve_Click(object sender, EventArgs e)
        {
            
        }

        private void btnImportEDT_Click(object sender, EventArgs e)
        {
            var frmSelectSection = new frmSelectSection();
            //frmSelectSection.Top = new frmParametres().Top;
            frmSelectSection.StartPosition = FormStartPosition.CenterScreen;
            frmSelectSection.Show();
            //importEDT();
            Globale._cheminPdf = Chemin.setPathImportFilePDF();
            Globale._cas = 3;
            var frmWait = new progressBarForm();
            frmWait.StartPosition = FormStartPosition.Manual;
            frmWait.Location = new Point(0, 0);
            frmWait.Show();
            frmWait.TopMost = true;
        }



        private void btnImportPhoto_Click(object sender, EventArgs e)
        {
            Edition.importPhoto(Chemin.setPathImportFolder());
        }

        private void frmParametres_Load(object sender, EventArgs e)
        {
            var time = new Timer(this);
        }
    }
}