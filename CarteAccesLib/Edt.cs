using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CartesAcces;

namespace CarteAccesLib
{
    public static class Edt
    {
        // -- Selection du bon emploi du temps en fonction de la classe selectionnée
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cbbClasse"></param>
        /// <param name="pbCarteArriere"></param>
        public static void AfficheEmploiDuTemps(ComboBox cbbClasse, PictureBox pbCarteArriere)
        {
            try
            {
                if (cbbClasse.Text != "")
                {
                    var classe = cbbClasse.Text;
                    pbCarteArriere.Image = Image.FromFile("./data/FichierEdtClasse/" + classe + ".jpg");
                }
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pbCarteArriere"></param>
        /// <param name="btnSelect"></param>
        public static void AjouterEdtPerso(PictureBox pbCarteArriere, Button btnSelect)
        {
            try
            {
                // -- Parcours des fichiers...
                var opf = new OpenFileDialog();

                var opfPath = "";

                opf.InitialDirectory = "./data/ElevesEdt/";
                opf.Filter = "Images (*.png, *.jpg) | *.png; *.jpg";
                opf.FilterIndex = 1;
                opf.RestoreDirectory = true;
                Chemin.CheminEdtPerso = "";

                if (opf.ShowDialog() == DialogResult.OK)
                {
                    opfPath = opf.FileName;
                    // -- Ajout de l'image dans la picturebox, celle ci devient visible
                    pbCarteArriere.Image = new Bitmap(opfPath);
                    Chemin.CheminEdtPerso = opfPath;
                    btnSelect.Enabled = true;
                }
            }
            catch
            {
                btnSelect.Enabled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pbCarteArriere"></param>
        /// <param name="cheminEdt"></param>
        public static void RognageEdt(PictureBox pbCarteArriere, string cheminEdt)
        {
            // -- Si la largeur a rogner est trop faible, on sort --
            if (Edition.RognageLargeur < 1) return;

            /* -- Rectangle pour stocker l'image rognée avec les points calculés --
                Les dimensions calculées ci dessous utilisent les dimensions 920 x 604 (calcul par proportionnalité)
                qui sont celles des vrai fichier EDT !
                Cela permet d'éviter les problèmes de résolution d'image après le rognage */

            // -- Je sais c'est moche mais j'ai pas eu le choix... --
            var rLargeurReel = (double) Edition.RognageLargeur * pbCarteArriere.Image.Width / 540;
            var rHauteurReel = (double) Edition.RognageHauteur * pbCarteArriere.Image.Height / 354;
            var rXReel = (double) Edition.RognageX * pbCarteArriere.Image.Width / 540;
            var rYReel = (double) Edition.RognageY * pbCarteArriere.Image.Height / 354;

            var rogagneLargeurReel = Convert.ToInt32(Math.Round(rLargeurReel));
            var rogagneHauteurReel = Convert.ToInt32(Math.Round(rHauteurReel));
            var rognageXReel = Convert.ToInt32(Math.Round(rXReel));
            var rogangeYReel = Convert.ToInt32(Math.Round(rYReel));

            var rectangle = new Rectangle(rognageXReel, rogangeYReel, rogagneLargeurReel, rogagneHauteurReel);

            // -- On stock l'image original dans un bitmap --
            var imageOriginel = new Bitmap(Image.FromFile(cheminEdt));

            // -- Bitmap pour l'image rognée --
            var image = new Bitmap(rogagneLargeurReel, rogagneHauteurReel);

            // -- Création d'un graphique depuis l'image rognée
            var graphique = Graphics.FromImage(image);

            // -- Attributs de l'image --
            graphique.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphique.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphique.CompositingQuality = CompositingQuality.HighQuality;

            // -- On dessine l'image original, avec les dimensions rognées dans le graphique 
            graphique.DrawImage(imageOriginel, 0, 0, rectangle, GraphicsUnit.Pixel);

            // -- Affichage dans la picturebox
            pbCarteArriere.Image = image;
            pbCarteArriere.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCarteArriere.Width = 540;
            pbCarteArriere.Height = 354;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listeEleve"></param>
        /// <param name="pbCarteArriere"></param>
        public static void ChercheEdtPerso(List<Eleve> listeEleve, PictureBox pbCarteArriere)
        {
            foreach (var eleve in listeEleve)
            {
                pbCarteArriere.Image = Image.FromFile("./data/FichierEdtClasse/" + eleve.ClasseEleve + ".jpg");
                try
                {
                    var dossier = "./data/image/" + eleve.ClasseEleve.Substring(0, 1) + "eme/";
                    pbCarteArriere.Image = Image.FromFile(dossier + Eleve.CreeCleEleve(eleve) + ".jpg");
                    Chemin.CheminEdt = dossier + Eleve.CreeCleEleve(eleve) + ".jpg";
                    return;
                }
                catch
                {
                    // Next ..
                }
            }
        }
    }
}