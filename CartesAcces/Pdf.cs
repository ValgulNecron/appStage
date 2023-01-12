using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using iText.IO.Util;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Xobject;
using iText.Layout;
using Image = iText.Layout.Element.Image;

namespace CartesAcces
{
    public static class Pdf
    {
        public static int getNbPages(string path)
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(path));
            return pdfDoc.GetNumberOfPages();
        }

        public static void savePdf(string path)
        {
            // -- 
        }

        public static void importEdt(string sourcePath)
        {
            // -- Copie le PDF dans les fichier de l'app --
            string destinationPath = Chemin.pathEdtEleve3e;
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(sourcePath));
            savePageAsPng(pdfDoc, 1, "./test2.png");
            //Globale.listeEdtImage = Pdf.getImages(sourcePath);

            try
            {
                if (File.Exists(destinationPath))
                {
                    File.Delete(destinationPath);
                }

                File.Copy(sourcePath, destinationPath);

                // -- Recupère les EDT sous forme d'image
                MessageBox.Show("listeimg");
                
                //Globale.listeEdtImage = Pdf.getImages(sourcePath);
                // -- Recupère les EDT sous forme de page de PDF
                MessageBox.Show("listeedt");
                //Globale.listeEdt = Pdf.getPages(sourcePath);


                
                MessageBox.Show("Import Réussi");
            }
            catch
            {
                MessageBox.Show("Import Echoué");
            }
        }
        
        public static string getText(string path)
        {
            string pageContent = "";
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(path));
            Document doc = new Document(pdfDoc);
            for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                pageContent = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), strategy);
            }
            pdfDoc.Close();
            return pageContent;
        }

        public static List<PdfPage> getPages(string path)
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(path));
            List<PdfPage> listePages = new List<PdfPage>();
            
            for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
            {
                listePages.Add(pdfDoc.GetPage(page));
            }
            
            return listePages;
        }

        public static List<Image> getImages(string path)
        {
            List<Image> listeImg = new List<Image>();
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(path));
            Document doc = new Document(pdfDoc);
            for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
            {
                MessageBox.Show(page.ToString());
                PdfPage origPage = pdfDoc.GetPage(page);
                PdfDocument pdf = new PdfDocument(new PdfWriter(path));
                PdfFormXObject pageCopy = origPage.CopyAsFormXObject(pdf);
                Image image = new Image(pageCopy);
                listeImg.Add(image);
            }

            return listeImg;
        }

        public static void savePageAsPng(PdfDocument pdfDoc, int numPage, string destPath)
        {
            PdfPage page = pdfDoc.GetPage(numPage); // get the first page of the PDF

            PdfResources resources = page.GetResources();
            PdfDictionary xObjects = resources.GetResource(PdfName.XObject);

            foreach (PdfName xObjectName in xObjects.KeySet())
            {
                PdfObject xObject = xObjects.Get(xObjectName);
                PdfImageXObject img = new PdfImageXObject((PdfStream)xObject);
                byte[] ImageBytes = img.GetImageBytes();
                using (var ms = new MemoryStream(ImageBytes)) 
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                    //Bitmap bitmap = new Bitmap(ms);
                    Bitmap b = new Bitmap(500, 500);

                    MessageBox.Show("created");
                    File.WriteAllBytes(destPath,ImageBytes);
                    //
                    // using(Graphics g = Graphics.FromImage(b))
                    // {
                    //     g.DrawImage(image, 0, 0, 1354, 2654);
                    // }
                    // b.Save(destPath, ImageFormat.Png);
                }
            }
        }
        
    }
}