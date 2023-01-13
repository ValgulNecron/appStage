using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CartesAcces
{
    public static class Edition
    {
        // ** VARIABLES : Pour l'édition de l'emploi du temps (rognage) **
        public static bool selectionClick = false;     // -> Est ce que le bouton "Selectionner" a été cliqué ? Si oui passe à true
        public static int cropX;       // -> Abscisse de départ du rognage
        public static int cropY;       // -> Ordonnée de départ du rognage
        public static int cropWidth;       // -> Largeur du rognage
        public static int cropHeight;      // -> Hauteur du rognage
        public static Pen cropPen;     // -> Stylo qui dessine le rectangle correspondant au rognage

        // ** VARIABLES  : Déplacement de la photo
        public static bool drag = false;       // -> Est ce que l'utilisateur a cliqué sur la photo ? (clique maintenue : drag passera a true)
        public static int posX;        // -> Abscisse initiale, sauvegardée quand l'utilisateur commence le déplacement (clic maintenu sur la photo)
        public static int posY;        // -> Ordonnée initialie, sauvegardée quand l'utilisateur commence le déplacement (clic maintenu sur la photo)

        // ** VARIABLES : Provisoires.. **
        public static string affichageTest;

        // ** VARIABLES : Chemin de l'image **
        public static string FilePath;
        
        public static string cheminImpressionFinal;
        
        // -- Selection du bon emploi du temps en fonction de la classe selectionnée
        public static void afficheEmploiDuTemps(ComboBox cbbClasse, PictureBox pbCarteArriere)
        {
            if(cbbClasse.Text != "")
            {
                string classe = cbbClasse.Text;
                pbCarteArriere.Image = Image.FromFile("./data/FichierEdtClasse/" + classe + ".png");
            }
        }
        
        // -- Dessine le rectangle de couleur derrière le text pour une meilleurs visibilité de celui ci --
        public static void fondTextCarteFace(Graphics ObjGraphics, string text, Font font, int posX, int posY, ComboBox cbbSection)
        {
            Brush brushJaune = new SolidBrush(Color.Yellow);
            Brush brushVert = new SolidBrush(Color.LightGreen);
            Brush brushRouge = new SolidBrush(Color.Red);
            Brush brushBleu = new SolidBrush(Color.LightBlue);
            int largeur = Convert.ToInt32(ObjGraphics.MeasureString(text, font).Width);
            int hauteur = Convert.ToInt32(ObjGraphics.MeasureString(text, font).Height);
            Rectangle rectangle = new Rectangle(posX, posY, largeur, hauteur);

            // -- Couleur du rectangle en fonction de la section (donc de la couleur de la carte) --
            switch (cbbSection.Text)
            {
                case "6eme":
                    ObjGraphics.FillRectangle(brushJaune, rectangle);
                    ObjGraphics.DrawRectangle(new Pen(brushJaune), rectangle);
                    break;
                case "5eme":
                    ObjGraphics.FillRectangle(brushVert, rectangle);
                    ObjGraphics.DrawRectangle(new Pen(brushVert), rectangle);
                    break;
                case "4eme":
                    ObjGraphics.FillRectangle(brushRouge, rectangle);
                    ObjGraphics.DrawRectangle(new Pen(brushRouge), rectangle);
                    break;
                case "3eme":
                    ObjGraphics.FillRectangle(brushBleu, rectangle);
                    ObjGraphics.DrawRectangle(new Pen(brushBleu), rectangle);
                    break;
            }
        }
        
        // -- Dessine le text des cases sur la carte --
        public static void dessineTextCarteFace(Font font, int posX, int posY, string text, PictureBox pbCarteFace, ComboBox cbbSection)
        {
            //Pinceaux et graphique
            Graphics ObjGraphics = Graphics.FromImage(pbCarteFace.Image);
            Brush brushNoir = new SolidBrush(Color.Black);

            //Dessine et rempli le fond pour l'écriture
            fondTextCarteFace(ObjGraphics, text, font, posX, posY, cbbSection);

            //Dessine la saisie en textbox
            ObjGraphics.DrawString(text, font, brushNoir, posX, posY);// Dessine le texte sur l'image à la position X et Y + couleur
            ObjGraphics.Dispose();// Libère les ressources
        }
        
        // -- Change le fond de la carte en fonction de la section choisie
        public static void fondCarteSection(PictureBox pbCarteFace, ComboBox cbbSection)
        {
            pbCarteFace.Image = Image.FromFile("./data/FichierCartesFace/" + cbbSection.Text + ".png");
            string date = DateTime.Today.ToShortDateString();
            Font font = new Font("comic sans ms", 45, FontStyle.Bold);
            dessineTextCarteFace(font, 50, 70, "Carte Provisoire", pbCarteFace, cbbSection);
            Font font2 = new Font("comic sans ms", 15, FontStyle.Bold);
            dessineTextCarteFace(font2, 870, 875, "Date de création : " + date, pbCarteFace, cbbSection);
            pbCarteFace.Refresh();
        }
        
        // -- N'affiche que les classes correspondantes a la section selectionnées --
        public static void classePourSection(ComboBox cbbSection, ComboBox cbbClasse)
        {
            switch (cbbSection.Text)
            {
                case "6eme":
                    cbbClasse.DataSource = Globale.classes6eme;
                    break;

                case "5eme":
                    cbbClasse.DataSource = Globale.classes5eme;
                    break;

                case "4eme":
                    cbbClasse.DataSource = Globale.classes4eme;
                    break;

                case "3eme":
                    cbbClasse.DataSource = Globale.classes3eme;
                    break;

                default:
                    break;
            }
        }
        
        public static void ajouterEdtPerso(PictureBox pbCarteArriere)
        {
            // -- Parcours des fichiers...
            OpenFileDialog opf = new OpenFileDialog();

            string opfPath = "";

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

        public static void reprendPrenom(TextBox txtPrenom, PictureBox pbCarteFace,
            ComboBox cbbSection)
        {
            if (txtPrenom.Text != "")
            {
                if (txtPrenom.TextLength < 7)
                {
                    Font font = new Font("times new roman", 25, FontStyle.Bold);
                    dessineTextCarteFace(font, 350, 1075, txtPrenom.Text, pbCarteFace, cbbSection);
                    pbCarteFace.Refresh();
                }
                else
                {
                    fondCarteSection(pbCarteFace, cbbSection);
                    Font font = new Font("times new roman", 20, FontStyle.Bold);
                    dessineTextCarteFace(font, 350, 1075, txtPrenom.Text, pbCarteFace, cbbSection);
                    pbCarteFace.Refresh();
                }
            }
        }

        public static void reprendNom(TextBox txtNom, PictureBox pbCarteFace, ComboBox cbbSection)
            {
                if (txtNom.Text != "")
                {
                    if (txtNom.TextLength < 7)
                    {
                        Font font = new Font("times new roman", 25, FontStyle.Bold);
                        dessineTextCarteFace(font, 250, 960, txtNom.Text, pbCarteFace, cbbSection);
                        pbCarteFace.Refresh();
                    }
                    else
                    {
                        fondCarteSection(pbCarteFace, cbbSection);
                        Font font = new Font("times new roman", 20, FontStyle.Bold);
                        dessineTextCarteFace(font, 250, 960, txtNom.Text, pbCarteFace, cbbSection);
                        pbCarteFace.Refresh();
                    }
                }
            }
        public static void checkMef(RadioButton rdbUlis, RadioButton rdbUPE2A, RadioButton rdbClRelais, PictureBox pbCarteFace, ComboBox cbbSection, Button btnEdtPerso, TextBox txtNom, TextBox txtPrenom)
        {
            if (rdbUlis.Checked == true)
            {
                Font font = new Font("comic sans ms", 30, FontStyle.Bold);
                Edition.dessineTextCarteFace(font, 50, 230, "ULIS ", pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
                btnEdtPerso.Enabled = true;
            }
            else if (rdbUPE2A.Checked == true)
            {
                Font font = new Font("comic sans ms", 30, FontStyle.Bold);
                Edition.dessineTextCarteFace(font, 50, 230, "UPE2A", pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
                btnEdtPerso.Enabled = true;
            }
            else if (rdbClRelais.Checked == true)
            {
                Font font = new Font("comic sans ms", 30, FontStyle.Bold);
                Edition.dessineTextCarteFace(font, 50, 230, "CL-Relais", pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
                btnEdtPerso.Enabled = true;
            }
            else
            {
                Edition.fondCarteSection(pbCarteFace, cbbSection);
                Edition.reprendNom(txtNom, pbCarteFace, cbbSection);
                Edition.reprendPrenom(txtPrenom, pbCarteFace, cbbSection);
                btnEdtPerso.Enabled = false;
            }
        }

        // -------------------------
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
            string sFile = System.IO.Path.Combine(sCurrentDirectory, "./data/ElevesPhoto");
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

        public static void cropEdt(PictureBox pbCarteArriere, string pathEdt)
        {
            // -- Si la largeur a rogner est trop faible, on sort --
            if (Edition.cropWidth < 1)
            {
                return;
            }

            /* -- Rectangle pour stocker l'image rognée avec les points calculés --
                Les dimensions calculées ci dessous utilisent les dimensions 920 x 604 (calcul par proportionnalité)
                qui sont celles des vrai fichier EDT !
                Cela permet d'éviter les problèmes de résolution d'image après le rognage */
            
            int cropWidthReal = (Edition.cropWidth * pbCarteArriere.Image.Width) / 540;
            int cropHeightReal = (Edition.cropHeight * pbCarteArriere.Image.Height) / 354;
            int cropXReal = (Edition.cropX * pbCarteArriere.Image.Width) / 540;
            int cropYReal = (Edition.cropY * pbCarteArriere.Image.Height) / 354;

            Rectangle rect = new Rectangle(cropXReal, cropYReal, cropWidthReal, cropHeightReal);

            // -- On stock l'image original dans un bitmap --
            Bitmap OriginalImage = new Bitmap(Bitmap.FromFile(pathEdt));

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
            pbCarteArriere.Image = _img;
            pbCarteArriere.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCarteArriere.Width = 540;
            pbCarteArriere.Height = 354;
        }
    }
}