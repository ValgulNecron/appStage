using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

            var outputPattern = outputPath + "page%d.jpg";

            if (Directory.Exists(outputPath))
            {
                foreach (var file in Directory.GetFiles(outputPath))
                {
                    File.Delete(file);
                }
                Directory.Delete(outputPath);
            }

            Directory.CreateDirectory(outputPath);
            var process = new Process();
            process.StartInfo.FileName = "gswin32c.exe"; // or the appropriate version of the executable for your system
            process.StartInfo.Arguments =
                $"-o \"{outputPattern}\" -I\"./font/a.ttg\" -sDEVICE=jpeg -dJPEGQ=100 -r200 -dPDFFitPage -c \"<< /Orientation 3 >> setpagedevice\" -dPrinted=false -dNOPAUSE -dBATCH \"{path}\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            PdfGs.renameEdt(outputPath, path);
            process.WaitForExit();
        }

        public static string getTextePdf(string path)
        {
            var outputFile = "./output.txt";

            var process = new Process();
            process.StartInfo.FileName = "gswin32c.exe"; // or the appropriate version of the executable for your system
            process.StartInfo.Arguments =
                $"-o \"{outputFile}\" -I\"./font/a.ttg\" -dTextFormat=3 -sDEVICE=txtwrite -dNOPAUSE -dEncoding=ISO-8859-1 -dBATCH \"{path}\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            string file = "";
            using (var sr = new StreamReader(outputFile, Encoding.GetEncoding("ISO-8859-1")))
            {
                // string line;
                // while ((line = sr.ReadLine()) != null)
                // {
                //     file += line;
                // }
                file = File.ReadAllText(outputFile);
            }
            return file;
        }

        public static List<string> getNomPrenomPdf(string pdftext)
        {
            List<string> listeExtractPDF = new List<string>();
            
            // !! Recherche des lignes qui nous interesse !!

            // -- On commence au premier caractère de la chaine --
            int posDepart = 0;
            // -- La ligne s'arrete lorsqu'il y a un saut --
            int posFin = pdftext.IndexOf(Environment.NewLine);
            // -- Tant qu'on a pas attein la fin de la variable --
            
            while (posFin != -1)
            {
                string line = pdftext.Substring(posDepart, posFin - posDepart);
                // -- Si la ligne contient la mention "Elève" .. -- 
                if (line.Contains(" Elève "))
                {
                    line = line.Substring(line.IndexOf("Elève") + 6, line.IndexOf("-") - line.IndexOf("Elève"));
                    line = line.Replace(" ", null);
                    line = line.Replace("/", null);
                    line = line.Replace("-", null);
                    // -- .. Alors on affecte cette ligne a la liste --
                    listeExtractPDF.Add(line);
                }
                // -- La position de départ se place au début de la ligne suivante --
                posDepart = posFin + 1;
                // -- La position de fin se place au saut de ligne de la ligne suivante --
                posFin = pdftext.IndexOf("\r\n", posDepart + 1);
                // -- Toujours vrai sauf si erreur --
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
            DirectoryInfo d = new DirectoryInfo(path);
            int i = 1;
            foreach(var f in d.GetFiles())
            {
                if (f.Name.Contains("page" + i + ".jpg"))
                {
                    string oldName = "page" + i + ".jpg";
                    string newName = name[i - 1] + ".jpg";
                    File.Move(f.FullName, f.FullName.Replace(oldName,newName));
                    i++;
                }
            }
            MessageBox.Show("fini");
            
        }
    }
}