using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CartesAcces;
using LinqToDB;

namespace CarteAccesLib
{
    /// <summary>
    /// 
    /// </summary>
    public static class Edition
    {
        // ** VARIABLES : Pour l'édition de l'emploi du temps (rognage) **
        /// <summary>
        /// 
        /// </summary>
        public static bool SelectionClique { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static int RognageX { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static int RognageY { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static int RognageLargeur { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static int RognageHauteur { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static Pen RognagePen { get; set; }

        // ** VARIABLES  : Déplacement de la photo
        /// <summary>
        /// 
        /// </summary>
        public static bool Drag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static int PosX { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static int PosY { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static int PosXDef { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static int PosYDef { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static int PosHeightDef { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static int PosWidthDef { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static int PosXClassique { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static int PosYClassique { get; set; }

        // ** VARIABLES : Chemin de l'image **
        /// <summary>
        /// 
        /// </summary>
        public static string CheminFichier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static string CheminImpressionFinal { get; set; }

        // -- Dessine le rectangle de couleur derrière le texte pour une meilleurs visibilité de celui ci --
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objGraphique"></param>
        /// <param name="texte"></param>
        /// <param name="police"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="cbbSection"></param>
        public static void FondTexteCarteFace(Graphics objGraphique, string texte, Font police, int posX, int posY,
            ComboBox cbbSection)
        {
            var etab = ClassSql.Db.GetTable<Etablissement>().FirstOrDefault();
            var couleur3 = ColorTranslator.FromHtml(etab.CodeHexa3Eme);
            var couleur4 = ColorTranslator.FromHtml(etab.CodeHexa4Eme);
            var couleur5 = ColorTranslator.FromHtml(etab.CodeHexa5Eme);
            var couleur6 = ColorTranslator.FromHtml(etab.CodeHexa6Eme);

            Brush pinceauJaune = new SolidBrush(couleur6);
            Brush pinceauVert = new SolidBrush(couleur5);
            Brush pinceauRouge = new SolidBrush(couleur4);
            Brush pinceauBleu = new SolidBrush(couleur3);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objGraphique"></param>
        /// <param name="texte"></param>
        /// <param name="police"></param>
        /// <param name="eleve"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        public static void FondTexteCarteFace(Graphics objGraphique, string texte, Font police, Eleve eleve, int posX,
            int posY)
        {
            var etab = ClassSql.Db.GetTable<Etablissement>().FirstOrDefault();
            var couleur3 = ColorTranslator.FromHtml(etab.CodeHexa3Eme);
            var couleur4 = ColorTranslator.FromHtml(etab.CodeHexa4Eme);
            var couleur5 = ColorTranslator.FromHtml(etab.CodeHexa5Eme);
            var couleur6 = ColorTranslator.FromHtml(etab.CodeHexa6Eme);

            Brush brushJaune = new SolidBrush(couleur6);
            Brush brushVert = new SolidBrush(couleur5);
            Brush brushRouge = new SolidBrush(couleur4);
            Brush brushBleu = new SolidBrush(couleur3);

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

        // -- Dessine le texte des cases sur la carte --
        /// <summary>
        /// 
        /// </summary>
        /// <param name="police"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="text"></param>
        /// <param name="pbCarteFace"></param>
        /// <param name="cbbSection"></param>
        public static void DessineTexteCarteFace(Font police, int posX, int posY, string text, PictureBox pbCarteFace,
            ComboBox cbbSection)
        {
            //Pinceaux et graphique
            var objetGraphique = Graphics.FromImage(pbCarteFace.Image);
            Brush pinceauNoir = new SolidBrush(Color.Black);

            //Dessine et rempli le fond pour l'écriture
            FondTexteCarteFace(objetGraphique, text, police, posX, posY, cbbSection);

            //Dessine la saisie en textbox
            objetGraphique.DrawString(text, police, pinceauNoir, posX,
                posY); // Dessine le texte sur l'image à la position X et Y + couleur
            objetGraphique.Dispose(); // Libère les ressources
        }

        // -- Récupère et place le qr code sur la face de la carte
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pbCarteFace"></param>
        public static void QrCodeFace(PictureBox pbCarteFace)
        {
            var etab = ClassSql.Db.GetTable<Etablissement>().FirstOrDefault();
            var bmpOriginal = QrCode.CreationQrCode(etab.UrlEtablissement);
            var bmpFinal = new Bitmap(bmpOriginal, new Size(220, 220));

            var objGraphique = Graphics.FromImage(pbCarteFace.Image);
            objGraphique.DrawImage(bmpFinal, new Point(1350, 80));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objGraphique"></param>
        public static void QrCodeFace(Graphics objGraphique)
        {
            var etab = ClassSql.Db.GetTable<Etablissement>().FirstOrDefault();
            var bmpOriginal = QrCode.CreationQrCode(etab.UrlEtablissement);
            var bmpFinal = new Bitmap(bmpOriginal, new Size(300, 300));

            objGraphique.DrawImage(bmpFinal, new Point(1400, 80));
        }

        // -- Change le fond de la carte en fonction de la section choisie
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pbCarteFace"></param>
        /// <param name="cbbSection"></param>
        public static void FondCarteNiveau(PictureBox pbCarteFace, ComboBox cbbSection)
        {
            if (File.Exists("./data/FichierCartesFace/" + cbbSection.Text + ".png"))
            {
                var bmp = new Bitmap("./data/FichierCartesFace/" + cbbSection.Text + ".png");
                bmp.SetResolution(150, 150);
                pbCarteFace.Image = bmp;
            }
            else
            {
                var bmp = new Bitmap("./data/FichierCartesFace/default.png");
                bmp.SetResolution(150, 150);
                pbCarteFace.Image = bmp;
            }

            QrCodeFace(pbCarteFace);

            var police = new Font("Calibri", 45, FontStyle.Bold);
            DessineTexteCarteFace(police, 50, 70, "Carte Provisoire", pbCarteFace, cbbSection);

            var police2 = new Font("Calibri", 24, FontStyle.Bold);

            var police3 = new Font("Calibri", 24, FontStyle.Bold);
            DessineTexteCarteFace(police3, 50, 960, "Nom :", pbCarteFace, cbbSection);
            DessineTexteCarteFace(police3, 50, 1075, "Prénom :", pbCarteFace, cbbSection);

            var police4 = new Font("Calibri", 24, FontStyle.Bold);

            var succes = true;

            var objetGraphique = Graphics.FromImage(pbCarteFace.Image);
            int mesure;
            string chaine;

            if (succes)
            {
                var etab = ClassSql.Db.GetTable<Etablissement>().FirstOrDefault();
                var date = DateTime.Today.ToShortDateString();

                chaine = "Date de création : " + date;
                mesure = Convert.ToInt32(objetGraphique.MeasureString(chaine, police4).Width);
                DessineTexteCarteFace(police2, 1700 - mesure, 700, chaine, pbCarteFace, cbbSection);

                chaine = etab.NomEtablissement;
                mesure = Convert.ToInt32(objetGraphique.MeasureString(chaine, police4).Width);
                DessineTexteCarteFace(police4, 1700 - mesure, 780, etab.NomEtablissement, pbCarteFace, cbbSection);

                chaine = "Adresse : " + etab.NumeroRueEtablissement + " " + etab.NomRueEtablissement;
                mesure = Convert.ToInt32(objetGraphique.MeasureString(chaine, police4).Width);
                DessineTexteCarteFace(police4, 1700 - mesure, 860, chaine, pbCarteFace, cbbSection);

                chaine = etab.CodePostaleEtablissement + " " + etab.VilleEtablissement;
                mesure = Convert.ToInt32(objetGraphique.MeasureString(chaine, police4).Width);
                DessineTexteCarteFace(police4, 1700 - mesure, 940, chaine, pbCarteFace, cbbSection);

                chaine = "Tel : " + etab.NumeroTelephoneEtablissement;
                mesure = Convert.ToInt32(objetGraphique.MeasureString(chaine, police4).Width);
                DessineTexteCarteFace(police4, 1700 - mesure, 1020, chaine, pbCarteFace, cbbSection);

                chaine = "Mail : " + etab.EmailEtablissement;
                mesure = Convert.ToInt32(objetGraphique.MeasureString(chaine, police4).Width);
                DessineTexteCarteFace(police4, 1700 - mesure, 1100, chaine, pbCarteFace, cbbSection);
            }

            pbCarteFace.Refresh();
        }

        // -- N'affiche que les classes correspondantes a la section selectionnées --
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cbbSection"></param>
        /// <param name="cbbClasse"></param>
        public static void ClassePourNiveau(ComboBox cbbSection, ComboBox cbbClasse)
        {
            switch (cbbSection.Text)
            {
                case "6eme":
                    cbbClasse.DataSource = Globale.Classes6Eme;
                    break;

                case "5eme":
                    cbbClasse.DataSource = Globale.Classes5Eme;
                    break;

                case "4eme":
                    cbbClasse.DataSource = Globale.Classes4Eme;
                    break;

                case "3eme":
                    cbbClasse.DataSource = Globale.Classes3Eme;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="txtPrenom"></param>
        /// <param name="pbCarteFace"></param>
        /// <param name="cbbSection"></param>
        public static void ReprendPrenom(string txtPrenom, PictureBox pbCarteFace,
            ComboBox cbbSection)
        {
            if (txtPrenom != "")
            {
                if (txtPrenom.Length < 15)
                {
                    var font = new Font("Calibri", 28, FontStyle.Bold);
                    DessineTexteCarteFace(font, 325, 1075, txtPrenom, pbCarteFace, cbbSection);
                    pbCarteFace.Refresh();
                }
                else
                {
                    FondCarteNiveau(pbCarteFace, cbbSection);
                    var font = new Font("Calibri", 25, FontStyle.Bold);
                    DessineTexteCarteFace(font, 325, 1075, txtPrenom, pbCarteFace, cbbSection);
                    pbCarteFace.Refresh();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="txtNom"></param>
        /// <param name="pbCarteFace"></param>
        /// <param name="cbbSection"></param>
        public static void ReprendNom(string txtNom, PictureBox pbCarteFace, ComboBox cbbSection)
        {
            if (txtNom != "")
            {
                if (txtNom.Length < 15)
                {
                    var font = new Font("times new roman", 28, FontStyle.Bold);
                    DessineTexteCarteFace(font, 250, 960, txtNom, pbCarteFace, cbbSection);
                    pbCarteFace.Refresh();
                }
                else
                {
                    FondCarteNiveau(pbCarteFace, cbbSection);
                    var font = new Font("times new roman", 25, FontStyle.Bold);
                    DessineTexteCarteFace(font, 250, 960, txtNom, pbCarteFace, cbbSection);
                    pbCarteFace.Refresh();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetDateFace()
        {
            if (File.Exists("./data/FichierCartesFace/6eme.png"))
                return File.GetCreationTime("./data/FichierCartesFace/6eme.png").ToString();

            if (File.Exists("./data/FichierCartesFace/5eme.png"))
                return File.GetCreationTime("./data/FichierCartesFace/5eme.png").ToString();

            if (File.Exists("./data/FichierCartesFace/3eme.png"))
                return File.GetCreationTime("./data/FichierCartesFace/3eme.png").ToString();

            if (File.Exists("./data/FichierCartesFace/4eme.png"))
                return File.GetCreationTime("./data/FichierCartesFace/4eme.png").ToString();

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rdbUlis"></param>
        /// <param name="rdbUpe2A"></param>
        /// <param name="rdbClRelais"></param>
        /// <param name="pbCarteFace"></param>
        /// <param name="cbbSection"></param>
        /// <param name="btnEdtPerso"></param>
        /// <param name="txtNom"></param>
        /// <param name="txtPrenom"></param>
        public static void CheckMef(RadioButton rdbUlis, RadioButton rdbUpe2A, RadioButton rdbClRelais,
            PictureBox pbCarteFace, ComboBox cbbSection, Button btnEdtPerso, TextBox txtNom, TextBox txtPrenom)
        {
            if (rdbUlis.Checked)
            {
                FondCarteNiveau(pbCarteFace, cbbSection);
                ReprendNom(txtNom.Text, pbCarteFace, cbbSection);
                ReprendPrenom(txtPrenom.Text, pbCarteFace, cbbSection);
                var police = new Font("Calibri", 30, FontStyle.Bold);
                DessineTexteCarteFace(police, 50, 230, "ULIS ", pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
                btnEdtPerso.Enabled = true;
            }
            else if (rdbUpe2A.Checked)
            {
                FondCarteNiveau(pbCarteFace, cbbSection);
                ReprendNom(txtNom.Text, pbCarteFace, cbbSection);
                ReprendPrenom(txtPrenom.Text, pbCarteFace, cbbSection);
                var police = new Font("Calibri", 30, FontStyle.Bold);
                DessineTexteCarteFace(police, 50, 230, "UPE2A", pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
                btnEdtPerso.Enabled = true;
            }
            else if (rdbClRelais.Checked)
            {
                FondCarteNiveau(pbCarteFace, cbbSection);
                ReprendNom(txtNom.Text, pbCarteFace, cbbSection);
                ReprendPrenom(txtPrenom.Text, pbCarteFace, cbbSection);
                var police = new Font("Calibri", 30, FontStyle.Bold);
                DessineTexteCarteFace(police, 50, 230, "CL-Relais", pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
                btnEdtPerso.Enabled = true;
            }
            else
            {
                FondCarteNiveau(pbCarteFace, cbbSection);
                ReprendNom(txtNom.Text, pbCarteFace, cbbSection);
                ReprendPrenom(txtPrenom.Text, pbCarteFace, cbbSection);
                btnEdtPerso.Enabled = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eleve"></param>
        /// <returns></returns>
        public static Image ImageCarteFace(Eleve eleve)
        {
            var image = Image.FromFile("./data/FichierCartesFace/default.png");

            if (File.Exists("./data/FichierCartesFace/" + eleve.ClasseEleve.Substring(0, 1) + "eme.png"))
                image = Image.FromFile("./data/FichierCartesFace/" + eleve.ClasseEleve.Substring(0, 1) + "eme.png");

            var objGraphique = Graphics.FromImage(image);

            QrCodeFace(objGraphique);

            Brush pinceauNoir = new SolidBrush(Color.Black);

            var police = new Font("Calibri", 45, FontStyle.Bold);
            var police2 = new Font("Calibri", 22, FontStyle.Bold);
            var police3 = new Font("Calibri", 40, FontStyle.Bold);
            var police4 = new Font("Calibri", 32, FontStyle.Bold);

            var date = DateTime.Today.ToShortDateString();
            var etab = ClassSql.Db.GetTable<Etablissement>().FirstOrDefault();

            //Dessine et rempli le fond pour l'écriture
            FondTexteCarteFace(objGraphique, eleve.MefEleve, police2, eleve, 50, 70);

            //Dessine la saisie en textbox
            var chaine = "Nom : " + eleve.NomEleve;
            FondTexteCarteFace(objGraphique, chaine, police3, eleve, 50, 960);
            objGraphique.DrawString(chaine, police3, pinceauNoir, 50,
                960); // Dessine le texte sur l'image à la position X et Y + couleur
            chaine = "Prenom : " + eleve.PrenomEleve;
            FondTexteCarteFace(objGraphique, chaine, police3, eleve, 50, 1075);
            objGraphique.DrawString(chaine, police3, pinceauNoir, 50, 1075);

            FondTexteCarteFace(objGraphique, eleve.MefEleve, police, eleve, 50, 70);
            objGraphique.DrawString(eleve.MefEleve, police, pinceauNoir, 50, 70);

            chaine = "Date de création : " + date;
            var mesure = Convert.ToInt32(objGraphique.MeasureString(chaine, police4).Width);
            FondTexteCarteFace(objGraphique, chaine, police2, eleve, 1850 - mesure, 850);
            objGraphique.DrawString(chaine, police2, pinceauNoir, 1850 - mesure, 850);

            chaine = etab.NomEtablissement;
            mesure = Convert.ToInt32(objGraphique.MeasureString(chaine, police4).Width);
            FondTexteCarteFace(objGraphique, chaine, police4, eleve, 1700 - mesure, 892);
            objGraphique.DrawString(chaine, police4, pinceauNoir, 1700 - mesure, 892);

            chaine = "Adresse : " + etab.NumeroRueEtablissement + " " + etab.NomRueEtablissement;
            mesure = Convert.ToInt32(objGraphique.MeasureString(chaine, police4).Width);
            FondTexteCarteFace(objGraphique, chaine, police4, eleve, 1700 - mesure, 944);
            objGraphique.DrawString(chaine, police4, pinceauNoir, 1700 - mesure, 944);

            chaine = etab.CodePostaleEtablissement + " " + etab.VilleEtablissement;
            mesure = Convert.ToInt32(objGraphique.MeasureString(chaine, police4).Width);
            FondTexteCarteFace(objGraphique, chaine, police4, eleve, 1700 - mesure, 996);
            objGraphique.DrawString(chaine, police4, pinceauNoir, 1700 - mesure, 996);

            chaine = "Tel : " + etab.NumeroTelephoneEtablissement;
            mesure = Convert.ToInt32(objGraphique.MeasureString(chaine, police4).Width);
            FondTexteCarteFace(objGraphique, chaine, police4, eleve, 1700 - mesure, 1048);
            objGraphique.DrawString(chaine, police4, pinceauNoir, 1700 - mesure, 1048);

            chaine = "Mail : " + etab.EmailEtablissement;
            mesure = Convert.ToInt32(objGraphique.MeasureString(chaine, police4).Width);
            FondTexteCarteFace(objGraphique, chaine, police4, eleve, 1700 - mesure, 1100);
            objGraphique.DrawString(chaine, police4, pinceauNoir, 1700 - mesure, 1100);
            objGraphique.Dispose(); // Libère les ressources

            return image;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eleve"></param>
        /// <param name="chemin"></param>
        public static void CarteFace(Eleve eleve, string chemin)
        {
            // -- Déclare l'image --
            Image imageFace = null;

            // -- Gestion de la taille de la police --
            if (eleve.NomEleve.Length > 10 || eleve.PrenomEleve.Length > 10)
            {
                var police = new Font("times new roman", 20, FontStyle.Bold);
                imageFace = ImageCarteFace(eleve);
            }
            else
            {
                var police = new Font("times new roman", 25, FontStyle.Bold);
                imageFace = ImageCarteFace(eleve);
            }

            // -- Sauvegarde l'image --
            imageFace.Save(chemin + "/" + eleve.NomEleve + eleve.PrenomEleve + "Carte.png", ImageFormat.Png);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eleve"></param>
        /// <param name="pbCarteArriere"></param>
        public static void CarteArriere(Eleve eleve, PictureBox pbCarteArriere)
        {
            if (!eleve.SansEdt)
            {
                var cheminEdt = "./data/image/" + eleve.ClasseEleve.Substring(0, 1) + "eme/" +
                                Eleve.CreeCleEleve(eleve) + ".jpg";
                pbCarteArriere.Image = Image.FromFile(cheminEdt);
                Edt.RognageEdt(pbCarteArriere, cheminEdt);
            }
            else
            {
                pbCarteArriere.Image = Image.FromFile("./data/FichierEdtClasse/" + eleve.ClasseEleve + ".jpg");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="posx"></param>
        /// <param name="posy"></param>
        public static void ReplacementPhotoClassique(int posx, int posy)
        {
            PosYClassique = posy;
            PosXClassique = posx;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void ImportEleves(string path)
        {
            var cheminSource = path;
            var cheminDestination = Chemin.CheminListeEleve;
            try
            {
                if (File.Exists(cheminDestination)) File.Delete(cheminDestination);

                Directory.CreateDirectory(Chemin.CheminDossierListeEleve);

                File.Copy(cheminSource, cheminDestination);
                File.SetCreationTime(cheminDestination, DateTime.Now);
                ReadCsv.SetLesEleves(cheminDestination);
                Eleve.SetLesClasses();

                MessageBox.Show(new Form {TopLevel = true, TopMost = true}, "L'importation du fichier CSV a réussi");
            }
            catch (Exception e)
            {
                MessageBox.Show("eeeee + " + e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chemin"></param>
        public static void ImportCarteFace(string chemin)
        {
            var cheminSource = chemin;
            var cheminDestination = Chemin.CheminFaceCarte + Globale.Classe + "eme.png";

            try
            {
                if (File.Exists(cheminDestination)) File.Delete(cheminDestination);

                Directory.CreateDirectory(Chemin.CheminFaceCarte);

                var img = Image.FromFile(cheminSource);
                var bmp = new Bitmap(img, new Size(1754, 1240));

                var etab = ClassSql.Db.GetTable<Etablissement>().FirstOrDefault();
                var bord = etab.Bordure;

                if (bord)
                {
                    var couleur = "";

                    switch (Globale.Classe)
                    {
                        case 6:
                            couleur = etab.CodeHexa6Eme;
                            break;
                        case 5:
                            couleur = etab.CodeHexa5Eme;
                            break;
                        case 4:
                            couleur = etab.CodeHexa4Eme;
                            break;
                        case 3:
                            couleur = etab.CodeHexa3Eme;
                            break;
                    }

                    var col = ColorTranslator.FromHtml(couleur);
                    Brush br = new SolidBrush(col);

                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.DrawRectangle(new Pen(br, 40), new Rectangle(0, 0, bmp.Width, bmp.Height));
                    }
                }

                bmp.Save(cheminDestination, ImageFormat.Png);
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chemin"></param>
        public static void ImportEdtClassique(string chemin)
        {
            var cheminDestination = Chemin.CheminEdtClassique;

            try
            {
                if (Directory.Exists(cheminDestination))
                {
                    foreach (var fichier in Directory.GetFiles(cheminDestination))
                        if (!fichier.Contains("Default"))
                            File.Delete(fichier);
                    Directory.Delete(cheminDestination);
                }

                Directory.CreateDirectory(cheminDestination);
            }
            catch
            {
                // ignored
            }
        }

        // -- Importation des photo des élèves --
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chemin"></param>
        public static void ImportPhoto(string chemin)
        {
            var cheminSource = chemin;
            var cheminDestination = Chemin.CheminPhotoEleve;

            try
            {
                if (Directory.Exists(cheminDestination))
                {
                    foreach (var file in Directory.GetFiles(cheminDestination)) File.Delete(file);
                    Directory.Delete(cheminDestination);
                }

                Directory.CreateDirectory(cheminDestination);

                var directory = new DirectoryInfo(cheminSource);

                foreach (var file in directory.GetFiles())
                {
                    var img = Image.FromFile(file.FullName);
                    var nom = file.Name;
                    img.Save(cheminDestination + nom, ImageFormat.Png);
                    img.Dispose();
                }

                Globale.Actuelle.Invoke(new MethodInvoker(delegate
                {
                    foreach (Control controle in Globale.Actuelle.Controls)
                        if (controle is Label && controle.Name == "lblDateListeEleve")
                            controle.Text = ReadCsv.GetDateFile();
                }));

                MessageBox.Show(new Form {TopMost = true}, " Les photos du dossier ont été importés");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chemin"></param>
        public static void ImportLogo(string chemin)
        {
            var cheminSource = chemin;
            var cheminDestination = "./data/";

            try
            {
                if (File.Exists("./data/logo.png")) File.Delete("./data/logo.png");

                var img = Image.FromFile(chemin);
                img.Save(cheminDestination + "logo.png", ImageFormat.Png);
                img.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public static void GitPoule()
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

            var listePoule = new List<string>();
            listePoule.Add(gitPoule1);
            listePoule.Add(gitPoule2);
            listePoule.Add(gitPoule3);
            listePoule.Add(gitPoule4);
            listePoule.Add(gitPoule5);
            listePoule.Add(gitPoule6);
            listePoule.Add(gitPoule7);
            listePoule.Add(gitPoule8);
            listePoule.Add(gitPoule9);
            listePoule.Add(gitPoule10);
            listePoule.Add(gitPoule11);
            listePoule.Add(gitPoule12);
            listePoule.Add(gitPoule13);
            listePoule.Add(gitPoule14);
            listePoule.Add(gitPoule15);
            listePoule.Add(gitPoule16);
            listePoule.Add(gitPoule17);
            listePoule.Add(gitPoule18);
            listePoule.Add(gitPoule19);
            listePoule.Add(gitPoule20);
            listePoule.Add(gitPoule21);
            listePoule.Add(gitPoule22);
            listePoule.Add(gitPoule23);
        }
    }
}