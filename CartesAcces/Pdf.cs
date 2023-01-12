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
        public static int getNbPages(string path)
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(path));
            return pdfDoc.GetNumberOfPages();
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
                PdfPage origPage = pdfDoc.GetPage(page);
                PdfDocument pdf = new PdfDocument(new PdfWriter(path));
                PdfFormXObject pageCopy = origPage.CopyAsFormXObject(pdf);
                Image image = new Image(pageCopy);
                listeImg.Add(image);
            }

            return listeImg;
        }
    }
}