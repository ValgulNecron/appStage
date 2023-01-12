namespace CartesAcces
{
    public static class Pdf
    {
        public static void getText()
        {
            string path = "./1SLAM.pdf";
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(path));
            Document doc = new Document(pdfDoc);
            for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                string pageContent = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), strategy);
                Console.WriteLine(pageContent);
            }
            pdfDoc.Close();
            Console.ReadKey();
        }
    }
}