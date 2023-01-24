using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using CarteAccesLib;
using CartesAcces;

namespace CarteAcces
{
    public static class Edt
    {
        // ** VARIABLES : Pour l'édition de l'emploi du temps (rognage) **
        public static bool
            selectionClick = false; // -> Est ce que le bouton "Selectionner" a été cliqué ? Si oui passe à true

        public static int cropX; // -> Abscisse de départ du rognage
        public static int cropY; // -> Ordonnée de départ du rognage
        public static int cropWidth; // -> Largeur du rognage
        public static int cropHeight; // -> Hauteur du rognage
        public static Pen cropPen; // -> Stylo qui dessine le rectangle correspondant au rognage

        // ** VARIABLES  : Déplacement de la photo
        public static bool
            drag = false; // -> Est ce que l'utilisateur a cliqué sur la photo ? (clique maintenue : drag passera a true)

        public static int
            posX; // -> Abscisse initiale, sauvegardée quand l'utilisateur commence le déplacement (clic maintenu sur la photo)

        public static int
            posY; // -> Ordonnée initialie, sauvegardée quand l'utilisateur commence le déplacement (clic maintenu sur la photo)

        // ** VARIABLES : Chemin de l'image **
        public static string FilePath;

        public static string cheminImpressionFinal;
        
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
            if (cropWidth < 1) return;

            /* -- Rectangle pour stocker l'image rognée avec les points calculés --
                Les dimensions calculées ci dessous utilisent les dimensions 920 x 604 (calcul par proportionnalité)
                qui sont celles des vrai fichier EDT !
                Cela permet d'éviter les problèmes de résolution d'image après le rognage */

            var cropWidthReal = cropWidth * pbCarteArriere.Image.Width / 540;
            var cropHeightReal = cropHeight * pbCarteArriere.Image.Height / 354;
            var cropXReal = cropX * pbCarteArriere.Image.Width / 540;
            var cropYReal = cropY * pbCarteArriere.Image.Height / 354;

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