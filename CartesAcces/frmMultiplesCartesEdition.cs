﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CarteAcces;
using CarteAccesLib;

namespace CartesAcces
{
    public partial class frmMultiplesCartesEdition : Form
    {
        public frmMultiplesCartesEdition()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
        }

        private void pbPhoto_MouseMove(object sender, MouseEventArgs e)
        {
            // -- Lorsque l'utilisateur clique sur la photo de l'élève --
            if (Edition.drag)
            {
                // -- La position de la photo change --
                pbPhoto.Left = e.X + pbPhoto.Left - Edition.posX;
                pbPhoto.Top = e.Y + pbPhoto.Top - Edition.posY;
            }
        }

        private void pbPhoto_MouseDown(object sender, MouseEventArgs e)
        {
            // -- Lorsque l'utilisateur clic, la position initiale est sauvegardée, drag passe a true
            if (e.Button == MouseButtons.Left)
            {
                Edition.posX = e.X;
                Edition.posY = e.Y;
                Edition.drag = true;
            }

            // -- Actualisation pour voir le déplacement en temps réel --
            Refresh();
        }

        private void pbPhoto_MouseUp(object sender, MouseEventArgs e)
        {
            // -- Le drag est fini lorsque le clic est relevé  --
            Edition.drag = false;
        }

        private void tkbTaillePhoto_Scroll(object sender, EventArgs e)
        {
            if (pbPhoto != null)
            {
                // -- La largeur en pixel de la photo change et prend la valeur de la trackbar
                pbPhoto.Width = tkbTaillePhoto.Value;
                pbPhoto.Height = Convert.ToInt32(tkbTaillePhoto.Value * 1.5);
            }
        }


        // #### Rognage de l'emploi du temps ####
        private void btnSelect_Click(object sender, EventArgs e)
        {
            // -- Curseur en croix pour symboliser le mode selection
            Cursor = Cursors.Cross;

            // -- On est dans le mode selection
            Edition.selectionClick = true;

            // -- On peut cliquer sur rogner
            btnCrop.Enabled = true;

            btnCancel.Enabled = true;
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            var pathEdt = Chemin.pathEdt;
            Edition.selectionClick = false;
            Edt.cropEdt(pbCarteArriere, pathEdt);
            btnCrop.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // -- Le curseur revient à la normal --
            Cursor = Cursors.Default;

            // -- On est plus dans la selection --
            Edition.selectionClick = false;

            // -- On remet les paramètres et l'image de base --
            Edition.chercheEdtPerso(Globale.listeEleveImpr, pbCarteArriere);
            Edition.affichePhotoProvisoire("./data/ElevesPhoto/edition.jpg", pbPhoto);
        }

        private void pbCarteArriere_MouseDown(object sender, MouseEventArgs e)
        {
            // -- Si le bouton selectionné est cliqué --
            if (Edition.selectionClick)
            {
                // -- Si il y a clic gauche --
                if (e.Button == MouseButtons.Left)
                {
                    // -- On prend les coordonnées de départ --
                    Edition.cropX = e.X;
                    Edition.cropY = e.Y;
                    Edition.cropPen = new Pen(Color.Black, 1);
                    Edition.cropPen.DashStyle = DashStyle.DashDotDot;
                }

                // -- Refresh constant pour avoir un apperçu pendant la selection --
                pbCarteArriere.Refresh();
            }
        }

        private void pbCarteArriere_MouseMove(object sender, MouseEventArgs e)
        {
            // -- Si le bouton selection est cliqué --
            if (Edition.selectionClick)
            {
                // -- Si pas d'image, on sort --
                if (pbCarteArriere.Image == null)
                    return;

                // -- Glissement à la fin du premier clic gauche --
                if (e.Button == MouseButtons.Left)
                {
                    // -- On prend les dimensions a la fin du déplacement de la souris
                    pbCarteArriere.Refresh();
                    Edition.cropWidth = e.X - Edition.cropX;
                    Edition.cropHeight = e.Y - Edition.cropY;
                    pbCarteArriere.CreateGraphics().DrawRectangle(Edition.cropPen, Edition.cropX, Edition.cropY,
                        Edition.cropWidth, Edition.cropHeight);
                }
            }
        }

        private void btnValiderImpr_Click(object sender, EventArgs e)
        {
            // -- Si la liste est impaire, on double le dernier élève
            if (Globale.listeEleveImpr.Count % 2 == 1)
            {
                var eleve = Globale.listeEleveImpr[Globale.listeEleveImpr.Count - 1];
                Globale.listeEleveImpr.Add(eleve);
            }

            var cheminImpressionFinal = Chemin.setPathImportFolder();
            WordFile.saveCardAsWord(cheminImpressionFinal, "test", Globale.listeEleveImpr, pbPhoto, pbCarteArriere);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void frmMultiplesCartesEdition_Load(object sender, EventArgs e)
        {
            Edition.chercheEdtPerso(Globale.listeEleveImpr, pbCarteArriere);
            Edition.affichePhotoProvisoire("./data/ElevesPhoto/edition.jpg", pbPhoto);
        }
    }
}