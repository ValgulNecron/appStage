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
        
        public static void cropEdt(PictureBox pbCarteArriere, string pathEdt)
        {
            // -- Si la largeur a rogner est trop faible, on sort --
            if (Edition.cropWidth < 1) return;

            /* -- Rectangle pour stocker l'image rognée avec les points calculés --
                Les dimensions calculées ci dessous utilisent les dimensions 920 x 604 (calcul par proportionnalité)
                qui sont celles des vrai fichier EDT !
                Cela permet d'éviter les problèmes de résolution d'image après le rognage */

            var cropWidthReal = Edition.cropWidth * pbCarteArriere.Image.Width / 540;
            var cropHeightReal = Edition.cropHeight * pbCarteArriere.Image.Height / 354;
            var cropXReal = Edition.cropX * pbCarteArriere.Image.Width / 540;
            var cropYReal = Edition.cropY * pbCarteArriere.Image.Height / 354;

            var rect = new Rectangle(cropXReal, cropYReal, cropWidthReal, cropHeightReal);

            // -- On stock l'image original dans un bitmap --
            var OriginalImage = new Bitmap(Image.FromFile(pathEdt));

            // -- Bitmap pour l'image rognée --
            var _img = new Bitmap(cropWidthReal, cropHeightReal);

            // -- Création d'un graphique depuis l'image rognée
            var g = Graphics.FromImage(_img);

            // -- Attributs de l'image --
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;

            // -- On dessine l'image original, avec les dimensions rognées dans le graphique 
            g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);

            // -- Affichage dans la picturebox
            pbCarteArriere.Image = _img;
            pbCarteArriere.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCarteArriere.Width = 540;
            pbCarteArriere.Height = 354;
        }
        
        public static void chercheEdtPerso(List<Eleve> listeEleve, PictureBox pbCarteArriere)
        {
            foreach (var eleve in listeEleve)
                try
                {
                    var folder = "./data/image/" + eleve.ClasseEleve.Substring(0, 1) + "eme/";
                    pbCarteArriere.Image = Image.FromFile(folder + Eleve.creeCleeEleve(eleve) + ".jpg");
                    Chemin.pathEdt = folder + Eleve.creeCleeEleve(eleve) + ".jpg";
                    break;
                }
                catch
                {
                    // Next ..
                }
        }
    }
}