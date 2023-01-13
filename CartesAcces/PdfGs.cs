using System.Diagnostics;
using System.IO;

namespace CartesAcces
{
    public static class PdfGs
    {
        public static void getImageFromPdf(string path, int classe)
        {
            var outputPath = "./data/image";
            switch (classe)
            {
                case 3:
                {
                    outputPath += "/3eme/";
                    break;
                }
                case 4:
                {
                    outputPath += "/4eme/";
                    break;
                }
                case 5:
                {
                    outputPath += "/5eme/";
                    break;
                }
                case 6:
                {
                    outputPath += "/6eme/";
                    break;
                }
            }

            var outputPattern = outputPath + "page_%d.jpg";

            if (Directory.Exists("./image"))
            {
                foreach (var file in Directory.GetFiles("./image")) File.Delete(file);
                Directory.Delete("./image");
            }

            Directory.CreateDirectory("./image");
            var process = new Process();
            process.StartInfo.FileName = "gswin32c.exe"; // or the appropriate version of the executable for your system
            process.StartInfo.Arguments =
                $"-o \"{outputPattern}\" -I\"./font/a.ttg\" -sDEVICE=jpeg -dJPEGQ=100 -r200 -dPDFFitPage -c \"<< /Orientation 3 >> setpagedevice\" -dPrinted=false -dNOPAUSE -dBATCH \"{path}\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
        }

        public static string getTextePdf(string path)
        {
            var outputFile = "output.txt";

            var process = new Process();
            process.StartInfo.FileName = "gswin32c.exe"; // or the appropriate version of the executable for your system
            process.StartInfo.Arguments =
                $"-o \"{outputFile}\" -I\"./font/a.ttg\" -sDEVICE=txtwrite -dNOPAUSE -dBATCH \"{path}\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            var file = "";
            using (var sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null) file = line;
            }

            return file;
        }

        public static int getNbPagePdf()
        {
            var folderPath = "./image/";
            var fileCount = Directory.GetFiles(folderPath).Length;
            return fileCount;
        }
    }
}