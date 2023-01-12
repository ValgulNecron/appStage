using System.Diagnostics;
using System.IO;

namespace CartesAcces
{
    public static class PdfGs
    {
        public static void getImageFromPdf(string path)
        {
            string outputPattern = "./image/page_%d.jpg";
            
            var process = new Process();
            process.StartInfo.FileName = "gs1000w32.exe"; // or the appropriate version of the executable for your system
            process.StartInfo.Arguments = $"-o \"{outputPattern}\" -sDEVICE=jpeg -dJPEGQ=100 -dPDFFitPage -dPrinted=false -dNOPAUSE -dBATCH \"{path}\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
        }

        public static string getTextePdf(string path)
        {
            string outputFile = "output.txt";

            var process = new Process();
            process.StartInfo.FileName = "gs1000w32.exe"; // or the appropriate version of the executable for your system
            process.StartInfo.Arguments = $"-o \"{outputFile}\" -sDEVICE=txtwrite -dNOPAUSE -dBATCH \"{path}\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            string file = "";
            using(StreamReader sr = new StreamReader(path))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    file = line;
                }
            }
            return file;
        }
        
        public static int getNbPagePdf(){
            string folderPath = "./image/";
            int fileCount = Directory.GetFiles(folderPath).Length;
            return fileCount;
        }
    }
}