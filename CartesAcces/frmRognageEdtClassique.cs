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
    /*
     * Permet de rogner l'edt classique
     * l'edt classique est un edt de classe non personnalisé
     * il est enregistré dans le dossier data/FichierEdtClasse
     */
    public partial class frmRognageEdtClassique : Form
    {
        private readonly List<string> listeFichiers = new List<string>();

        public frmRognageEdtClassique()
        {
            InitializeComponent();
        }

        
        private void frmRognageEdtClassique_Load(object sender, EventArgs e)
        {
            try
            {
                listeFichiers.AddRange(Directory.GetFiles(Globale.CheminEdtClassique));
                pbEdtClassique.Image = Image.FromFile(listeFichiers[0]);
                Edt.rognageEdt(pbEdtClassique, Globale.CheminEdtClassique);
            }
            catch
            {
            }
        }

        private void btnRogner_Click(object sender, EventArgs e)
        {
            // -- Curseur en croix pour symboliser le mode selection
            Cursor = Cursors.Cross;

            // -- On est dans le mode selection
            Edition.SelectionClique = true;

            // -- On peut cliquer sur rogner
            btnAnnuler.Enabled = true;
        }

        private void pbEdtClassique_MouseDown(object sender, MouseEventArgs e)
        {
            // -- Si le bouton selectionné est cliqué --
            if (Edition.SelectionClique)
            {
                // -- Si il y a clic gauche --
                if (e.Button == MouseButtons.Left)
                {
                    // -- On prend les coordonnées de départ --
                    Edition.RognageX = e.X;
                    Edition.RognageY = e.Y;
                    Edition.RognagePen = new Pen(Color.Black, 1);
                    Edition.RognagePen.DashStyle = DashStyle.DashDotDot;
                }

                // -- Refresh constant pour avoir un apperçu pendant la selection --
                pbEdtClassique.Refresh();
            }
        }

        private void pbEdtClassique_MouseUp(object sender, MouseEventArgs e)
        {
            if (Edition.SelectionClique)
            {
                Edition.RognageX = Math.Min(Edition.RognageX, e.X);
                Edition.RognageY = Math.Min(Edition.RognageY, e.Y);
                Cursor = Cursors.Default;
                Edition.SelectionClique = false;
                Edt.rognageEdt(pbEdtClassique, listeFichiers[0]);
                btnRogner.Enabled = false;
            }
        }

        private void pbEdtClassique_MouseMove(object sender, MouseEventArgs e)
        {
            // -- Si le bouton selection est cliqué --
            if (Edition.SelectionClique)
            {
                // -- Si pas d'image, on sort --
                if (pbEdtClassique.Image == null)
                    return;

                // -- Glissement à la fin du premier clic gauche --
                if (e.Button == MouseButtons.Left)
                {
                    // -- On prend les dimensions a la fin du déplacement de la souris
                    pbEdtClassique.Refresh();
                    Edition.RognageLargeur = e.X - Edition.RognageX;
                    Edition.RognageHauteur = e.Y - Edition.RognageY;

                    Edition.RognageLargeur = Math.Abs(Edition.RognageLargeur);
                    Edition.RognageHauteur = Math.Abs(Edition.RognageHauteur);

                    pbEdtClassique.CreateGraphics().DrawRectangle(Edition.RognagePen, Math.Min(Edition.RognageX, e.X),
                        Math.Min(Edition.RognageY, e.Y),
                        Math.Abs(Edition.RognageLargeur),
                        Math.Abs(Edition.RognageHauteur));
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            pbEdtClassique.Image = Image.FromFile(listeFichiers[0]);
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(Chemin.CheminEdtClassique))
                {
                    foreach (var file in Directory.GetFiles(Chemin.CheminEdtClassique)) File.Delete(file);
                    Directory.Delete(Chemin.CheminEdtClassique);
                }

                Directory.CreateDirectory(Chemin.CheminEdtClassique);

                var directory = new DirectoryInfo(Globale.CheminEdtClassique);
                MessageBox.Show(listeFichiers.Count.ToString());
                foreach (var fichier in listeFichiers)
                {
                    pbEdtClassique.Image = Image.FromFile(fichier);
                    Edt.rognageEdt(pbEdtClassique, fichier);
                    var nom = fichier.Substring(fichier.LastIndexOf("/"),
                        fichier.Length - fichier.LastIndexOf("/"));
                    pbEdtClassique.Image.Save(Chemin.CheminEdtClassique + "//" + nom, ImageFormat.Png);
                }


                MessageBox.Show(new Form { TopMost = true },"L'importation des emplois de temps classique à réussis");
                Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
    }
}