using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using CartesAcces;

namespace CarteAcces
{
    public static class Photo
    {
        private static bool pasDePhoto = false;
        public static void verifPhotoEleve(Eleve eleve, PictureBox pbPhoto)
        {
            var nomFichierJPG = eleve.NomEleve + " " + eleve.PrenomEleve + ".jpg";
            var nomFichierPNG = eleve.NomEleve + " " + eleve.PrenomEleve + ".png";

            if (File.Exists("./data/ElevesPhoto/" + nomFichierJPG))
                pbPhoto.Image = Image.FromFile("./data/ElevesPhoto/" + nomFichierJPG);
            else if (File.Exists("./data/ElevesPhoto/" + nomFichierPNG))
                pbPhoto.Image = Image.FromFile("./data/ElevesPhoto/" + nomFichierPNG);
            else
                pasDePhoto = true;
                pbPhoto.Image = Image.FromFile("./data/ElevesPhoto/edition.jpg");
        }

        public static void affichePhotoProvisoire(string chemin, PictureBox pbPhoto)
        {
            pbPhoto.Image = new Bitmap(chemin);
            pbPhoto.Size = new Size(110, 165);
            pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPhoto.Visible = true;
        }

        public static void proportionPhoto(PictureBox pbPhoto, PictureBox pbCarteArriere, Eleve eleve, string path)
        {
            // -- Calcul par proportionnalité de la position et des dimensions de la photo sur le cadre de l'application par rapport a l'image réelle --
            // -- Cela permet de répercuter les déplacements effectués par l'utilisateur sur l'image originelle afin de pouvoir réutiliser celle ci --
            // -- Et ainsi ne pas perdre en qualité de l'image --
            double rLocX = 0.0;
            double rLocY = 0.0;
            double rWidth = 0.0;
            double rHeight = 0.0;
            
            if (pasDePhoto)
            {
                rLocX = Edition.PosYClassique * pbCarteArriere.Image.Width / pbCarteArriere.Width;
                rLocY = Edition.PosXClassique * pbCarteArriere.Image.Height / pbCarteArriere.Height;
                rWidth = pbPhoto.Width * pbCarteArriere.Image.Width / pbCarteArriere.Width;
                rHeight = pbPhoto.Height * pbCarteArriere.Image.Height / pbCarteArriere.Height;
            }
            else
            {
                rLocX = Edition.PosX * pbCarteArriere.Image.Width / pbCarteArriere.Width;
                rLocY = Edition.PosY * pbCarteArriere.Image.Height / pbCarteArriere.Height;
                rWidth = pbPhoto.Width * pbCarteArriere.Image.Width / pbCarteArriere.Width;
                rHeight = pbPhoto.Height * pbCarteArriere.Image.Height / pbCarteArriere.Height;
            }

            int realLocX = Convert.ToInt32(Math.Round(rLocX)) - 2;
            int realLocY = Convert.ToInt32(Math.Round(rLocY)) + 3;
            int realWidth = Convert.ToInt32(Math.Round(rWidth)) - 1;
            int realHeight = Convert.ToInt32(Math.Round(rHeight)) - 1;

            // -- Superposition des deux image dans un objet "Graphics" --
            var ObjGraphics = Graphics.FromImage(pbCarteArriere.Image);
            ObjGraphics.DrawImage(pbPhoto.Image, realLocX, realLocY, realWidth, realHeight);

            pbCarteArriere.Image.Save(path + "/" + eleve.NomEleve + eleve.PrenomEleve + "EDT.png", ImageFormat.Png);

            Thread.Sleep(1000);
        }

        public static string getDatePhotos()
        {
            var dateFile = "Aucune Importation";
            var dir = new DirectoryInfo(Chemin.CheminPhotoEleve);
            if (dir.Exists) dateFile = dir.CreationTime.ToString();

            return dateFile;
        }
    }
}