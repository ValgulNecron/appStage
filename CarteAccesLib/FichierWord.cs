using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CartesAcces;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;  

namespace CarteAccesLib
{
    /// <summary>
    /// 
    /// </summary>
    public static class FichierWord
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="margeHaute"></param>
        /// <param name="margeDroite"></param>
        /// <param name="margeGauche"></param>
        /// <param name="margeBasse"></param>
        /// <returns></returns>
        public static Application InitWordFile(int margeHaute, int margeDroite, int margeGauche, int margeBasse)
        {
            FermerWord();
            // -- Ouverture de l'applucation Word -- 
            var applicationWord = new Application();

            // -- Nouveau Document --
            applicationWord.Documents.Add();

            // -- Marge à 0 pour éviter les espaces blancs entre la page et l'image sur le document --
            applicationWord.ActiveDocument.PageSetup.TopMargin = margeHaute; // 15 points = env à 0.5 cm
            applicationWord.ActiveDocument.PageSetup.RightMargin = margeDroite;
            applicationWord.ActiveDocument.PageSetup.LeftMargin = margeGauche;
            applicationWord.ActiveDocument.PageSetup.BottomMargin = margeBasse;

            return applicationWord;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationWord"></param>
        /// <param name="carteFace1"></param>
        /// <param name="carteFace2"></param>
        public static void RectifPositionImages(Application applicationWord, Shape carteFace1, Shape carteFace2)
        {
            // -- Gestion de la hauteur et de la position des images --
            /*
             * Le but ici est d'avoir un espace blanc d'environ 1cm au milieu de la page, entre les deux image, pour la découpe.
             * On définit la position de la deuxieme image par rapport au haut de la page afin d'ancrer celle au bas de la page.
             * Et enfin on gère la hauteur des deux images pour que celles ci aient les mêmes dimensions.
            */

            carteFace1.Height = 379;

            //MessageBox.Show(carteFace1.Height.ToString());

            carteFace1.Top = 0;
            carteFace1.Left = 0;

            carteFace2.Height = carteFace1.Height;
            carteFace2.Top = carteFace1.Height + 50;
            carteFace2.Left = 0;

            // carteFace1.Height = carteFace1.Height - 20;
            // carteFace2.RelativeVerticalPosition = WdRelativeVerticalPosition.wdRelativeVerticalPositionPage;
            // carteFace2.Top = applicationWord.InchesToPoints(11 - carteFace1.Height / 72);
            // carteFace2.Height = carteFace1.Height;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationWord"></param>
        /// <param name="chemin"></param>
        /// <param name="nbPage"></param>
        public static void Limite50Pages(Application applicationWord, string chemin, int nbPage)
        {
            // -- Sauvegarde du document --
            applicationWord.ActiveDocument.SaveAs(chemin + "Part " + nbPage + " " + ".doc", Type.Missing, Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // -- Ferme le document --
            applicationWord.ActiveDocument.Close();

            //Permet d'éviter la surcharge de mémoire qui s'arrête à 2400 ko, puis l'application s'arrête
            GC.Collect();

            // -- Nouveau Document --
            applicationWord.Documents.Add();

            // -- Marge à 0 pour éviter les espaces blancs entre la page et l'image sur le document --
            applicationWord.ActiveDocument.PageSetup.TopMargin = 15;
            applicationWord.ActiveDocument.PageSetup.RightMargin = 15;
            applicationWord.ActiveDocument.PageSetup.LeftMargin = 15;
            applicationWord.ActiveDocument.PageSetup.BottomMargin = 15;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chemin"></param>
        /// <param name="listeEleve"></param>
        /// <param name="pbPhoto"></param>
        /// <param name="pbCarteArriere"></param>
        public static void SauvegardeCarteEnWord(string chemin, List<Eleve> listeEleve, PictureBox pbPhoto,
            PictureBox pbCarteArriere)
        {
            FermerWord();
            var k = 0;
            var pages = 0;
            Eleve.PossedeEdt(listeEleve);
            var fichierWord = InitWordFile(15, 15, 15, 15);

            Globale.LblCount.Visible = true;
            for (var compt = 1; compt <= listeEleve.Count; compt += 2)
            {
                Globale.LblCount.Text = compt + "/" + listeEleve.Count + " cartes réalisées";

                // -- Les élèves sont gérés deux par deux --

                // -- Carte Face : 1/2 Eleve --
                Edition.CarteFace(listeEleve[compt], chemin);
                // -- Carte Face : 2/2 Eleve --
                Edition.CarteFace(listeEleve[compt - 1], chemin);

                // -- Ajout des deux fichier PNG au nouveau document Word --
                var shapeCarteFace1 = fichierWord.ActiveDocument.Shapes.AddPicture(
                    chemin + "\\" + listeEleve[compt].NomEleve + listeEleve[compt].PrenomEleve + "Carte.png",
                    Type.Missing, Type.Missing, Type.Missing);
                var shapeCarteFace2 = fichierWord.ActiveDocument.Shapes.AddPicture(
                    chemin + "\\" + listeEleve[compt - 1].NomEleve + listeEleve[compt - 1].PrenomEleve + "Carte.png",
                    Type.Missing, Type.Missing, Type.Missing);
                RectifPositionImages(fichierWord, shapeCarteFace1, shapeCarteFace2);
                // -- Suppression des deux fichiers PNG, plus besoin d'eux maintenant qu'ils sont dans le fichier Word -- 
                File.Delete(chemin + "\\" + listeEleve[compt].NomEleve + listeEleve[compt].PrenomEleve + "Carte.png");
                File.Delete(chemin + "\\" + listeEleve[compt - 1].NomEleve + listeEleve[compt - 1].PrenomEleve +
                            "Carte.png");
                //Permet d'éviter la surcharge de mémoire qui s'arrête à 2400 ko, puis l'application s'arrête
                GC.Collect();
                // -- Nouvelle page --
                //fichierWord.Selection.InsertNewPage();
                fichierWord.Selection.EndKey(WdUnits.wdStory, Missing.Value);
                fichierWord.Selection.InsertBreak(WdBreakType.wdSectionBreakNextPage);

                // ------------------------------------------------------------------

                // -- Carte arriere : 1/2 Eleve --
                Edition.CarteArriere(listeEleve[compt], pbCarteArriere);
                Photo.VerifPhotoEleve(listeEleve[compt], pbPhoto);
                Photo.ProportionPhotoMultiple(pbPhoto, pbCarteArriere, listeEleve[compt], chemin);
                // -- Carte arriere : 2/2 Eleve --
                Edition.CarteArriere(listeEleve[compt - 1], pbCarteArriere);
                Photo.VerifPhotoEleve(listeEleve[compt - 1], pbPhoto);
                Photo.ProportionPhotoMultiple(pbPhoto, pbCarteArriere, listeEleve[compt - 1], chemin);

                Globale.LblCount.Text = compt + 1 + "/" + listeEleve.Count + " cartes réalisées";

                // -- Ajout des deux fichier PNG au nouveau document Word --
                var shapeCarteArriere1 = fichierWord.ActiveDocument.Shapes.AddPicture(
                    chemin + "/" + listeEleve[compt].NomEleve + listeEleve[compt].PrenomEleve + "EDT.png", Type.Missing,
                    Type.Missing, Type.Missing);
                var shapeCarteArriere2 = fichierWord.ActiveDocument.Shapes.AddPicture(
                    chemin + "/" + listeEleve[compt - 1].NomEleve + listeEleve[compt - 1].PrenomEleve + "EDT.png",
                    Type.Missing, Type.Missing, Type.Missing);

                RectifPositionImages(fichierWord, shapeCarteArriere1, shapeCarteArriere2);

                // -- Suppression des deux fichiers PNG, plus besoin d'eux maintenant qu'ils sont dans le fichier Word -- 
                File.Delete(chemin + "\\" + listeEleve[compt].NomEleve + listeEleve[compt].PrenomEleve + "EDT.png");
                File.Delete(
                    chemin + "\\" + listeEleve[compt - 1].NomEleve + listeEleve[compt - 1].PrenomEleve + "EDT.png");

                //Permet d'éviter la surcharge de mémoire qui s'arrête à 2400 ko, puis l'application s'arrête
                GC.Collect();

                // -- Nouvelle page --
                fichierWord.Selection.EndKey(WdUnits.wdStory, Missing.Value);
                fichierWord.Selection.InsertBreak(WdBreakType.wdSectionBreakNextPage);
                //fichierWord.Selection.InsertBreak(WdBreakType.wdPageBreak);

                if (compt > k + 50)
                {
                    var name = chemin + "/Imprimer ";
                    var nbPage = k / 50;
                    Limite50Pages(fichierWord, name, nbPage);
                    k += 50;
                    pages++;
                }
            }

            if (k / 50 == 1)
                fichierWord.ActiveDocument.SaveAs(chemin + "/Imprimer.doc", Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            else
                fichierWord.ActiveDocument.SaveAs(chemin + "/Imprimer Part " + pages + ".doc", Type.Missing,
                    Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // -- Ferme le document --
            fichierWord.ActiveDocument.Close();

            // -- Quitte l'application -- 
            fichierWord.Quit();

            // -- TaskKill --
            Marshal.FinalReleaseComObject(fichierWord);

            //Permet d'éviter la surcharge de mémoire qui s'arrête à 2400 ko, puis l'application s'arrête
            GC.Collect();

            // -- Message qui indique que nous sommes arrivé au bout --
            if (Globale.EleveImpr)
                MessageBox.Show(new Form {TopMost = true}, listeEleve.Count - 1 + " élèves ont été imprimés.");
            else
                MessageBox.Show(new Form {TopMost = true}, listeEleve.Count + " élèves ont été imprimés.");
            FermerWord();
        }


        /// <summary>
        /// 
        /// </summary>
        public static void GetDossierCarteProvisoire()
        {
            var diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == DialogResult.OK)
                Edition.CheminImpressionFinal = diag.SelectedPath;

            else
                MessageBox.Show(new Form {TopMost = true},
                    "Merci de choisir un dossier de destination pour les fichiers générés par l'application");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pbCarteArriere"></param>
        /// <param name="pbPhoto"></param>
        /// <param name="pbCarteFace"></param>
        /// <param name="txtNom"></param>
        /// <param name="txtPrenom"></param>
        public static void SauvegardeCarteProvisoireWord(PictureBox pbCarteArriere, PictureBox pbPhoto,
            PictureBox pbCarteFace, TextBox txtNom, TextBox txtPrenom)
        {
            FermerWord();
            if (pbCarteArriere.Image != null && pbCarteFace.Image != null && pbPhoto.Image != null)
            {
                double rLocX = pbPhoto.Location.X * pbCarteArriere.Image.Width / pbCarteArriere.Width;
                double rLocY = pbPhoto.Location.Y * pbCarteArriere.Image.Height / pbCarteArriere.Height;
                double rWidth = pbPhoto.Width * pbCarteArriere.Image.Width / pbCarteArriere.Width;
                double rHeight = pbPhoto.Height * pbCarteArriere.Image.Height / pbCarteArriere.Height;

                // -- Rectifications des positions --
                var realLocX = Convert.ToInt32(Math.Round(rLocX)) - 2;
                var realLocY = Convert.ToInt32(Math.Round(rLocY)) + 3;
                var realWidth = Convert.ToInt32(Math.Round(rWidth)) - 1;
                var realHeight = Convert.ToInt32(Math.Round(rHeight)) - 1;

                var ObjGraphics = Graphics.FromImage(pbCarteArriere.Image);
                ObjGraphics.DrawImage(pbPhoto.Image, realLocX, realLocY, realWidth, realHeight);

                Edition.CheminImpressionFinal = Edition.CheminImpressionFinal + "\\";

                pbCarteArriere.Image.Save(Edition.CheminImpressionFinal + txtNom.Text + txtPrenom.Text + "EDT.png",
                    ImageFormat.Png);
                pbCarteFace.Image.Save(Edition.CheminImpressionFinal + txtNom.Text + txtPrenom.Text + "Carte.png",
                    ImageFormat.Png);

                var WordApp = new Application();
                WordApp.Documents.Add();
                WordApp.ActiveDocument.PageSetup.TopMargin = 15;
                WordApp.ActiveDocument.PageSetup.RightMargin = 15;
                WordApp.ActiveDocument.PageSetup.LeftMargin = 15;
                WordApp.ActiveDocument.PageSetup.BottomMargin = 15;

                var shapeCarte = WordApp.ActiveDocument.Shapes.AddPicture(
                    Edition.CheminImpressionFinal + txtNom.Text + txtPrenom.Text + "Carte.png", Type.Missing,
                    Type.Missing, Type.Missing);

                WordApp.Selection.EndKey();
                WordApp.Selection.InsertNewPage();

                var shapeEDT = WordApp.ActiveDocument.Shapes.AddPicture(
                    Edition.CheminImpressionFinal + txtNom.Text + txtPrenom.Text + "EDT.png", Type.Missing,
                    Type.Missing, Type.Missing);

                shapeCarte.Top = 0;
                shapeCarte.Left = 0;

                shapeEDT.Top = 0;
                shapeEDT.Height = shapeCarte.Height;

                File.Delete(Edition.CheminImpressionFinal + txtNom.Text + txtPrenom.Text + "EDT.png");
                File.Delete(Edition.CheminImpressionFinal + txtNom.Text + txtPrenom.Text + "Carte.png");

                WordApp.ActiveDocument.SaveAs(
                    Edition.CheminImpressionFinal + txtNom.Text + txtPrenom.Text + " Carte.doc", Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                WordApp.ActiveDocument.Close();
                WordApp.Quit();
                Marshal.FinalReleaseComObject(WordApp);

                GC.Collect();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void FermerWord()
        {
            var processes = Process.GetProcessesByName("WINWORD");
            foreach (var process in processes) process.Kill();
        }
    }
}