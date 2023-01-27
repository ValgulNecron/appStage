﻿using System;
using System.Drawing;
using System.Windows.Forms;
using CarteAcces;

namespace CartesAcces
{
    public partial class frmImportation : Form
    {
        public frmImportation()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
            TailleControle.setTailleControleTexte(this);
            TailleControle.setTailleControleLabel(this);
            TailleControle.setTailleBouton(this);
            lblDateListeEleve.Text = ReadCSV.getDateFile();
            lblEdtEleve.Text = PdfGs.getDateFile();
            lblPhotoEleve.Text = Photo.getDatePhotos();
        }

        private void OpenChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None; // pour faire stylax
            childForm.Dock = DockStyle.Fill; // le WF appelé va prendre tout l'espace du panel
            foreach (Control controle in Globale._accueil.Controls)
            {
                if (controle is Panel && controle.Name == "pnlContent")
                {
                    Panel pnlContent = controle as Panel;
                    pnlContent.Controls.Add(childForm); // reprend les éléments de l'ITF du windows forms
                    pnlContent.Tag = childForm; // reprend les propriétés de chaque éléments de l'ITF de la classe(WF)
                }
            }


            childForm.BringToFront(); // ramène la WF appélé en avant-plan pour une WF déjà appelé
            childForm.Show(); // lorsque la WF est appelé pour la première fois
        }

        // ### Controls ###

        private void btnImporterEleves_Click(object sender, EventArgs e)
        {
            try
            {
                //lblDateListeEleve = Globale._lblDate;
                Globale._cheminTexte = Chemin.setCheminImportationFichierExcel();
                Globale._actuelle = new frmImportation(); //
                OpenChildForm(Globale._actuelle); //
                if (Globale._cheminTexte.Length > 0)
                {
                    Globale._cas = 2;
                    var frmWait = new barDeProgression();
                    frmWait.StartPosition = FormStartPosition.Manual;
                    frmWait.Location = new Point(0, 0);
                    frmWait.Show();
                    frmWait.TopMost = true;
                }
            }
            catch { }

        }

        private void btnImportEDT_Click(object sender, EventArgs e)
        {
            try
            {
                Globale._cheminPdf = Chemin.setCheminImportationFichierPdf();
                var frmSelectSection = new frmSelectNiveau();
                frmSelectSection.StartPosition = FormStartPosition.CenterScreen;
                frmSelectSection.Show();
                //lblEdtEleve.Text = PdfGs.getDateFile();
            }
            catch { }

        }

        private void btnImportPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                 Globale._cheminPhoto = Chemin.setCheminImportationDossier();
                 Globale._cas = 4;
                 var frmWait = new barDeProgression();
                 frmWait.StartPosition = FormStartPosition.Manual;
                 frmWait.Location = new Point(0, 0);
                 frmWait.Show();
                 frmWait.TopMost = true;   
            }
            catch { }

        }

        private void btnImportEdtClassique_Click(object sender, EventArgs e)
        {
            try
            {
               lblImportEdtClassique = Globale._lblDate;
               Globale._cheminEdtClassique = Chemin.setCheminImportationEdtClassique();
               Edition.importEdtClassique(Globale._cheminEdtClassique);
   
               frmRognageEdtClassique frmRognageEdtClassique = new frmRognageEdtClassique();
               frmRognageEdtClassique.Show(); 
            }
            catch { }

        }

        private void frmParametres_Load(object sender, EventArgs e)
        {
            var time = new Timer(this);
        }

    }
}