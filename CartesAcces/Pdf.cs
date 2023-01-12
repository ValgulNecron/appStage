using System;
using System.Collections.Generic;
using System.Drawing;
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

        public static List<Image> getImages(string path)
        {
            List<Image> listeImg = new List<Image>();
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(path));
            Document doc = new Document(pdfDoc);
            for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
            {
                PdfPage origPage = pdfDoc.GetPage(1);
                PdfDocument pdf = new PdfDocument(new PdfWriter(path));
                PdfFormXObject pageCopy = origPage.CopyAsFormXObject(pdf);
                Image image = new Image(pageCopy);
                listeImg.Add(image);
            }

            return listeImg;
        }

        public static void imgTest(string path)
        {
            using (PdfDocument pdfDoc = new PdfDocument(new PdfReader("path/to/input.pdf")))
            {
                PdfPage page = pdfDoc.GetPage(1); // get the first page of the PDF

                PdfResources resources = page.GetResources();
                PdfDictionary xObjects = resources.GetResource(PdfName.XObject);

                foreach (PdfName xObjectName in xObjects.KeySet())
                {
                    PdfObject xObject = xObjects.Get(xObjectName);
                    if (xObject.IsIndirectReference())
                    {
                        xObject = ((PdfIndirectReference)xObject).GetRefersTo();
                    }
                    if (xObject.IsImage())
                    {
                        PdfImageXObject image = new PdfImageXObject((PdfStream)xObject);
                        // save the image to a file
                        image.SaveAsJpeg("path/to/output.jpg");
                        Bitmap imgg = new Bitmap(image);
                        var bmp = ConvertToBitmap(image);
                    }
                }
            }
        }
    }
}