using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CarteAcces;
using CartesAcces;
using Application = Microsoft.Office.Interop.Word.Application;

namespace CarteAccesLib
{
    public static class WordFile
    {
        public static Application initWordFile(int topMargin, int rightMargin, int leftMargin, int bottomMargin)
        {
            // -- Ouverture de l'applucation Word -- 
            var WordApp = new Application();

            // -- Nouveau Document --
            WordApp.Documents.Add();

            // -- Marge à 0 pour éviter les espaces blancs entre la page et l'image sur le document --
            WordApp.ActiveDocument.PageSetup.TopMargin = topMargin; // 15 points = env à 0.5 cm
            WordApp.ActiveDocument.PageSetup.RightMargin = rightMargin;
            WordApp.ActiveDocument.PageSetup.LeftMargin = leftMargin;
            WordApp.ActiveDocument.PageSetup.BottomMargin = bottomMargin;

            return WordApp;
        }

        public static void rectifPositionImages(Shape shapeCarteFace1, Shape shapeCarteFace2)
        {
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
        }

        public static void limite50Pages(Application WordApp, string path)
        {
            // -- Sauvegarde du document --
            WordApp.ActiveDocument.SaveAs(path + "test.doc", Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // -- Ferme le document --
            WordApp.ActiveDocument.Close();

            //Permet d'éviter la surcharge de mémoire qui s'arrête à 2400 ko, puis l'application s'arrête
            GC.Collect();

            // -- Nouveau Document --
            WordApp.Documents.Add();

            // -- Marge à 0 pour éviter les espaces blancs entre la page et l'image sur le document --
            WordApp.ActiveDocument.PageSetup.TopMargin = 15; // 15 points = env à 0.5 cm
            WordApp.ActiveDocument.PageSetup.RightMargin = 15;
            WordApp.ActiveDocument.PageSetup.LeftMargin = 15;
            WordApp.ActiveDocument.PageSetup.BottomMargin = 15;
        }
        
        public static void saveCardAsWord(string path, string nomFicher, List<Eleve> listeEleve, PictureBox pbPhoto,
            PictureBox pbCarteArriere)
        {
            var k = 0;
            var pages = 0;
            Eleve.possedeEdt(listeEleve);
            var wordFile = WordFile.initWordFile(15, 15, 15, 15);

            for (var compt = 1; compt <= listeEleve.Count; compt += 2)
            {
                // -- Les élèves sont gérés deux par deux --

                // -- Carte Face : 1/2 Eleve --
                Edition.carteFace(listeEleve[compt], path);
                // -- Carte Face : 2/2 Eleve --
                Edition.carteFace(listeEleve[compt - 1], path);

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
                Edition.carteArriere(listeEleve[compt], pbCarteArriere);
                Photo.verifPhotoEleve(listeEleve[compt], pbPhoto);
                Photo.proportionPhoto(pbPhoto, pbCarteArriere, listeEleve[compt], path);
                // -- Carte arriere : 2/2 Eleve --
                Edition.carteArriere(listeEleve[compt - 1], pbCarteArriere);
                Photo.verifPhotoEleve(listeEleve[compt - 1], pbPhoto);
                Photo.proportionPhoto(pbPhoto, pbCarteArriere, listeEleve[compt - 1], path);

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
                    var name = path + " page " + k / 50;
                    WordFile.limite50Pages(wordFile, name);
                    k += 50;
                    pages++;
                }
            }

            if (k / 50 == 1)
                wordFile.ActiveDocument.SaveAs(path + "/Imprimer.doc", Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            else
                wordFile.ActiveDocument.SaveAs(path + "/Imprimer Part " + pages + ".doc", Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // -- Ferme le document --
            wordFile.ActiveDocument.Close();

            // -- Quitte l'application -- 
            wordFile.Quit();

            // -- TaskKill --
            Marshal.FinalReleaseComObject(wordFile);

            //Permet d'éviter la surcharge de mémoire qui s'arrête à 2400 ko, puis l'application s'arrête
            GC.Collect();

            // -- Message qui indique que nous sommes arrivé au bout --
            MessageBox.Show(listeEleve.Count + " élèves ont été imprimés.");
        }
    }
}