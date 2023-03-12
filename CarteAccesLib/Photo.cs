using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using CartesAcces;

namespace CarteAccesLib
{
    /// <summary>
    /// Cette classe permet de gérer les photos
    /// </summary>
    public static class Photo
    {
        /// <summary>
        /// Cette fonction permet de vérifier si une photo existe pour un élève
        /// </summary>
        /// <param name="eleve"></param>
        /// <param name="pbPhoto"></param>
        public static void VerifPhotoEleve(Eleve eleve, PictureBox pbPhoto)
        {
            var nomFichierJpg = eleve.NomEleve + " " + eleve.PrenomEleve + ".jpg";
            var nomFichierPng = eleve.NomEleve + " " + eleve.PrenomEleve + ".png";

            if (File.Exists("./data/ElevesPhoto/" + nomFichierJpg))
                pbPhoto.Image = Image.FromFile("./data/ElevesPhoto/" + nomFichierJpg);
            else if (File.Exists("./data/ElevesPhoto/" + nomFichierPng))
                pbPhoto.Image = Image.FromFile("./data/ElevesPhoto/" + nomFichierPng);
            else
                pbPhoto.Image = Image.FromFile("./data/edition.jpg");
        }

        /// <summary>
        /// Cette fonction permet de d'afficher une photo provisoire
        /// </summary>
        /// <param name="chemin"></param>
        /// <param name="pbPhoto"></param>
        public static void AffichePhotoProvisoire(string chemin, PictureBox pbPhoto)
        {
            pbPhoto.Image = new Bitmap(chemin);
            pbPhoto.Size = new Size(110, 165);
            pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPhoto.Visible = true;
        }

        /// <summary>
        /// Cette fonction permet de gérer les proportions de la photo
        /// </summary>
        /// <param name="pbPhoto"></param>
        /// <param name="pbCarteArriere"></param>
        /// <param name="eleve"></param>
        /// <param name="path"></param>
        public static void ProportionPhotoMultiple(PictureBox pbPhoto, PictureBox pbCarteArriere, Eleve eleve,
            string path)
        {
            // -- Calcul par proportionnalité de la position et des dimensions de la photo sur le cadre de l'application par rapport a l'image réelle --
            // -- Cela permet de répercuter les déplacements effectués par l'utilisateur sur l'image originelle afin de pouvoir réutiliser celle ci --
            // -- Et ainsi ne pas perdre en qualité de l'image --
            //double rLocX = 0.0;
            //double rLocY = 0.0;
            //double rWidth = 0.0;
            //double rHeight = 0.0;

            var rLocX = Edition.PosXDef * pbCarteArriere.Image.Width / pbCarteArriere.Width;
            var rLocY = Edition.PosYDef * pbCarteArriere.Image.Height / pbCarteArriere.Height;
            var rWidth = Edition.PosWidthDef * pbCarteArriere.Image.Width / pbCarteArriere.Width;
            var rHeight = Edition.PosHeightDef * pbCarteArriere.Image.Height / pbCarteArriere.Height;

            if (eleve.SansEdt)
            {
                rLocX = Edition.PosXClassique * pbCarteArriere.Image.Width / pbCarteArriere.Width;
                rLocY = Edition.PosYClassique * pbCarteArriere.Image.Height / pbCarteArriere.Height;
                rWidth = pbPhoto.Width * pbCarteArriere.Image.Width / pbCarteArriere.Width;
                rHeight = pbPhoto.Height * pbCarteArriere.Image.Height / pbCarteArriere.Height;
            }

            // -- Superposition des deux image dans un objet "Graphics" --
            var objGraphics = Graphics.FromImage(pbCarteArriere.Image);
            objGraphics.DrawImage(pbPhoto.Image, rLocX, rLocY, rWidth, rHeight);

            pbCarteArriere.Image.Save(path + "/" + eleve.NomEleve + eleve.PrenomEleve + "EDT.png", ImageFormat.Png);

            Thread.Sleep(1000);
        }

        /// <summary>
        /// Cette fonction permet d'obtenir la date de la dernière importation des photos
        /// </summary>
        /// <returns></returns>
        public static string GetDatePhotos()
        {
            var dateFile = "Aucune Importation";
            var dir = new DirectoryInfo(Chemin.CheminPhotoEleve);
            if (dir.Exists) dateFile = dir.CreationTime.ToString(CultureInfo.InvariantCulture);

            return dateFile;
        }
    }
}