using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using CarteAcces;

namespace CartesAcces
{
    public partial class frmRognageEdtClassique : Form
    {
        private List<string> listeFichiers = new List<string>();
        public frmRognageEdtClassique()
        {
            InitializeComponent();
        }

        private void frmRognageEdtClassique_Load(object sender, EventArgs e)
        {
            listeFichiers.AddRange(Directory.GetFiles(Globale._cheminEdtClassique));
            pbEdtClassique.Image = Image.FromFile(listeFichiers[0]);
            Edt.rognageEdt(pbEdtClassique, Globale._cheminEdtClassique);
        }

        private void btnRogner_Click(object sender, EventArgs e)
        {
            // -- Curseur en croix pour symboliser le mode selection
            Cursor = Cursors.Cross;

            // -- On est dans le mode selection
            Edition.selectionClique = true;

            // -- On peut cliquer sur rogner
            btnAnnuler.Enabled = true;
        }
        
        private void pbEdtClassique_MouseDown(object sender, MouseEventArgs e)
        {
            // -- Si le bouton selectionné est cliqué --
            if (Edition.selectionClique)
            {
                // -- Si il y a clic gauche --
                if (e.Button == MouseButtons.Left)
                {
                    // -- On prend les coordonnées de départ --
                    Edition.rognageX = e.X;
                    Edition.rognageY = e.Y;
                    Edition.rognagePen = new Pen(Color.Black, 1);
                    Edition.rognagePen.DashStyle = DashStyle.DashDotDot;
                }

                // -- Refresh constant pour avoir un apperçu pendant la selection --
                pbEdtClassique.Refresh();
            }
        }

        private void pbEdtClassique_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            Edition.selectionClique = false;
            Edt.rognageEdt(pbEdtClassique, listeFichiers[0]);
            btnRogner.Enabled = false;
        }

        private void pbEdtClassique_MouseMove(object sender, MouseEventArgs e)
        {
            // -- Si le bouton selection est cliqué --
            if (Edition.selectionClique)
            {
                // -- Si pas d'image, on sort --
                if (pbEdtClassique.Image == null)
                    return;

                // -- Glissement à la fin du premier clic gauche --
                if (e.Button == MouseButtons.Left)
                {
                    // -- On prend les dimensions a la fin du déplacement de la souris
                    pbEdtClassique.Refresh();
                    Edition.rognageLargeur = e.X - Edition.rognageX;
                    Edition.rognageHauteur = e.Y - Edition.rognageY;
                    pbEdtClassique.CreateGraphics().DrawRectangle(Edition.rognagePen,Math.Min(Edition.rognageX, e.X),
                        Math.Min(Edition.rognageY , e.Y),
                        Math.Abs(Edition.rognageLargeur),
                        Math.Abs(Edition.rognageHauteur));
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            pbEdtClassique.Image = Image.FromFile(listeFichiers[0]);
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            MessageBox.Show(listeFichiers[0]);
            string nom = listeFichiers[0].Substring(listeFichiers[0].LastIndexOf("\\"),
                listeFichiers[0].Length - listeFichiers[0].LastIndexOf("\\"));
            pbEdtClassique.Image.Save(Chemin.cheminEdtClassique + "//" + nom , ImageFormat.Png);
        }
    }
}