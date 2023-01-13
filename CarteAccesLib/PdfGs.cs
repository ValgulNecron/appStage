using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

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
            PdfGs.renameEdt(outputPath, path);
        }

        public static string getTextePdf(string path)
        {
            var outputFile = "output.txt";

            var process = new Process();
            process.StartInfo.FileName = "gswin32c.exe"; // or the appropriate version of the executable for your system
            process.StartInfo.Arguments =
                $"-o \"{outputFile}\" -I\"./font/a.ttg\" -sDEVICE=txtwrite -dNOPAUSE -dEncoding=ISO-8859-1 -dBATCH \"{path}\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            var file = "";
            using (var sr = new StreamReader(path, Encoding.GetEncoding("ISO-8859-1")))
            {
                string line;
                while ((line = sr.ReadLine()) != null) file += line;
            }

            return file;
        }

        public static List<string> getNomPrenomPdf(string pdftext)
        {
            List<string> listeExtractPDF = new List<string>();
                        
            // !! Recherche des lignes qui nous interesse !!
            // -- La ligne s'arrete lorsqu'il y a un saut --
            int posFin = pdftext.IndexOf("\r\n");

            // -- On commence au premier caractère de la chaine --
            int posDepart = 0;

            // -- Tant qu'on a pas attein la fin de la variable --
            while (posFin != -1)
            {
                // -- Toujours vrai sauf si erreur --
                if (posDepart >= 0)
                {
                    // -- Si la ligne contient la mention "Elève" .. -- 
                    if (pdftext.Substring(posDepart, 6).Contains("Elève"))
                    {
                        // -- .. Alors on affecte cette ligne a la liste --
                        listeExtractPDF.Add(pdftext.Substring(posDepart + 1, posFin - posDepart - 1));
                    }
                    // -- La position de départ se place au début de la ligne suivante --
                    posDepart = posFin + 1;
                    // -- La position de fin se place au saut de ligne de la ligne suivante --
                    posFin = pdftext.IndexOf("\r\n", posDepart + 1);
                }
            }

            return listeExtractPDF;
        }

        public static int getNbPagePdf()
        {
            var folderPath = "./image/";
            var fileCount = Directory.GetFiles(folderPath).Length;
            return fileCount;
        }

        public static void renameEdt(string path, string pdf)
        {
            List<string> name = new List<string>();
            name = getNomPrenomPdf(getTextePdf(pdf));
            int nb = name.Count;
            MessageBox.Show(nb.ToString());
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] infos = d.GetFiles();
            int i = 0;
            foreach(FileInfo f in infos)
            {
                string oldName = "page_" + (i + 1).ToString();
                string newName = name[i];
                File.Move(f.FullName, f.FullName.Replace(oldName, newName));
                i++;
            }
        }
    }
}