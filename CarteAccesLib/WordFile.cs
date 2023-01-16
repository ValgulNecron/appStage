using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace CarteAccesLib
{
    public static class WordFile
    {
        
        public static Word.Application initWordFile(int topMargin, int rightMargin, int leftMargin, int bottomMargin)
        {
            // -- Ouverture de l'applucation Word -- 
            Word.Application WordApp = new Word.Application();
            
            // -- Nouveau Document --
            WordApp.Documents.Add();

            // -- Marge à 0 pour éviter les espaces blancs entre la page et l'image sur le document --
            WordApp.ActiveDocument.PageSetup.TopMargin = topMargin;    // 15 points = env à 0.5 cm
            WordApp.ActiveDocument.PageSetup.RightMargin = rightMargin;
            WordApp.ActiveDocument.PageSetup.LeftMargin = leftMargin;
            WordApp.ActiveDocument.PageSetup.BottomMargin = bottomMargin;

            return WordApp;
        }

        public static void rectifPositionImages(Word.Shape shapeCarteFace1, Word.Shape shapeCarteFace2)
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

        public static void limite50Pages(Word.Application WordApp, string path)
        {
            // -- Sauvegarde du document --
            WordApp.ActiveDocument.SaveAs(path + "test.doc", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

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
        }
    }
}