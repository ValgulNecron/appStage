using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace CartesAcces
{
    public partial class frmMultiplesCartesEdition : Form
    {
        // ** VARIABLES : Liste et selection bool **
        public List<Eleve> listeEleve;
        public List<string> listeCleeEleve = new List<string>();
        public List<Eleve> listeSansEDT = new List<Eleve>();

        public bool imprSection;
        public bool imprClasse;
        public bool imprListe;

        public string cheminImpressionFinal;

        // ** VARIABLES : Pour l'édition de l'emploi du temps (rognage) **
        public bool selectionClick = false;     // -> Est ce que le bouton "Selectionner" a été cliqué ? Si oui passe à true
        public int cropX;       // -> Abscisse de départ du rognage
        public int cropY;       // -> Ordonnée de départ du rognage
        public int cropWidth;       // -> Largeur du rognage
        public int cropHeight;      // -> Hauteur du rognage
        public Pen cropPen;     // -> Stylo qui dessine le rectangle correspondant au rognage

        // ** VARIABLES  : Déplacement de la photo **
        public bool drag = false;       // -> Est ce que l'utilisateur a cliqué sur la photo ? (clique maintenue : drag passera a true)
        public int posX;        // -> Abscisse initiale, sauvegardée quand l'utilisateur commence le déplacement (clic maintenu sur la photo)
        public int posY;        // -> Ordonnée initialie, sauvegardée quand l'utilisateur commence le déplacement (clic maintenu sur la photo)

        public frmMultiplesCartesEdition()
        {
            InitializeComponent();

            //cache les deux éléments jusqu'à ce qu'on veut qu'ils soient visible
            progressBar1.Hide(); // animation de la barre
            label1.Hide(); // label de la barre de progression
        }

        public void affecterListeClee()
        {
            // -- Liste des noms de fichier --
            List<string> listeNomFichier = new List<string>();

            string sFilePath = getFilePath("FichiersEDT");
            sFilePath += "\\" + getNiveau(0);
            DirectoryInfo directory = new DirectoryInfo(sFilePath);

            // -- On remplit la liste avec les noms trouvés --
            foreach (var file in directory.GetFiles())
            {
                listeNomFichier.Add(file.Name);
            }

            // -- Création d'une clé pour chaques élèves de la liste --
            foreach (Eleve eleve in listeEleve)
            {
                // Nom prenom classe
                string clé = "Elève " + eleve.NomEleve + " " + eleve.PrenomEleve + " " + eleve.ClasseEleve;

                // Correction sur le regime
                if (eleve.RegimeEleve == "EXTERN")
                {
                    clé += " - Externe";
                }
                else if (eleve.RegimeEleve.Substring(0, 2) == "DP")
                {
                    clé += " - 12P";
                }

                // Option 1
                clé += " - " + eleve.OptionUnEleve;

                // Option 2
                if (eleve.OptionDeuxEleve != "")
                {
                    clé += " - " + eleve.OptionDeuxEleve;
                }

                // Option 3
                if (eleve.OptionTroisEleve != "")
                {
                    clé += " - " + eleve.OptionTroisEleve;
                }

                // Option 4
                if (eleve.OptionQuatreEleve != "")
                {
                    clé += " - " + eleve.OptionQuatreEleve;
                }

                // -- On ajoute la clé a la liste --
                listeCleeEleve.Add(clé);

                // -- Recherche de si l'élève a bien un emploi du temps dans le dossier correspondant a sa clé --
                bool bTrouve = false;

                // -- Pour chaques fichier dans la liste faite précédemment .. --
                foreach (string fichier in listeNomFichier)
                {
                    // -- Si la clé correspond a l'un d'entre eux --
                    
                    if (clé + ".png" == fichier)
                    {
                        bTrouve = true;
                        // -- On passe directement a la suite --
                        break;
                    }

                    // -- Sinon on continue .. --
                    else
                    {
                        bTrouve = false;
                    }

                    // -- .. jusqu'a la fin de la liste de nom --
                    
                }

                // -- Si on a pas trouvé .. --
                if (bTrouve == false)
                {
                    // -- .. l'élève est noté comme sans edt --
                    eleve.SansEDT = true;
                }
            }
        }

        public string getNiveau(int indexEleve)
        {
            string folder = "";

            switch (listeEleve[indexEleve].ClasseEleve.Substring(0, 1))
            {
                case "3":
                    folder = "3EME";
                    break;
                case "4":
                    folder = "4EME";
                    break;
                case "5":
                    folder = "5EME";
                    break;
                case "6":
                    folder = "6EME";
                    break;
            }

            return folder;
        }

        public void afficheEmploiDuTemps(int indexEleve)
        {
            string folder = getNiveau(indexEleve);

            if(imprListe == true && listeEleve[indexEleve].SansEDT == false)
            {
                pbCarteArriere.Image = Image.FromFile(@".\FichiersEDT\" + folder + "\\" + listeCleeEleve[indexEleve] + ".png");
            }

            else if (listeEleve[indexEleve].SansEDT == true)
            {
                pbCarteArriere.Image = Image.FromFile(@".\FichiersEDT\Classes\" + listeEleve[indexEleve].ClasseEleve + ".png");
            }

            else
            {
                foreach(Eleve eleve in listeEleve)
                {
                    if (eleve.SansEDT == false)
                    {
                        int i = listeEleve.IndexOf(eleve);
                        pbCarteArriere.Image = Image.FromFile(@".\FichiersEDT\" + folder + "\\" + listeCleeEleve[i] + ".png");
                        break;
                    }
                }
            }
        }

        public void affichePhotoProvisoire()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @".\FichiersPHOTO\");
            string sFilePath = Path.GetFullPath(sFile);

            pbPhoto.Image = new Bitmap(sFilePath + "edition.jpg");
            pbPhoto.Size = new Size(110, 165);
            pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPhoto.Visible = true;
        }

        public void reprendreEDT(Eleve eleve)
        {
            int index = listeEleve.IndexOf(eleve);
            afficheEmploiDuTemps(index);
        }

        public void reprendreCropEDT(Eleve eleve)
        {
            if (eleve.SansEDT == true)
            {
                return;
            }
            // -- Si la largeur a rogner est trop faible, on sort --
            if (cropWidth < 1)
            {
                return;
            }

            /*  
                Rectangle pour stocker l'image rognée avec les points calculés --
                Les dimensions calculées ci dessous utilisent les dimensions 920 x 604 (calcul par proportionnalité)
                qui sont celles des vrai fichier EDT !
                Cela permet d'éviter les problèmes de résolution d'image après le rognage 
            */

            int cropWidthReal = (cropWidth * pbCarteArriere.Image.Width) / 540;
            int cropHeightReal = (cropHeight * pbCarteArriere.Image.Height) / 354;
            int cropXReal = (cropX * pbCarteArriere.Image.Width) / 540;
            int cropYReal = (cropY * pbCarteArriere.Image.Height) / 354;

            Rectangle rect = new Rectangle(cropXReal, cropYReal, cropWidthReal, cropHeightReal);

            int index = listeEleve.IndexOf(eleve);
            string folder = getNiveau(index);

            // -- On stock l'image original dans un bitmap --

            Bitmap OriginalImage = new Bitmap(Bitmap.FromFile(".\\FichiersEDT\\" + folder + "\\" + listeCleeEleve[index] + ".png"));

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

            GC.Collect();
        }

        public string fondCarteSection(Eleve eleve)
        {
            string section = eleve.ClasseEleve.Substring(0,1);
            switch (section)
            {
                case "6":
                    return ".\\FichiersCARTESFACES\\6eme.png";

                case "5":
                    return ".\\FichiersCARTESFACES\\5eme.png";

                case "4":
                    return ".\\FichiersCARTESFACES\\4eme.png";

                case "3":
                    return ".\\FichiersCARTESFACES\\3eme.png";

                default:
                    return ".\\FichiersCARTESFACES\\6eme.png";
            }
        }

        public void fondTextCarteFace(Graphics ObjGraphics, string text, Font font, Eleve eleve, int posX, int posY)
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

        public Image carteFace(Eleve eleve, Font font)
        {
            Image image = Image.FromFile(fondCarteSection(eleve));
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


        // -- Obtention du chemin --
        public string getFilePath(string file)
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, ".\\" + file + "\\");
            string sFilePath = Path.GetFullPath(sFile);

            return sFilePath;
        }

        public void getPhotoEleve(Eleve eleve)
        {
            string nomFichier = "";

            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @".\FichiersPHOTO");
            string sFilePath = Path.GetFullPath(sFile);

            string sFilePathTemp = sFilePath + "\\edition.jpg";
            pbPhoto.Image = Image.FromFile(sFilePathTemp);

            DirectoryInfo directory = new DirectoryInfo(sFilePath);

            foreach (var file in directory.GetFiles())
            {
                int index = file.Name.IndexOf(".");
                if (file.Name.Substring(index, 4) == ".png")
                {
                    nomFichier = eleve.NomEleve + " " + eleve.PrenomEleve + ".png";
                    if (nomFichier == file.Name)
                    {
                        pbPhoto.Image = Image.FromFile(file.FullName);

                        break;
                    }
                }
                else if (file.Name.Substring(index, 4) == ".jpg")
                {
                    nomFichier = eleve.NomEleve + " " + eleve.PrenomEleve + ".jpg";
                    if (nomFichier == file.Name)
                    {
                        pbPhoto.Image = Image.FromFile(file.FullName);

                        break;
                    }
                }
            }
        }

        public void gereCarteFace(Eleve eleve)
        {
            // -- Déclare l'image --
            Image imageFace = null;

            // -- Gestion de la taille de la police --
            if (eleve.NomEleve.Length > 10 || eleve.PrenomEleve.Length > 10)
            {
                Font font = new Font("times new roman", 20, FontStyle.Bold);
                imageFace = carteFace(eleve, font);
            }
            else
            {
                Font font = new Font("times new roman", 25, FontStyle.Bold);
                imageFace = carteFace(eleve, font);
            }

            // -- Sauvegarde l'image --
            imageFace.Save(cheminImpressionFinal + "\\" + eleve.NomEleve + eleve.PrenomEleve + "Carte.png", System.Drawing.Imaging.ImageFormat.Png);

        }

        public void validerImpressionCarte()
        {
            if (listeEleve.Count % 2 == 1)
            {
                Eleve eleve = listeEleve[listeEleve.Count - 1];
                listeEleve.Add(eleve);
            }

            // -- Gestion du nom du fichier en fonction du type d'impression (Par liste, par classe ou par sectin), à completer .. --
            string nomFichier = "";

            if (imprClasse == true)
                nomFichier = listeEleve[0].ClasseEleve;
            else if (imprSection == true)
                nomFichier = listeEleve[0].ClasseEleve.Substring(0, 1) + "eme";
            else if (imprListe == true)
                nomFichier = "Liste";


            // -- Ouverture de l'applucation Word -- 
            Word.Application WordApp = new Word.Application();

            // -- Nouveau Document --
            WordApp.Documents.Add();

            // -- Marge à 0 pour éviter les espaces blancs entre la page et l'image sur le document --
            WordApp.ActiveDocument.PageSetup.TopMargin = 15;    // 15 points = env à 0.5 cm
            WordApp.ActiveDocument.PageSetup.RightMargin = 15;
            WordApp.ActiveDocument.PageSetup.LeftMargin = 15;
            WordApp.ActiveDocument.PageSetup.BottomMargin = 15;

            int posX = pbPhoto.Location.X;
            int posY = pbPhoto.Location.Y;
            int height = pbPhoto.Height;
            int width = pbPhoto.Width;

            int pages = 1;

            int k = 0;

            // -- Boucle pour chaques élèves de la liste à imprimer --
            for (int compt = 1; compt <= listeEleve.Count(); compt += 2)
            {
                bool edtClassique = false;

                // -- Carte Face : 1/2 Eleve --

                gereCarteFace(listeEleve[compt]);

                // -- Carte Face : 2/2 Eleve --

                gereCarteFace(listeEleve[compt - 1]);

                // -- Ajout des deux fichier PNG au nouveau document Word --
                var shapeCarteFace1 = WordApp.ActiveDocument.Shapes.AddPicture(cheminImpressionFinal + "\\" + listeEleve[compt].NomEleve + listeEleve[compt].PrenomEleve + "Carte.png", Type.Missing, Type.Missing, Type.Missing);
                var shapeCarteFace2 = WordApp.ActiveDocument.Shapes.AddPicture(cheminImpressionFinal + "\\" + listeEleve[compt - 1].NomEleve + listeEleve[compt - 1].PrenomEleve + "Carte.png", Type.Missing, Type.Missing, Type.Missing);

                // -- Gestion de la hauteur et de la position des images --
                /*
                 * Le but ici est d'avoir un espace blanc d'environ 1cm au milieu de la page, entre les deux image, pour la découpe.
                 * On définit la position de la deuxieme image par rapport au haut de la page afin d'ancrer celle au bas de la page.
                 * Et enfin on gère la hauteur des deux images pour que celles ci aient les mêmes dimensions.
                */

                shapeCarteFace1.Top = 0;
                shapeCarteFace1.Left = 0;

                shapeCarteFace1.Height = shapeCarteFace1.Height - 20;
                shapeCarteFace2.Top = shapeCarteFace1.Height + 40;
                shapeCarteFace2.Height = shapeCarteFace1.Height;

                // -- Suppression des deux fichiers PNG, plus besoin d'eux maintenant qu'ils sont dans le fichier Word -- 
                File.Delete(cheminImpressionFinal + "\\" + listeEleve[compt].NomEleve + listeEleve[compt].PrenomEleve + "Carte.png");
                File.Delete(cheminImpressionFinal + "\\" + listeEleve[compt - 1].NomEleve + listeEleve[compt - 1].PrenomEleve + "Carte.png");

                //Permet d'éviter la surcharge de mémoire qui s'arrête à 2400 ko, puis l'application s'arrête
                GC.Collect();

                // -- Nouvelle page --
                WordApp.Selection.EndKey();
                WordApp.Selection.InsertNewPage();

                // -- Carte Arrière : 1/2 Eleve --
                if (listeEleve[compt].SansEDT == false)
                {
                    reprendreEDT(listeEleve[compt]);
                    reprendreCropEDT(listeEleve[compt]);
                }
                else
                {
                        pbCarteArriere.Image = Image.FromFile(@".\FichiersEDT\Classes\" + listeEleve[compt].ClasseEleve + ".png");
                    edtClassique = true;
                }

                pbPhoto.Invoke(new MethodInvoker(delegate
                {
                    getPhotoEleve(listeEleve[compt]);

                    if (edtClassique == false)
                    {
                        pbPhoto.Location = new Point(posX, posY);
                        pbPhoto.Height = height;
                        pbPhoto.Width = width;
                    }
                    else
                    {
                        pbPhoto.Location = new Point(230, 145);
                        pbPhoto.Height = 110;
                        pbPhoto.Width = 100;
                    }
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

                    pbCarteArriere.Image.Save(cheminImpressionFinal + "\\" + listeEleve[compt].NomEleve + listeEleve[compt].PrenomEleve + "EDT.png", System.Drawing.Imaging.ImageFormat.Png);

                    System.Threading.Thread.Sleep(1000);

                    // -- Carte Arrière : 2/2 Eleve --
                    if (listeEleve[compt - 1].SansEDT == false)
                    {
                        reprendreEDT(listeEleve[compt - 1]);
                        reprendreCropEDT(listeEleve[compt - 1]);
                    }
                    else
                    {
                        pbCarteArriere.Image = Image.FromFile(@".\FichiersEDT\Classes\" + listeEleve[compt - 1].ClasseEleve + ".png");
                        edtClassique = true;
                    }

                    getPhotoEleve(listeEleve[compt - 1]);

                    if (listeEleve[compt - 1].SansEDT == false)
                    {
                        pbPhoto.Location = new Point(posX, posY);
                        pbPhoto.Height = height;
                        pbPhoto.Width = width;
                    }
                    else
                    {
                        pbPhoto.Location = new Point(230, 145);
                        pbPhoto.Height = 110;
                        pbPhoto.Width = 100;
                    }

                    // -- Calcul par proportionnalité de la position et des dimensions de la photo sur le cadre de l'application par rapport a l'image réelle --
                    // -- Cela permet de répercuter les déplacements effectués par l'utilisateur sur l'image originelle afin de pouvoir réutiliser celle ci --
                    // -- Et ainsi ne pas perdre en qualité de l'image --
                    int realLocX2 = (pbPhoto.Location.X * pbCarteArriere.Image.Width) / pbCarteArriere.Width;
                    int realLocY2 = (pbPhoto.Location.Y * pbCarteArriere.Image.Height) / pbCarteArriere.Height;
                    int realWidth2 = (pbPhoto.Width * pbCarteArriere.Image.Width) / pbCarteArriere.Width;
                    int realHeight2 = (pbPhoto.Height * pbCarteArriere.Image.Height) / pbCarteArriere.Height;

                    // -- Superposition des deux image dans un objet "Graphics" --
                    Graphics ObjGraphics2 = Graphics.FromImage(pbCarteArriere.Image);
                    ObjGraphics2.DrawImage(pbPhoto.Image, realLocX2, realLocY2, realWidth2, realHeight2);

                    pbCarteArriere.Image.Save(cheminImpressionFinal + "\\" + listeEleve[compt - 1].NomEleve + listeEleve[compt - 1].PrenomEleve + "EDT.png", System.Drawing.Imaging.ImageFormat.Png);
                }));

                // -- Ajout des deux fichier PNG au nouveau document Word --
                var shapeCarteArriere1 = WordApp.ActiveDocument.Shapes.AddPicture(cheminImpressionFinal + "\\" + listeEleve[compt].NomEleve + listeEleve[compt].PrenomEleve + "EDT.png", Type.Missing, Type.Missing, Type.Missing);
                var shapeCarteArriere2 = WordApp.ActiveDocument.Shapes.AddPicture(cheminImpressionFinal + "\\" + listeEleve[compt - 1].NomEleve + listeEleve[compt - 1].PrenomEleve + "EDT.png", Type.Missing, Type.Missing, Type.Missing);

                // -- Gestion de la hauteur et de la position des images --

                /*
                 * Le but ici est d'avoir un espace blanc d'environ 1cm au milieu de la page, entre les deux image, pour la découpe.
                 * On définit la position de la deuxieme image par rapport au haut de la page afin d'ancrer celle au bas de la page.
                 * Et enfin on gère la hauteur des deux images pour que celles ci aient les mêmes dimensions.
                */

                shapeCarteArriere1.Top = 0;
                shapeCarteArriere1.Left = 0;
                shapeCarteArriere1.Height = shapeCarteFace1.Height;

                shapeCarteArriere2.Top = shapeCarteArriere1.Height + 40;
                shapeCarteArriere2.Height = shapeCarteArriere1.Height;

                // -- Suppression des deux fichiers PNG, plus besoin d'eux maintenant qu'ils sont dans le fichier Word -- 
                File.Delete(cheminImpressionFinal + "\\" + listeEleve[compt].NomEleve + listeEleve[compt].PrenomEleve + "EDT.png");
                File.Delete(cheminImpressionFinal + "\\" + listeEleve[compt - 1].NomEleve + listeEleve[compt - 1].PrenomEleve + "EDT.png");

                //Permet d'éviter la surcharge de mémoire qui s'arrête à 2400 ko, puis l'application s'arrête
                GC.Collect();

                // -- Nouvelle page --

                WordApp.Selection.EndKey();
                WordApp.Selection.InsertNewPage();

                if (compt > k + 50)
                {
                    // -- Sauvegarde du document --
                    WordApp.ActiveDocument.SaveAs(cheminImpressionFinal + "\\" + nomFichier + "Imprimer Part " + pages + ".doc", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    // -- Ferme le document --
                    WordApp.ActiveDocument.Close();

                    //Permet d'éviter la surcharge de mémoire qui s'arrête à 2400 ko, puis l'application s'arrête
                    GC.Collect();

                    // -- Nouveau Document --
                    WordApp.Documents.Add();

                    // -- Marge à 0 pour éviter les espaces blancs entre la page et l'image sur le document --
                    WordApp.ActiveDocument.PageSetup.TopMargin = 15;    // 15 points = env à 0.5 cm
                    WordApp.ActiveDocument.PageSetup.RightMargin = 15;
                    WordApp.ActiveDocument.PageSetup.LeftMargin = 15;
                    WordApp.ActiveDocument.PageSetup.BottomMargin = 15;

                    pages++;
                    k += 50;

                }

            }

            // -- j = 1 signifie qu'on a qu'un seule document -- 
            if (pages == 1)
            {
                WordApp.ActiveDocument.SaveAs(cheminImpressionFinal + "\\" + nomFichier + "Imprimer.doc", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            else
            {
                WordApp.ActiveDocument.SaveAs(cheminImpressionFinal + "\\" + nomFichier + "Imprimer Part " + pages + ".doc", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }

            // -- Ferme le document --
            WordApp.ActiveDocument.Close();

            // -- Quitte l'application -- 
            WordApp.Quit();

            // -- TaskKill --
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(WordApp);

            //Permet d'éviter la surcharge de mémoire qui s'arrête à 2400 ko, puis l'application s'arrête
            GC.Collect();

            // -- Message qui indique que nous sommes arrivé au bout --
            MessageBox.Show(listeEleve.Count() + " élèves ont été imprimés.");
        }

        // ### Commandes ###

        private void pbPhoto_MouseMove(object sender, MouseEventArgs e)
        {
            // -- Lorsque l'utilisateur clique sur la photo de l'élève --
            if (drag == true)
            {
                // -- La position de la photo change --
                pbPhoto.Left = e.X + pbPhoto.Left - posX;
                pbPhoto.Top = e.Y + pbPhoto.Top - posY;
            }
        }

        private void pbPhoto_MouseDown(object sender, MouseEventArgs e)
        {
            // -- Lorsque l'utilisateur clic, la position initiale est sauvegardée, drag passe a true
            if (e.Button == MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
                drag = true;
            }
            // -- Actualisation pour voir le déplacement en temps réel --
            this.Refresh();
        }

        private void pbPhoto_MouseUp(object sender, MouseEventArgs e)
        {
            // -- Le drag est fini lorsque le clic est relevé  --
            drag = false;
        }

        private void tkbHauteurPhoto_Scroll(object sender, EventArgs e)
        {
            if (pbPhoto != null)
            {
                // -- La hauteur en pixel de la photo change et prend la valeur de la trackbar
                pbPhoto.Height = tkbHauteurPhoto.Value;
            }
        }

        private void tkbLargeurPhoto_Scroll(object sender, EventArgs e)
        {
            if (pbPhoto != null)
            {
                // -- La largeur en pixel de la photo change et prend la valeur de la trackbar
                pbPhoto.Width = tkbLargeurPhoto.Value;
            }
        }

        // #### Rognage de l'emploi du temps ####
        private void btnSelect_Click(object sender, EventArgs e)
        {
            // -- Curseur en croix pour symboliser le mode selection
            Cursor = Cursors.Cross;

            // -- On est dans le mode selection
            selectionClick = true;

            // -- On peut cliquer sur rogner
            btnCrop.Enabled = true;
        }
        private void btnCrop_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            selectionClick = false;

            foreach(Eleve eleve in listeEleve)
            {
                if (eleve.SansEDT == false)
                {
                    reprendreCropEDT(eleve);
                    break;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // -- Le curseur revient à la normal --
            Cursor = Cursors.Default;

            // -- On est plus dans la selection --
            selectionClick = false;

            // -- On remet les paramètres et l'image de base --
            pbCarteArriere.Width = 540;
            pbCarteArriere.Height = 354;
            afficheEmploiDuTemps(0);
            pbCarteArriere.Refresh();
            btnCrop.Enabled = false;
        }

        private void pbCarteArriere_MouseDown(object sender, MouseEventArgs e)
        {
            // -- Si le bouton selectionné est cliqué --
            if (selectionClick == true)
            {
                // -- Si il y a clic gauche --
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    // -- On prend les coordonnées de départ --
                    cropX = e.X;
                    cropY = e.Y;
                    cropPen = new Pen(Color.Black, 1);
                    cropPen.DashStyle = DashStyle.DashDotDot;
                }
                // -- Refresh constant pour avoir un apperçu pendant la selection --
                pbCarteArriere.Refresh();
            }
        }

        private void pbCarteArriere_MouseMove(object sender, MouseEventArgs e)
        {
            // -- Si le bouton selection est cliqué --
            if (selectionClick == true)
            {
                // -- Si pas d'image, on sort --
                if (pbCarteArriere.Image == null)
                    return;

                // -- Glissement à la fin du premier clic gauche --
                if (e.Button == MouseButtons.Left)
                {
                    // -- On prend les dimensions a la fin du déplacement de la souris
                    pbCarteArriere.Refresh();
                    cropWidth = e.X - cropX;
                    cropHeight = e.Y - cropY;
                    pbCarteArriere.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
                }
            }
        }

        private void btnValiderImpr_Click(object sender, EventArgs e)
        {
            this.Enabled = false; // Empêche les conflits que l'utilisateur pourrait potentiellement créer

            FolderBrowserDialog diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                cheminImpressionFinal = diag.SelectedPath;

                label1.Show(); // montre le label en relation avec la barre de progrès
                progressBar1.Show(); // montre la barre de progrès
                backgroundWorker1.RunWorkerAsync(); // utilisation de la méthode validerImpressionCarte() en arrière plan afin
                                                    // de garder l'interface en main thread (cela permet à ce que l'animation de la barre continue)
            }
            else
            {
                MessageBox.Show("Merci de choisir un dossier de destination pour les fichiers générés par l'application");
                this.Enabled = true;
                return;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //événement de backgroundWorker, DoWork permet de lui indiquer la tâche qu'il doit effectuer lorsqu'on lui fait utiliser la méthode
            //RunWorkerAsync();
            validerImpressionCarte();  // ce qu'on veut que le programme fasse en cliquant sur le bouton associe, ici btnValiderImpr_Click
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //événement de backgroundWorker, RunWorkerCompleted permet d'indiquer à ce qu'il doit faire une fois que la méthode qu'il utilse
            //se termine, ici une fois que validerImpressionCarte() se termine on lui indique de cacher le label et la barre de progression
            //on donne l'accès de nouveau à l'utilisateur l'interface de l'application, il n'y a plus de risque à ce qu'il puisse
            //créer un conflit
            label1.Hide();
            progressBar1.Hide();
            this.Enabled = true;

            //ce n'est pas génant d'avoir la bar de progrès et le label toujours actifs...
        }

        private void frmMultiplesCartesEdition_Load(object sender, EventArgs e)
        {

        }
    }
}
