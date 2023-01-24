using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using CarteAcces;

namespace CartesAcces
{
    public static class Edition
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
        
        // -- Dessine le rectangle de couleur derrière le text pour une meilleurs visibilité de celui ci --
        public static void fondTextCarteFace(Graphics ObjGraphics, string text, Font font, int posX, int posY,
            ComboBox cbbSection)
        {
            Brush brushJaune = new SolidBrush(Color.Yellow);
            Brush brushVert = new SolidBrush(Color.LightGreen);
            Brush brushRouge = new SolidBrush(Color.Red);
            Brush brushBleu = new SolidBrush(Color.LightBlue);
            var largeur = Convert.ToInt32(ObjGraphics.MeasureString(text, font).Width);
            var hauteur = Convert.ToInt32(ObjGraphics.MeasureString(text, font).Height);
            var rectangle = new Rectangle(posX, posY, largeur, hauteur);

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
        public static void dessineTextCarteFace(Font font, int posX, int posY, string text, PictureBox pbCarteFace,
            ComboBox cbbSection)
        {
            //Pinceaux et graphique
            var ObjGraphics = Graphics.FromImage(pbCarteFace.Image);
            Brush brushNoir = new SolidBrush(Color.Black);

            //Dessine et rempli le fond pour l'écriture
            fondTextCarteFace(ObjGraphics, text, font, posX, posY, cbbSection);

            //Dessine la saisie en textbox
            ObjGraphics.DrawString(text, font, brushNoir, posX,
                posY); // Dessine le texte sur l'image à la position X et Y + couleur
            ObjGraphics.Dispose(); // Libère les ressources
        }

        // -- Change le fond de la carte en fonction de la section choisie
        public static void fondCarteSection(PictureBox pbCarteFace, ComboBox cbbSection)
        {
            pbCarteFace.Image = Image.FromFile("./data/FichierCartesFace/" + cbbSection.Text + ".png");
            var date = DateTime.Today.ToShortDateString();
            var font = new Font("times new roman", 45, FontStyle.Bold);
            dessineTextCarteFace(font, 50, 70, "Carte Provisoire", pbCarteFace, cbbSection);
            var font2 = new Font("times new roman", 15, FontStyle.Bold);
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
            }
        }

        public static void reprendPrenom(string txtPrenom, PictureBox pbCarteFace,
            ComboBox cbbSection)
        {
            if (txtPrenom != "")
            {
                if (txtPrenom.Length < 15)
                {
                    var font = new Font("times new roman", 28, FontStyle.Bold);
                    dessineTextCarteFace(font, 350, 1075, txtPrenom, pbCarteFace, cbbSection);
                    pbCarteFace.Refresh();
                }
                else
                {
                    fondCarteSection(pbCarteFace, cbbSection);
                    var font = new Font("times new roman", 25, FontStyle.Bold);
                    dessineTextCarteFace(font, 350, 1075, txtPrenom, pbCarteFace, cbbSection);
                    pbCarteFace.Refresh();
                }
            }
        }

        public static void reprendNom(string txtNom, PictureBox pbCarteFace, ComboBox cbbSection)
        {
            if (txtNom != "")
            {
                if (txtNom.Length < 15)
                {
                    var font = new Font("times new roman", 28, FontStyle.Bold);
                    dessineTextCarteFace(font, 250, 960, txtNom, pbCarteFace, cbbSection);
                    pbCarteFace.Refresh();
                }
                else
                {
                    fondCarteSection(pbCarteFace, cbbSection);
                    var font = new Font("times new roman", 25, FontStyle.Bold);
                    dessineTextCarteFace(font, 250, 960, txtNom, pbCarteFace, cbbSection);
                    pbCarteFace.Refresh();
                }
            }
        }

        public static void checkMef(RadioButton rdbUlis, RadioButton rdbUPE2A, RadioButton rdbClRelais,
            PictureBox pbCarteFace, ComboBox cbbSection, Button btnEdtPerso, TextBox txtNom, TextBox txtPrenom)
        {
            if (rdbUlis.Checked)
            {
                var font = new Font("times new roman", 30, FontStyle.Bold);
                dessineTextCarteFace(font, 50, 230, "ULIS ", pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
                btnEdtPerso.Enabled = true;
            }
            else if (rdbUPE2A.Checked)
            {
                var font = new Font("times new roman", 30, FontStyle.Bold);
                dessineTextCarteFace(font, 50, 230, "UPE2A", pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
                btnEdtPerso.Enabled = true;
            }
            else if (rdbClRelais.Checked)
            {
                var font = new Font("times new roman", 30, FontStyle.Bold);
                dessineTextCarteFace(font, 50, 230, "CL-Relais", pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
                btnEdtPerso.Enabled = true;
            }
            else
            {
                fondCarteSection(pbCarteFace, cbbSection);
                reprendNom(txtNom.Text, pbCarteFace, cbbSection);
                reprendPrenom(txtPrenom.Text, pbCarteFace, cbbSection);
                btnEdtPerso.Enabled = false;
            }
        }
        
        public static void affichePhotoProvisoire(string path, PictureBox pbPhoto)
        {
            pbPhoto.Image = new Bitmap(path);
            pbPhoto.Size = new Size(110, 165);
            pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPhoto.Visible = true;
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

        public static void fondTextCarteFace(Graphics ObjGraphics, string text, Font font, Eleve eleve, int posX,
            int posY)
        {
            Brush brushJaune = new SolidBrush(Color.Yellow);
            Brush brushVert = new SolidBrush(Color.LightGreen);
            Brush brushRouge = new SolidBrush(Color.Red);
            Brush brushBleu = new SolidBrush(Color.LightBlue);
            var largeur = Convert.ToInt32(ObjGraphics.MeasureString(text, font).Width);
            var hauteur = Convert.ToInt32(ObjGraphics.MeasureString(text, font).Height);
            var rectangle = new Rectangle(posX, posY, largeur, hauteur);

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
            var image = Image.FromFile("./data/FichierCartesFace/" + eleve.ClasseEleve.Substring(0, 1) + "eme.png");
            var ObjGraphics = Graphics.FromImage(image);
            Brush brushNoir = new SolidBrush(Color.Black);

            var font2 = new Font("times new roman", 30, FontStyle.Bold);
            var font3 = new Font("times new roman", 15, FontStyle.Bold);

            var date = DateTime.Today.ToShortDateString();

            //Dessine et rempli le fond pour l'écriture
            fondTextCarteFace(ObjGraphics, eleve.NomEleve, font, eleve, 250, 960);
            fondTextCarteFace(ObjGraphics, eleve.PrenomEleve, font, eleve, 350, 1075);
            fondTextCarteFace(ObjGraphics, eleve.MefEleve, font2, eleve, 50, 70);
            fondTextCarteFace(ObjGraphics, "Date de création: " + date, font3, eleve, 870, 875);

            //Dessine la saisie en textbox
            ObjGraphics.DrawString(eleve.NomEleve, font, brushNoir, 250,
                960); // Dessine le texte sur l'image à la position X et Y + couleur
            ObjGraphics.DrawString(eleve.PrenomEleve, font, brushNoir, 350, 1075);
            ObjGraphics.DrawString(eleve.MefEleve, font2, brushNoir, 50, 70);
            ObjGraphics.DrawString("Date de création: " + date, font3, brushNoir, 870, 875);
            ObjGraphics.Dispose(); // Libère les ressources

            return image;
        }

        public static void carteFace(Eleve eleve, string path)
        {
            // -- Déclare l'image --
            Image imageFace = null;

            // -- Gestion de la taille de la police --
            if (eleve.NomEleve.Length > 10 || eleve.PrenomEleve.Length > 10)
            {
                var font = new Font("times new roman", 20, FontStyle.Bold);
                imageFace = imageCarteFace(eleve, font);
            }
            else
            {
                var font = new Font("times new roman", 25, FontStyle.Bold);
                imageFace = imageCarteFace(eleve, font);
            }

            // -- Sauvegarde l'image --
            imageFace.Save(path + "/" + eleve.NomEleve + eleve.PrenomEleve + "Carte.png", ImageFormat.Png);
        }

        public static void carteArriere(Eleve eleve, PictureBox pbCarteArriere)
        {
            if (eleve.SansEDT == false)
            {
                var pathEdt = "./data/image/" + eleve.ClasseEleve.Substring(0, 1) + "eme/" +
                              Eleve.creeCleeEleve(eleve) + ".jpg";
                pbCarteArriere.Image = Image.FromFile(pathEdt);
                Edt.cropEdt(pbCarteArriere, pathEdt);
            }
            else
            {
                pbCarteArriere.Image = Image.FromFile("./data/FichierEdtClasse/" + eleve.ClasseEleve + ".png");
            }
        }

        public static void importEleves(string path)
        {
            var sourcePath = path;
            var destinationPath = Chemin.pathListeEleve;
            try
            {
                if (File.Exists(destinationPath)) File.Delete(destinationPath);

                Directory.CreateDirectory(Chemin.pathFolderListeEleve);

                File.Copy(sourcePath, destinationPath);
                ReadCSV.setLesEleves(destinationPath);
                Eleve.setLesClasses();

                MessageBox.Show("Import Réussi");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        // -- Importation des photo des élèves --
        public static void importPhoto(string path)
        {
            var sourcePath = path;
            var destinationPath = Chemin.pathPhotoEleve;

            try
            {
                Directory.CreateDirectory(destinationPath);

                var directory = new DirectoryInfo(sourcePath);

                foreach (var file in directory.GetFiles())
                {
                    var img = Image.FromFile(file.FullName);
                    var nom = file.Name;

                    img.Save(destinationPath + nom, ImageFormat.Png);
                }

                MessageBox.Show("Import réussie !");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public static void easterEgg()
        {
            var gitPoule1 = "⠀⠀⠀⠀⠀⣀⡀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀ ⠀⠀⠀⠀ ⢀⣤⣤ ⣤⣄⠀⠀ ⠀⠀⠀⠀⠀";
            var gitPoule2 = "⠀⠀⣴⠾⣿⣿⣷⣀⠀  ⠀⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀ ⠀⠀⠀⣴ ⡏⠙⣿ ⡥⣿⣻⣆ ⣀⠀⠀⠀⠀";
            var gitPoule3 = "⠀⠸⣯⠞⣽⠸⣄⠀⠉  ⢤⡀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀ ⠀⠀⠸⢸ ⠀⠀⠹ ⠇⠟⡽⠁ ⣸⢤⡄⠀⠀";
            var gitPoule4 = "⠀⣾⣿⢦⡈⢀⣿⠀⠀  ⠀⠙⠷⣄⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀ ⠀⠀⣇⣈ ⠄⠀⠀ ⢀⣰⠃⡰ ⠃⣰⣻⡆⠀";
            var gitPoule5 = "⠈⠁⢸⠀⢻⡞⠁⠀⠀  ⠀⢲⣠⣜⢳⣄⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⣠ ⠴⠚⠉⠀ ⠀⠀⠘ ⢹⣯⠀⠀ ⣠⣿⠏⣹⣄";
            var gitPoule6 = "⠀⠀⠈⠓⣻⠁⢀⠀⠀  ⠀⢠⠙⢻⣿⡿⢦⡀⠀  ⠀⠀⠀⢀⡴⠞⠁ ⠀⠀⠀⠀ ⠀⠀⠀ ⠀⠘⠦⣬ ⡏⢁⣴⣍⡟";
            var gitPoule7 = "⠀⠀⠀⠀⡟⠀⣼⡄⣷  ⣦⠀⠳⠀⠀⡀⠤⠷⠖  ⠒⠒⣻⡋⠀⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀ ⠀⠀⠀⠘ ⠛⠿⣿⡛⣦";
            var gitPoule8 = "⠀⠀⠀⢸⡇⠀⢹⣷⠙  ⣿⠦⠒⠒⠉⠀⠀⠠⠴  ⠒⠀⠀⠉⠉⠒⠢ ⠤⣀⡀⠀ ⢀⣼⡄ ⠀⠀⣲⠀ ⠀⠀⣠⠟⠃";
            var gitPoule9 = "⠀⠀⠀⢸⡇⠦⠞⠋⠀  ⠀⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀ ⠀⡀⠈⠙ ⠲⠤⡅ ⠠⠾⠋⠀ ⠀⠀⣸⠀⠀";
            var gitPoule10 = "⠀⠀⠀⠸⣇⠀⠀⠀  ⠀⠀⠀⠐⠦⣄⠀⠀⠀  ⠀⠀⠀⠀⠀⢀⡄ ⠀⢸⢁⣀ ⣀⣀⣠ ⣧⠀⠀⣠ ⣐⠆⣠⠃⠀⠀";
            var gitPoule11 = "⠀⠀⠀⠀⢻⡆⠀⠀  ⠀⠀⠀⠀⠀⠈⠿⢤⣄  ⠀⠀⠀⠀⢀⠞⠀ ⠀⡞⠀⠤ ⠤⠖⣲ ⡞⠁⠀⠐ ⢃⣤⠋⠀⠀⠀";
            var gitPoule12 = "⠀⠀⠀⠀⠀⢻⡄⠀  ⠀⠀⠀⠀⠀⠀⠀⠀⠺  ⣷⣀⡠⠼⣧⠃⠐ ⠊⣠⠴⠖ ⠛⠉⠀ ⠉⠻⢷⣶ ⠞⠁⠀⠀⠀⠀";
            var gitPoule13 = "⠀⠀⠀⠀⠀⠀⠹⣦  ⠀⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠘⠛⢦⣅⡤⠖ ⠉⠀⠀⠀ ⠀⠀⠀ ⣀⣠⣼⡇ ⠀⠀⠀⠀⠀⠀";
            var gitPoule14 = "⠀⠀⠀⠀⠀⠀⠀⠈  ⢦⣀⠀⠀⠀⠀⠀⠀⠀  ⣀⢀⣀⠈⠁⣀⠀ ⠀⠀⠀⠀ ⠀⡀⢀ ⠀⢠⡿⠁ ⠀⠀⠀⠀⠀⠀";
            var gitPoule15 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠙⢷⡄⠀⠀⠤⠶⠖  ⠀⠀⠀⠀⠀⠘⡄ ⠀⠀⠀⠀ ⠀⠩⠓ ⣶⠟⠀⠀ ⠀⠀⠀⠀⠀⠀";
            var gitPoule16 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠈⢻⣆⠀⠀⠀⠀  ⠀⠀⠀⠀⢀⣿⣇ ⣶⣦⣀⡄ ⠀⣤⡟ ⠉⠀⠀⠀ ⠀⠀⠀⠀⠀⠀";
            var gitPoule17 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠻⣆⠀⠀⠀  ⠀⠀⠀⠀⠀⠛⣯ ⣿⣿⣿⡿ ⠟⠉⠀ ⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⠀";
            var gitPoule18 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠙⢧⡀⠀  ⠀⠀⠀⢀⣴⣟⣉ ⠿⠋⠁⠀ ⠀⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⠀";
            var gitPoule19 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀⠈⢹  ⠛⡿⠚⠉⠀⠹⣿ ⠀⠀⠀⠀ ⠀⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⠀";
            var gitPoule20 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀⠀⣬  ⡞⠁⠀⠀⠀⠀⢻ ⣇⠀⣠⡴ ⠆⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⠀";
            var gitPoule21 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⢀⣀⣀⣀⣀⣴⢿  ⡁⠀⠀⢠⣤⠤⠼ ⣯⡿⠋⠀ ⠀⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⠀";
            var gitPoule22 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⣿⣟⣻⡿⠿⠓⠒  ⠚⠓⠀⢻⡗⠒⠛ ⠉⠀⠀⠀ ⠀⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⠀";
            var gitPoule23 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠉⠉⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";

            var ListePoule = new List<string>();
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
        }
    }
}