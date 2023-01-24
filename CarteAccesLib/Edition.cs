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
            selectionClique = false; // -> Est ce que le bouton "Selectionner" a été cliqué ? Si oui passe à true
        
        public static int rognageX; // -> Abscisse de départ du rognage
        public static int rognageY; // -> Ordonnée de départ du rognage
        public static int rognageLargeur; // -> Largeur du rognage
        public static int rogagneHauteur; // -> Hauteur du rognage
        public static Pen rognagePen; // -> Stylo qui dessine le rectangle correspondant au rognage
        
        // ** VARIABLES  : Déplacement de la photo
        public static bool
            drag = false; // -> Est ce que l'utilisateur a cliqué sur la photo ? (clique maintenue : drag passera a true)
        
        public static int
            posX; // -> Abscisse initiale, sauvegardée quand l'utilisateur commence le déplacement (clic maintenu sur la photo)
        
        public static int
            posY; // -> Ordonnée initialie, sauvegardée quand l'utilisateur commence le déplacement (clic maintenu sur la photo)
        
        // ** VARIABLES : Chemin de l'image **
        public static string cheminFichier;
        
        public static string cheminImpressionFinal;
        
        // -- Dessine le rectangle de couleur derrière le texte pour une meilleurs visibilité de celui ci --
        public static void fondTexteCarteFace(Graphics objGraphique, string texte, Font police, int posX, int posY,
            ComboBox cbbSection)
        {
            Brush pinceauJaune = new SolidBrush(Color.Yellow);
            Brush pinceauVert = new SolidBrush(Color.LightGreen);
            Brush pinceauRouge = new SolidBrush(Color.Red);
            Brush pinceauBleu = new SolidBrush(Color.LightBlue);
            var largeur = Convert.ToInt32(objGraphique.MeasureString(texte, police).Width);
            var hauteur = Convert.ToInt32(objGraphique.MeasureString(texte, police).Height);
            var rectangle = new Rectangle(posX, posY, largeur, hauteur);

            // -- Couleur du rectangle en fonction de la section (donc de la couleur de la carte) --
            switch (cbbSection.Text)
            {
                case "6eme":
                    objGraphique.FillRectangle(pinceauJaune, rectangle);
                    objGraphique.DrawRectangle(new Pen(pinceauJaune), rectangle);
                    break;
                case "5eme":
                    objGraphique.FillRectangle(pinceauVert, rectangle);
                    objGraphique.DrawRectangle(new Pen(pinceauVert), rectangle);
                    break;
                case "4eme":
                    objGraphique.FillRectangle(pinceauRouge, rectangle);
                    objGraphique.DrawRectangle(new Pen(pinceauRouge), rectangle);
                    break;
                case "3eme":
                    objGraphique.FillRectangle(pinceauBleu, rectangle);
                    objGraphique.DrawRectangle(new Pen(pinceauBleu), rectangle);
                    break;
            }
        }

        // -- Dessine le texte des cases sur la carte --
        public static void dessineTexteCarteFace(Font police, int posX, int posY, string text, PictureBox pbCarteFace,
            ComboBox cbbSection)
        {
            //Pinceaux et graphique
            var objetGraphique = Graphics.FromImage(pbCarteFace.Image);
            Brush pinceauNoir = new SolidBrush(Color.Black);

            //Dessine et rempli le fond pour l'écriture
            fondTexteCarteFace(objetGraphique, text, police, posX, posY, cbbSection);

            //Dessine la saisie en textbox
            objetGraphique.DrawString(text, police, pinceauNoir, posX,
                posY); // Dessine le texte sur l'image à la position X et Y + couleur
            objetGraphique.Dispose(); // Libère les ressources
        }

        // -- Change le fond de la carte en fonction de la section choisie
        public static void fondCarteNiveau(PictureBox pbCarteFace, ComboBox cbbSection)
        {
            pbCarteFace.Image = Image.FromFile("./data/FichierCartesFace/" + cbbSection.Text + ".png");
            var date = DateTime.Today.ToShortDateString();
            var police = new Font("times new roman", 45, FontStyle.Bold);
            dessineTexteCarteFace(police, 50, 70, "Carte Provisoire", pbCarteFace, cbbSection);
            var police2 = new Font("times new roman", 15, FontStyle.Bold);
            dessineTexteCarteFace(police2, 870, 875, "Date de création : " + date, pbCarteFace, cbbSection);
            pbCarteFace.Refresh();
        }

        // -- N'affiche que les classes correspondantes a la section selectionnées --
        public static void classePourNiveau(ComboBox cbbSection, ComboBox cbbClasse)
        {
            switch (cbbSection.Text)
            {
                case "6eme":
                    cbbClasse.DataSource = Globale._classes6eme;
                    break;

                case "5eme":
                    cbbClasse.DataSource = Globale._classes5eme;
                    break;

                case "4eme":
                    cbbClasse.DataSource = Globale._classes4eme;
                    break;

                case "3eme":
                    cbbClasse.DataSource = Globale._classes3eme;
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
                    dessineTexteCarteFace(font, 350, 1075, txtPrenom, pbCarteFace, cbbSection);
                    pbCarteFace.Refresh();
                }
                else
                {
                    fondCarteNiveau(pbCarteFace, cbbSection);
                    var font = new Font("times new roman", 25, FontStyle.Bold);
                    dessineTexteCarteFace(font, 350, 1075, txtPrenom, pbCarteFace, cbbSection);
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
                    dessineTexteCarteFace(font, 250, 960, txtNom, pbCarteFace, cbbSection);
                    pbCarteFace.Refresh();
                }
                else
                {
                    fondCarteNiveau(pbCarteFace, cbbSection);
                    var font = new Font("times new roman", 25, FontStyle.Bold);
                    dessineTexteCarteFace(font, 250, 960, txtNom, pbCarteFace, cbbSection);
                    pbCarteFace.Refresh();
                }
            }
        }

        public static void checkMef(RadioButton rdbUlis, RadioButton rdbUPE2A, RadioButton rdbClRelais,
            PictureBox pbCarteFace, ComboBox cbbSection, Button btnEdtPerso, TextBox txtNom, TextBox txtPrenom)
        {
            if (rdbUlis.Checked)
            {
                var police = new Font("times new roman", 30, FontStyle.Bold);
                dessineTexteCarteFace(police, 50, 230, "ULIS ", pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
                btnEdtPerso.Enabled = true;
            }
            else if (rdbUPE2A.Checked)
            {
                var police = new Font("times new roman", 30, FontStyle.Bold);
                dessineTexteCarteFace(police, 50, 230, "UPE2A", pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
                btnEdtPerso.Enabled = true;
            }
            else if (rdbClRelais.Checked)
            {
                var police = new Font("times new roman", 30, FontStyle.Bold);
                dessineTexteCarteFace(police, 50, 230, "CL-Relais", pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
                btnEdtPerso.Enabled = true;
            }
            else
            {
                fondCarteNiveau(pbCarteFace, cbbSection);
                reprendNom(txtNom.Text, pbCarteFace, cbbSection);
                reprendPrenom(txtPrenom.Text, pbCarteFace, cbbSection);
                btnEdtPerso.Enabled = false;
            }
        }
        
        public static void affichePhotoProvisoire(string chemin, PictureBox pbPhoto)
        {
            pbPhoto.Image = new Bitmap(chemin);
            pbPhoto.Size = new Size(110, 165);
            pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPhoto.Visible = true;
        }

        public static void chercheEdtPerso(List<Eleve> listeEleve, PictureBox pbCarteArriere)
        {
            foreach (var eleve in listeEleve)
                try
                {
                    var dossier = "./data/image/" + eleve.ClasseEleve.Substring(0, 1) + "eme/";
                    pbCarteArriere.Image = Image.FromFile(dossier + Eleve.creeCleeEleve(eleve) + ".jpg");
                    Chemin.pathEdt = dossier + Eleve.creeCleeEleve(eleve) + ".jpg";
                    break;
                }
                catch
                {
                    // Next ..
                }
        }

        public static void fondTexteCarteFace(Graphics objGraphique, string texte, Font police, Eleve eleve, int posX,
            int posY)
        {
            Brush brushJaune = new SolidBrush(Color.Yellow);
            Brush brushVert = new SolidBrush(Color.LightGreen);
            Brush brushRouge = new SolidBrush(Color.Red);
            Brush brushBleu = new SolidBrush(Color.LightBlue);
            var largeur = Convert.ToInt32(objGraphique.MeasureString(texte, police).Width);
            var hauteur = Convert.ToInt32(objGraphique.MeasureString(texte, police).Height);
            var rectangle = new Rectangle(posX, posY, largeur, hauteur);

            // -- Couleur du rectangle en fonction de la section (donc de la couleur de la carte) --
            switch (eleve.ClasseEleve.Substring(0, 1))
            {
                case "6":
                    objGraphique.FillRectangle(brushJaune, rectangle);
                    objGraphique.DrawRectangle(new Pen(brushJaune), rectangle);
                    break;
                case "5":
                    objGraphique.FillRectangle(brushVert, rectangle);
                    objGraphique.DrawRectangle(new Pen(brushVert), rectangle);
                    break;
                case "4":
                    objGraphique.FillRectangle(brushRouge, rectangle);
                    objGraphique.DrawRectangle(new Pen(brushRouge), rectangle);
                    break;
                case "3":
                    objGraphique.FillRectangle(brushBleu, rectangle);
                    objGraphique.DrawRectangle(new Pen(brushBleu), rectangle);
                    break;
                default:
                    objGraphique.FillRectangle(brushJaune, rectangle);
                    objGraphique.DrawRectangle(new Pen(brushJaune), rectangle);
                    break;
            }
        }

        public static Image imageCarteFace(Eleve eleve, Font police)
        {
            var image = Image.FromFile("./data/FichierCartesFace/" + eleve.ClasseEleve.Substring(0, 1) + "eme.png");
            var objGraphique = Graphics.FromImage(image);
            Brush pinceauNoir = new SolidBrush(Color.Black);

            var police2 = new Font("times new roman", 30, FontStyle.Bold);
            var police3 = new Font("times new roman", 15, FontStyle.Bold);

            var date = DateTime.Today.ToShortDateString();

            //Dessine et rempli le fond pour l'écriture
            fondTexteCarteFace(objGraphique, eleve.NomEleve, police, eleve, 250, 960);
            fondTexteCarteFace(objGraphique, eleve.PrenomEleve, police, eleve, 350, 1075);
            fondTexteCarteFace(objGraphique, eleve.MefEleve, police2, eleve, 50, 70);
            fondTexteCarteFace(objGraphique, "Date de création: " + date, police3, eleve, 870, 875);

            //Dessine la saisie en textbox
            objGraphique.DrawString(eleve.NomEleve, police, pinceauNoir, 250,
                960); // Dessine le texte sur l'image à la position X et Y + couleur
            objGraphique.DrawString(eleve.PrenomEleve, police, pinceauNoir, 350, 1075);
            objGraphique.DrawString(eleve.MefEleve, police2, pinceauNoir, 50, 70);
            objGraphique.DrawString("Date de création: " + date, police3, pinceauNoir, 870, 875);
            objGraphique.Dispose(); // Libère les ressources

            return image;
        }

        public static void carteFace(Eleve eleve, string chemin)
        {
            // -- Déclare l'image --
            Image imageFace = null;

            // -- Gestion de la taille de la police --
            if (eleve.NomEleve.Length > 10 || eleve.PrenomEleve.Length > 10)
            {
                var police = new Font("times new roman", 20, FontStyle.Bold);
                imageFace = imageCarteFace(eleve, police);
            }
            else
            {
                var police = new Font("times new roman", 25, FontStyle.Bold);
                imageFace = imageCarteFace(eleve, police);
            }

            // -- Sauvegarde l'image --
            imageFace.Save(chemin + "/" + eleve.NomEleve + eleve.PrenomEleve + "Carte.png", ImageFormat.Png);
        }

        public static void carteArriere(Eleve eleve, PictureBox pbCarteArriere)
        {
            if (eleve.SansEDT == false)
            {
                var cheminEdt = "./data/image/" + eleve.ClasseEleve.Substring(0, 1) + "eme/" +
                              Eleve.creeCleeEleve(eleve) + ".jpg";
                pbCarteArriere.Image = Image.FromFile(cheminEdt);
                Edt.cropEdt(pbCarteArriere, cheminEdt);
            }
            else
            {
                pbCarteArriere.Image = Image.FromFile("./data/FichierEdtClasse/" + eleve.ClasseEleve + ".png");
            }
        }

        public static void importEleves(string path)
        {
            var cheminSource = path;
            var cheminDestination = Chemin.cheminListeEleve;
            try
            {
                if (File.Exists(cheminDestination)) File.Delete(cheminDestination);

                Directory.CreateDirectory(Chemin.cheminDossierListeEleve);

                File.Copy(cheminSource, cheminDestination);
                ReadCSV.setLesEleves(cheminDestination);
                Eleve.setLesClasses();

                MessageBox.Show("Import Réussi");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        // -- Importation des photo des élèves --
        public static void importPhoto(string chemin)
        {
            var cheminSource = chemin;
            var cheminDestination = Chemin.cheminPhotoEleve;

            try
            {
                Directory.Delete(cheminDestination);
                
                Directory.CreateDirectory(cheminDestination);

                var directory = new DirectoryInfo(cheminSource);

                foreach (var file in directory.GetFiles())
                {
                    var img = Image.FromFile(file.FullName);
                    var nom = file.Name;

                    img.Save(cheminDestination + nom, ImageFormat.Png);
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
            var gitPoule23 = "⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠀⠉⠉⠀⠀⠀⠀⠀  ⠀⠀⠀⠀⠀⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀ ⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⠀";

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