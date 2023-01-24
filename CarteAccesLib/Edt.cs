using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CartesAcces;

namespace CarteAcces
{
    public static class Edt
    {
        // -- Selection du bon emploi du temps en fonction de la classe selectionnée
        public static void afficheEmploiDuTemps(ComboBox cbbClasse, PictureBox pbCarteArriere)
        {
            if (cbbClasse.Text != "")
            {
                var classe = cbbClasse.Text;
                pbCarteArriere.Image = Image.FromFile("./data/FichierEdtClasse/" + classe + ".png");
            }
        }
        
        public static void ajouterEdtPerso(PictureBox pbCarteArriere)
        {
            // -- Parcours des fichiers...
            var opf = new OpenFileDialog();

            var opfPath = "";

            opf.InitialDirectory = "./data/ElevesEdt/";
            opf.Filter = "Images (*.png, *.jpg) | *.png; *.jpg";
            opf.FilterIndex = 1;
            opf.RestoreDirectory = true;

            if (opf.ShowDialog() == DialogResult.OK)
            {
                opfPath = opf.FileName;
                // -- Ajout de l'image dans la picturebox, celle ci devient visible
                pbCarteArriere.Image = new Bitmap(opfPath);
            }
        }
        
        public static void rognageEdt(PictureBox pbCarteArriere, string cheminEdt)
        {
            // -- Si la largeur a rogner est trop faible, on sort --
            if (Edition.rognageLargeur < 1) return;

            /* -- Rectangle pour stocker l'image rognée avec les points calculés --
                Les dimensions calculées ci dessous utilisent les dimensions 920 x 604 (calcul par proportionnalité)
                qui sont celles des vrai fichier EDT !
                Cela permet d'éviter les problèmes de résolution d'image après le rognage */

            var rogagneLargeurReel = Edition.rognageLargeur * pbCarteArriere.Image.Width / 540;
            var rogagneHauteurReel = Edition.rogagneHauteur * pbCarteArriere.Image.Height / 354;
            var rognageXReel = Edition.rognageX * pbCarteArriere.Image.Width / 540;
            var rogangeYReel = Edition.rognageY * pbCarteArriere.Image.Height / 354;

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
        
        public static void chercheEdtPerso(List<Eleve> listeEleve, PictureBox pbCarteArriere)
        {
            foreach (var eleve in listeEleve)
                try
                {
                    var dossier = "./data/image/" + eleve.ClasseEleve.Substring(0, 1) + "eme/";
                    pbCarteArriere.Image = Image.FromFile(dossier + Eleve.creeCleeEleve(eleve) + ".jpg");
                    Chemin.pathEdt = dossier + Eleve.creeCleeEleve(eleve) + ".jpg";
                    break;
                }
                catch
                {
                    // Next ..
                }
        }
    }
}