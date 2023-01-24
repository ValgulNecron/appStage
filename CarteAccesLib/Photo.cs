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
    public static class Photo
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
        
        public static void cropLaPhoto(PictureBox pbPhotoUnique)
        {
            // -- Si la largeur a rogner est trop faible, on sort --
            if (cropWidth < 1) return;

            /* -- Rectangle pour stocker l'image rognée avec les points calculés --
                Les dimensions calculées ci dessous utilisent les dimensions 920 x 604 (calcul par proportionnalité)
                qui sont celles des vrai fichier EDT !
                Cela permet d'éviter les problèmes de résolution d'image après le rognage */

            var widthSave = pbPhotoUnique.Width;
            var heightSave = pbPhotoUnique.Height;

            var cropWidthReal = cropWidth * pbPhotoUnique.Image.Width / pbPhotoUnique.Width;
            var cropHeightReal = cropHeight * pbPhotoUnique.Image.Height / pbPhotoUnique.Height;
            var cropXReal = cropX * pbPhotoUnique.Image.Width / pbPhotoUnique.Width;
            var cropYReal = cropY * pbPhotoUnique.Image.Height / pbPhotoUnique.Height;

            var rect = new Rectangle(cropXReal, cropYReal, cropWidthReal, cropHeightReal);

            // -- On stock l'image original dans un bitmap --
            var OriginalImage = new Bitmap(Image.FromFile(FilePath));

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
            pbPhotoUnique.Image = _img;
            pbPhotoUnique.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPhotoUnique.Width = widthSave;
            pbPhotoUnique.Height = heightSave;
        }
        
        public static void verifPhotoEleve(Eleve eleve, PictureBox pbPhoto)
        {
            var nomFichierJPG = eleve.NomEleve + " " + eleve.PrenomEleve + ".jpg";
            var nomFichierPNG = eleve.NomEleve + " " + eleve.PrenomEleve + ".png";
            var trouveBool = false;

            if (File.Exists("./data/ElevesPhoto/" + nomFichierJPG))
                pbPhoto.Image = Image.FromFile("./data/ElevesPhoto/" + nomFichierJPG);
            else if (File.Exists("./data/ElevesPhoto/" + nomFichierPNG))
                pbPhoto.Image = Image.FromFile("./data/ElevesPhoto/" + nomFichierPNG);
            else
                pbPhoto.Image = Image.FromFile("./data/ElevesPhoto/edition.jpg");
        }
        
        public static void affichePhotoProvisoire(string path, PictureBox pbPhoto)
        {
            pbPhoto.Image = new Bitmap(path);
            pbPhoto.Size = new Size(110, 165);
            pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPhoto.Visible = true;
        }
        
        public static void proportionPhoto(PictureBox pbPhoto, PictureBox pbCarteArriere, Eleve eleve, string path)
        {
            // -- Calcul par proportionnalité de la position et des dimensions de la photo sur le cadre de l'application par rapport a l'image réelle --
            // -- Cela permet de répercuter les déplacements effectués par l'utilisateur sur l'image originelle afin de pouvoir réutiliser celle ci --
            // -- Et ainsi ne pas perdre en qualité de l'image --
            var realLocX = pbPhoto.Location.X * pbCarteArriere.Image.Width / pbCarteArriere.Width;
            var realLocY = pbPhoto.Location.Y * pbCarteArriere.Image.Height / pbCarteArriere.Height;
            var realWidth = pbPhoto.Width * pbCarteArriere.Image.Width / pbCarteArriere.Width;
            var realHeight = pbPhoto.Height * pbCarteArriere.Image.Height / pbCarteArriere.Height;

            // -- Superposition des deux image dans un objet "Graphics" --
            var ObjGraphics = Graphics.FromImage(pbCarteArriere.Image);
            ObjGraphics.DrawImage(pbPhoto.Image, realLocX, realLocY, realWidth, realHeight);

            pbCarteArriere.Image.Save(path + "/" + eleve.NomEleve + eleve.PrenomEleve + "EDT.png", ImageFormat.Png);

            Thread.Sleep(1000);
        }
        
        public static string getDatePhotos()
        {
            var dateFile = "Aucune Importation";
            var dir = new DirectoryInfo(Chemin.pathPhotoEleve);
            if (dir.Exists) dateFile = dir.CreationTime.ToString();

            return dateFile;
        }
    }
}