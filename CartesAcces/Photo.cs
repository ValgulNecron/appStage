using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CartesAcces
{
    public static class Photo
    {
        // ** VARIABLES : Pour l'édition de l'emploi du temps (rognage) **
        public static bool selectionClick = false;     // -> Est ce que le bouton "Selectionner" a été cliqué ? Si oui passe à true
        public static int cropX;       // -> Abscisse de départ du rognage
        public static int cropY;       // -> Ordonnée de départ du rognage
        public static int cropWidth;       // -> Largeur du rognage
        public static int cropHeight;      // -> Hauteur du rognage
        public static Pen cropPen;     // -> Stylo qui dessine le rectangle correspondant au rognage
        
        // ** VARIABLES : Chemin de l'image **
        public static string FilePath;
        
        public static void setLaPhoto(string path, PictureBox pbPhoto)
        {
            pbPhoto.Image = Image.FromFile(path);
            FilePath = path;
        }
        
        public static void cropLaPhoto(PictureBox pbPhotoUnique)
        {
            // -- Si la largeur a rogner est trop faible, on sort --
            if (cropWidth < 1)
            {
                return;
            }

            /* -- Rectangle pour stocker l'image rognée avec les points calculés --
                Les dimensions calculées ci dessous utilisent les dimensions 920 x 604 (calcul par proportionnalité)
                qui sont celles des vrai fichier EDT !
                Cela permet d'éviter les problèmes de résolution d'image après le rognage */

            int widthSave = pbPhotoUnique.Width;
            int heightSave = pbPhotoUnique.Height;


            int cropWidthReal = (cropWidth * pbPhotoUnique.Image.Width) / pbPhotoUnique.Width;
            int cropHeightReal = (cropHeight * pbPhotoUnique.Image.Height) / pbPhotoUnique.Height;
            int cropXReal = (cropX * pbPhotoUnique.Image.Width) / pbPhotoUnique.Width;
            int cropYReal = (cropY * pbPhotoUnique.Image.Height) / pbPhotoUnique.Height;

            Rectangle rect = new Rectangle(cropXReal, cropYReal, cropWidthReal, cropHeightReal);

            // -- On stock l'image original dans un bitmap --
            Bitmap OriginalImage = new Bitmap(Bitmap.FromFile(FilePath));

            // -- Bitmap pour l'image rognée --
            Bitmap _img = new Bitmap(cropWidthReal, cropHeightReal);

            // -- Création d'un graphique depuis l'image rognée
            Graphics g = Graphics.FromImage(_img);

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
        
        public static void verifPhotoEleve(Eleve eleve)
        {
            string nomFichierJPG = eleve.NomEleve + " " + eleve.PrenomEleve + ".jpg";
            string nomFichierPNG = eleve.NomEleve + " " + eleve.PrenomEleve + ".png";
            bool trouveBool = false;

            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @".\FichiersPHOTO");
            string sFilePath = Path.GetFullPath(sFile);

            DirectoryInfo directory = new DirectoryInfo(sFilePath);

            foreach (var file in directory.GetFiles())
            {
                int index = file.Name.IndexOf(".");
                if (file.Name.Substring(index, 4) == ".png")
                {
                    if (nomFichierPNG == file.Name)
                    {
                        trouveBool = true;
                        break;
                    }
                }

                else if (file.Name.Substring(index, 4) == ".jpg")
                {
                    if (nomFichierJPG == file.Name)
                    {
                        trouveBool = true;
                        break;
                    }
                }
            }

            if(trouveBool == false)
            {
                Globale.listeEleveSansPhoto.Add(eleve);
            }
        }
    }
}