using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Mime;
using System.Windows.Forms;
using CarteAccesLib;
using Word = Microsoft.Office.Interop.Word;

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
        
        public static void verifPhotoEleve(Eleve eleve, PictureBox pbPhoto)
        {
            string nomFichierJPG = eleve.NomEleve + " " + eleve.PrenomEleve + ".jpg";
            string nomFichierPNG = eleve.NomEleve + " " + eleve.PrenomEleve + ".png";
            bool trouveBool = false;

            if (File.Exists("./data/ElevesPhoto/" + nomFichierJPG))
            {
                pbPhoto.Image = Image.FromFile("./data/ElevesPhoto/" + nomFichierJPG);
            }
            else if(File.Exists("./data/ElevesPhoto/" + nomFichierPNG))
            {
                pbPhoto.Image = Image.FromFile("./data/ElevesPhoto/" + nomFichierPNG);
            }
            else
            {
                affichePhotoProvisoire("./data/ElevesPhoto/edition.jpg",pbPhoto);
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
        
        public static void affichePhotoProvisoire(string path,PictureBox pbPhoto)
        {
            pbPhoto.Image = new Bitmap(path);
            pbPhoto.Size = new Size(110, 165);
            pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPhoto.Visible = true;
        }

        public static void afficheEmploiDuTempsEleve(Eleve eleve, PictureBox pbCarteArriere)
        {
            string folder = "./data/image" + eleve.ClasseEleve.Substring(0, 1) + "eme";

            if(eleve.SansEDT == false)
            {
                pbCarteArriere.Image = Image.FromFile(folder + Eleve.creeCleeEleve(eleve));
            }

            else
            {
                pbCarteArriere.Image = Image.FromFile("./data/FichierEdtClasse/" + eleve.ClasseEleve + ".png");
            }
        }

        public static void chercheEdtPerso(List<Eleve> listeEleve, PictureBox pbCarteArriere)
        {
            foreach(Eleve eleve in listeEleve)
            {
                try
                {
                    string folder = "./data/image/" + eleve.ClasseEleve.Substring(0, 1) + "eme/";
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
        
        public static void fondTextCarteFace(Graphics ObjGraphics, string text, Font font, Eleve eleve, int posX, int posY)
        {
            Brush brushJaune = new SolidBrush(Color.Yellow);
            Brush brushVert = new SolidBrush(Color.LightGreen);
            Brush brushRouge = new SolidBrush(Color.Red);
            Brush brushBleu = new SolidBrush(Color.LightBlue);
            int largeur = Convert.ToInt32(ObjGraphics.MeasureString(text, font).Width);
            int hauteur = Convert.ToInt32(ObjGraphics.MeasureString(text, font).Height);
            Rectangle rectangle = new Rectangle(posX, posY, largeur, hauteur);

            // -- Couleur du rectangle en fonction de la section (donc de la couleur de la carte) --
            switch (eleve.ClasseEleve.Substring(0, 1))
            {
                case "6":
                    ObjGraphics.FillRectangle(brushJaune, rectangle);
                    ObjGraphics.DrawRectangle(new Pen(brushJaune), rectangle);
                    break;
                case "5":
                    ObjGraphics.FillRectangle(brushVert, rectangle);
                    ObjGraphics.DrawRectangle(new Pen(brushVert), rectangle);
                    break;
                case "4":
                    ObjGraphics.FillRectangle(brushRouge, rectangle);
                    ObjGraphics.DrawRectangle(new Pen(brushRouge), rectangle);
                    break;
                case "3":
                    ObjGraphics.FillRectangle(brushBleu, rectangle);
                    ObjGraphics.DrawRectangle(new Pen(brushBleu), rectangle);
                    break;
                default:
                    ObjGraphics.FillRectangle(brushJaune, rectangle);
                    ObjGraphics.DrawRectangle(new Pen(brushJaune), rectangle);
                    break;
            }
        }
        
        public static Image imageCarteFace(Eleve eleve, Font font)
        {
            Image image = Image.FromFile("./data/FichierCartesFace/" + eleve.ClasseEleve.Substring(0,1) + "eme.png");
            Graphics ObjGraphics = Graphics.FromImage(image);
            Brush brushNoir = new SolidBrush(Color.Black);

            Font font2 = new Font("comic sans ms", 30, FontStyle.Bold);
            Font font3 = new Font("comic sans ms", 15, FontStyle.Bold);

            string date = DateTime.Today.ToShortDateString();

            //Dessine et rempli le fond pour l'écriture
            fondTextCarteFace(ObjGraphics, eleve.NomEleve, font, eleve, 250, 960);
            fondTextCarteFace(ObjGraphics, eleve.PrenomEleve, font, eleve, 350, 1075);
            fondTextCarteFace(ObjGraphics, eleve.MefEleve, font2, eleve, 50, 70);
            fondTextCarteFace(ObjGraphics, "Date de création: " + date, font3, eleve, 870, 875);

            //Dessine la saisie en textbox
            ObjGraphics.DrawString(eleve.NomEleve, font, brushNoir, 250, 960);// Dessine le texte sur l'image à la position X et Y + couleur
            ObjGraphics.DrawString(eleve.PrenomEleve, font, brushNoir, 350, 1075);
            ObjGraphics.DrawString(eleve.MefEleve, font2, brushNoir, 50, 70);
            ObjGraphics.DrawString("Date de création: " + date, font3, brushNoir, 870, 875);
            ObjGraphics.Dispose();// Libère les ressources

            return image;
        }
        
        public static void carteFace(Eleve eleve, string path)
        {
            // -- Déclare l'image --
            Image imageFace = null;

            // -- Gestion de la taille de la police --
            if (eleve.NomEleve.Length > 10 || eleve.PrenomEleve.Length > 10)
            {
                Font font = new Font("times new roman", 20, FontStyle.Bold);
                imageFace = imageCarteFace(eleve, font);
            }
            else
            {
                Font font = new Font("times new roman", 25, FontStyle.Bold);
                imageFace = imageCarteFace(eleve, font);
            }

            // -- Sauvegarde l'image --
            imageFace.Save(path + "/" + eleve.NomEleve + eleve.PrenomEleve + "Carte.png", System.Drawing.Imaging.ImageFormat.Png);

        }

        public static void carteArriere(Eleve eleve, PictureBox pbCarteArriere)
        {
            if (eleve.SansEDT == false)
            {
                string pathEdt = "./data/image/" + eleve.ClasseEleve.Substring(0, 1) + "eme/" + Eleve.creeCleeEleve(eleve) + ".jpg";
                pbCarteArriere.Image = Image.FromFile(pathEdt);
                cropEdt(pbCarteArriere, pathEdt);
            }
            else
            {
                pbCarteArriere.Image = Image.FromFile("./data/FichierEdtClasse/" + eleve.ClasseEleve + ".png");
            }
        }

        public static void proportionPhoto(PictureBox pbPhoto, PictureBox pbCarteArriere, Eleve eleve, string path)
        {
            // -- Calcul par proportionnalité de la position et des dimensions de la photo sur le cadre de l'application par rapport a l'image réelle --
            // -- Cela permet de répercuter les déplacements effectués par l'utilisateur sur l'image originelle afin de pouvoir réutiliser celle ci --
            // -- Et ainsi ne pas perdre en qualité de l'image --
            int realLocX = (pbPhoto.Location.X * pbCarteArriere.Image.Width) / pbCarteArriere.Width;
            int realLocY = (pbPhoto.Location.Y * pbCarteArriere.Image.Height) / pbCarteArriere.Height;
            int realWidth = (pbPhoto.Width * pbCarteArriere.Image.Width) / pbCarteArriere.Width;
            int realHeight = (pbPhoto.Height * pbCarteArriere.Image.Height) / pbCarteArriere.Height;

            // -- Superposition des deux image dans un objet "Graphics" --
            Graphics ObjGraphics = Graphics.FromImage(pbCarteArriere.Image);
            ObjGraphics.DrawImage(pbPhoto.Image, realLocX, realLocY, realWidth, realHeight);

            pbCarteArriere.Image.Save(path + "/" + eleve.NomEleve + eleve.PrenomEleve + "EDT.png", System.Drawing.Imaging.ImageFormat.Png);

            System.Threading.Thread.Sleep(1000);
        }
        
        public static void saveCardAsWord(string path, string nomFicher, List<Eleve> listeEleve, PictureBox pbPhoto, PictureBox pbCarteArriere)
        {
            int k = 0;
            int pages = 0;
            Eleve.possedeEdt(listeEleve);
            Word.Application wordFile = WordFile.initWordFile(15,15,15,15);

            for (int compt = 1; compt <= listeEleve.Count; compt += 2)
            {
                // -- Les élèves sont gérés deux par deux --

                // -- Carte Face : 1/2 Eleve --
                carteFace(listeEleve[compt], path);
                // -- Carte Face : 2/2 Eleve --
                carteFace(listeEleve[compt - 1], path);

                // -- Ajout des deux fichier PNG au nouveau document Word --
                var shapeCarteFace1 = wordFile.ActiveDocument.Shapes.AddPicture(
                    path + "\\" + listeEleve[compt].NomEleve + listeEleve[compt].PrenomEleve + "Carte.png",
                    Type.Missing, Type.Missing, Type.Missing);
                var shapeCarteFace2 = wordFile.ActiveDocument.Shapes.AddPicture(
                    path + "\\" + listeEleve[compt - 1].NomEleve + listeEleve[compt - 1].PrenomEleve + "Carte.png",
                    Type.Missing, Type.Missing, Type.Missing);
                WordFile.rectifPositionImages(shapeCarteFace1, shapeCarteFace2);
                // -- Suppression des deux fichiers PNG, plus besoin d'eux maintenant qu'ils sont dans le fichier Word -- 
                File.Delete(path + "\\" + listeEleve[compt].NomEleve + listeEleve[compt].PrenomEleve + "Carte.png");
                File.Delete(path + "\\" + listeEleve[compt - 1].NomEleve + listeEleve[compt - 1].PrenomEleve +
                            "Carte.png");
                //Permet d'éviter la surcharge de mémoire qui s'arrête à 2400 ko, puis l'application s'arrête
                GC.Collect();
                // -- Nouvelle page --
                wordFile.Selection.EndKey();
                wordFile.Selection.InsertNewPage();

                // ------------------------------------------------------------------

                // -- Carte arriere : 1/2 Eleve --
                carteArriere(listeEleve[compt], pbCarteArriere);
                verifPhotoEleve(listeEleve[compt], pbPhoto);
                proportionPhoto(pbPhoto, pbCarteArriere, listeEleve[compt],path);
                // -- Carte arriere : 2/2 Eleve --
                carteArriere(listeEleve[compt - 1], pbCarteArriere);
                verifPhotoEleve(listeEleve[compt - 1], pbPhoto);
                proportionPhoto(pbPhoto, pbCarteArriere, listeEleve[compt - 1], path);

                // -- Ajout des deux fichier PNG au nouveau document Word --
                var shapeCarteArriere1 = wordFile.ActiveDocument.Shapes.AddPicture(
                    path + "/" + listeEleve[compt].NomEleve + listeEleve[compt].PrenomEleve + "EDT.png", Type.Missing,
                    Type.Missing, Type.Missing);
                var shapeCarteArriere2 = wordFile.ActiveDocument.Shapes.AddPicture(
                    path + "/" + listeEleve[compt - 1].NomEleve + listeEleve[compt - 1].PrenomEleve + "EDT.png",
                    Type.Missing, Type.Missing, Type.Missing);

                WordFile.rectifPositionImages(shapeCarteArriere1, shapeCarteArriere2);

                // -- Suppression des deux fichiers PNG, plus besoin d'eux maintenant qu'ils sont dans le fichier Word -- 
                File.Delete(path + "\\" + listeEleve[compt].NomEleve + listeEleve[compt].PrenomEleve + "EDT.png");
                File.Delete(
                    path + "\\" + listeEleve[compt - 1].NomEleve + listeEleve[compt - 1].PrenomEleve + "EDT.png");

                //Permet d'éviter la surcharge de mémoire qui s'arrête à 2400 ko, puis l'application s'arrête
                GC.Collect();

                // -- Nouvelle page --

                wordFile.Selection.EndKey();
                wordFile.Selection.InsertNewPage();

                if (compt > k + 50)
                {
                    string name = path + " page " + (k / 50).ToString();
                    WordFile.limite50Pages(wordFile, name);
                    k += 50;
                    pages++;
                }
            }

            if (k/50 == 1)
            {
                wordFile.ActiveDocument.SaveAs(path + "/Imprimer.doc", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            else
            {
                wordFile.ActiveDocument.SaveAs(path + "/Imprimer Part " + pages + ".doc", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            
            // -- Ferme le document --
            wordFile.ActiveDocument.Close();

            // -- Quitte l'application -- 
            wordFile.Quit();

            // -- TaskKill --
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(wordFile);

            //Permet d'éviter la surcharge de mémoire qui s'arrête à 2400 ko, puis l'application s'arrête
            GC.Collect();

            // -- Message qui indique que nous sommes arrivé au bout --
            MessageBox.Show(listeEleve.Count + " élèves ont été imprimés.");
        }

        public static void easterEgg()
        {
            string gitPoule1 = "⠀⠀⠀⠀⠀⣀⡀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀ ⠀⠀⠀⠀ ⢀⣤⣤ ⣤⣄⠀⠀ ⠀⠀⠀⠀⠀";
            string gitPoule2 = "⠀⠀⣴⠾⣿⣿⣷⣀⠀  ⠀⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀ ⠀⠀⠀⣴ ⡏⠙⣿ ⡥⣿⣻⣆ ⣀⠀⠀⠀⠀";
            string gitPoule3 = "⠀⠸⣯⠞⣽⠸⣄⠀⠉  ⢤⡀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀ ⠀⠀⠸⢸ ⠀⠀⠹ ⠇⠟⡽⠁ ⣸⢤⡄⠀⠀";
            string gitPoule4 = "⠀⣾⣿⢦⡈⢀⣿⠀⠀  ⠀⠙⠷⣄⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀ ⠀⠀⣇⣈ ⠄⠀⠀ ⢀⣰⠃⡰ ⠃⣰⣻⡆⠀";
            string gitPoule5 = "⠈⠁⢸⠀⢻⡞⠁⠀⠀  ⠀⢲⣠⣜⢳⣄⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⣠ ⠴⠚⠉⠀ ⠀⠀⠘ ⢹⣯⠀⠀ ⣠⣿⠏⣹⣄";
            string gitPoule6 = "⠀⠀⠈⠓⣻⠁⢀⠀⠀  ⠀⢠⠙⢻⣿⡿⢦⡀⠀  ⠀⠀⠀⢀⡴⠞⠁ ⠀⠀⠀⠀ ⠀⠀⠀ ⠀⠘⠦⣬ ⡏⢁⣴⣍⡟";
            string gitPoule7 = "⠀⠀⠀⠀⡟⠀⣼⡄⣷  ⣦⠀⠳⠀⠀⡀⠤⠷⠖  ⠒⠒⣻⡋⠀⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀ ⠀⠀⠀⠘ ⠛⠿⣿⡛⣦";
            string gitPoule8 = "⠀⠀⠀⢸⡇⠀⢹⣷⠙  ⣿⠦⠒⠒⠉⠀⠀⠠⠴  ⠒⠀⠀⠉⠉⠒⠢ ⠤⣀⡀⠀ ⢀⣼⡄ ⠀⠀⣲⠀ ⠀⠀⣠⠟⠃";
            string gitPoule9 = "⠀⠀⠀⢸⡇⠦⠞⠋⠀  ⠀⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀ ⠀⡀⠈⠙ ⠲⠤⡅ ⠠⠾⠋⠀ ⠀⠀⣸⠀⠀";
            string gitPoule10 = "⠀⠀⠀⠸⣇⠀⠀⠀  ⠀⠀⠀⠐⠦⣄⠀⠀⠀  ⠀⠀⠀⠀⠀⢀⡄ ⠀⢸⢁⣀ ⣀⣀⣠ ⣧⠀⠀⣠ ⣐⠆⣠⠃⠀⠀";
            string gitPoule11 = "⠀⠀⠀⠀⢻⡆⠀⠀  ⠀⠀⠀⠀⠀⠈⠿⢤⣄  ⠀⠀⠀⠀⢀⠞⠀ ⠀⡞⠀⠤ ⠤⠖⣲ ⡞⠁⠀⠐ ⢃⣤⠋⠀⠀⠀";
            string gitPoule12 = "⠀⠀⠀⠀⠀⢻⡄⠀  ⠀⠀⠀⠀⠀⠀⠀⠀⠺  ⣷⣀⡠⠼⣧⠃⠐ ⠊⣠⠴⠖ ⠛⠉⠀ ⠉⠻⢷⣶ ⠞⠁⠀⠀⠀⠀";
            string gitPoule13 = "⠀⠀⠀⠀⠀⠀⠹⣦  ⠀⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠘⠛⢦⣅⡤⠖ ⠉⠀⠀⠀ ⠀⠀⠀ ⣀⣠⣼⡇ ⠀⠀⠀⠀⠀⠀";
            string gitPoule14 = "⠀⠀⠀⠀⠀⠀⠀⠈  ⢦⣀⠀⠀⠀⠀⠀⠀⠀  ⣀⢀⣀⠈⠁⣀⠀ ⠀⠀⠀⠀ ⠀⡀⢀ ⠀⢠⡿⠁ ⠀⠀⠀⠀⠀⠀";
            string gitPoule15 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠙⢷⡄⠀⠀⠤⠶⠖  ⠀⠀⠀⠀⠀⠘⡄ ⠀⠀⠀⠀ ⠀⠩⠓ ⣶⠟⠀⠀ ⠀⠀⠀⠀⠀⠀";
            string gitPoule16 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠈⢻⣆⠀⠀⠀⠀  ⠀⠀⠀⠀⢀⣿⣇ ⣶⣦⣀⡄ ⠀⣤⡟ ⠉⠀⠀⠀ ⠀⠀⠀⠀⠀⠀";
            string gitPoule17 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠻⣆⠀⠀⠀  ⠀⠀⠀⠀⠀⠛⣯ ⣿⣿⣿⡿ ⠟⠉⠀ ⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⠀";
            string gitPoule18 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠙⢧⡀⠀  ⠀⠀⠀⢀⣴⣟⣉ ⠿⠋⠁⠀ ⠀⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⠀";
            string gitPoule19 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀⠈⢹  ⠛⡿⠚⠉⠀⠹⣿ ⠀⠀⠀⠀ ⠀⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⠀";
            string gitPoule20 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀⠀⣬  ⡞⠁⠀⠀⠀⠀⢻ ⣇⠀⣠⡴ ⠆⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⠀";
            string gitPoule21 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⢀⣀⣀⣀⣀⣴⢿  ⡁⠀⠀⢠⣤⠤⠼ ⣯⡿⠋⠀ ⠀⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⠀";
            string gitPoule22 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⣿⣟⣻⡿⠿⠓⠒  ⠚⠓⠀⢻⡗⠒⠛ ⠉⠀⠀⠀ ⠀⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⠀";
            string gitPoule23 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠉⠉⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";

            List<string> ListePoule = new List<string>(); 
            ListePoule.Add(gitPoule1);
            ListePoule.Add(gitPoule2);  
            ListePoule.Add(gitPoule3);  
            ListePoule.Add(gitPoule4);  
            ListePoule.Add(gitPoule5);  
            ListePoule.Add(gitPoule6);  
            ListePoule.Add(gitPoule7);  
            ListePoule.Add(gitPoule8);  
            ListePoule.Add(gitPoule9);  
            ListePoule.Add(gitPoule10);  
            ListePoule.Add(gitPoule11);  
            ListePoule.Add(gitPoule12);  
            ListePoule.Add(gitPoule13);  
            ListePoule.Add(gitPoule14);  
            ListePoule.Add(gitPoule15);  
            ListePoule.Add(gitPoule16);  
            ListePoule.Add(gitPoule17);  
            ListePoule.Add(gitPoule18);  
            ListePoule.Add(gitPoule19);  
            ListePoule.Add(gitPoule20);  
            ListePoule.Add(gitPoule21);  
            ListePoule.Add(gitPoule22);  
            ListePoule.Add(gitPoule23);
            foreach (string gitPoule in ListePoule)
            {
                Console.WriteLine(gitPoule);
            }

            


    }
            
    }
}