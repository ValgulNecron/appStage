using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace CartesAcces
{
    /// <summary>
    /// Cette classe permet de récupérer des images d'un pdf
    /// </summary>
    public static class PdfGs
    {
        private static string _outputPath = "./data/image";
        
        /// <summary>
        ///  Cette fonction permet de récupérer les images d'un pdf
        /// </summary>
        /// <param name="path"></param>
        /// <param name="classe"></param>
        public static void getImageFromPdf(string path, int classe)
        {
            switch (classe)
            {
                case 3:
                {
                    _outputPath += "/3eme/";
                    break;
                }
                case 4:
                {
                    _outputPath += "/4eme/";
                    break;
                }
                case 5:
                {
                    _outputPath += "/5eme/";
                    break;
                }
                case 6:
                {
                    _outputPath += "/6eme/";
                    break;
                }
                case 7:
                {
                    _outputPath += "/classes/";
                    break;
                }
            }

            var outputPattern = _outputPath + "page%d.jpg";

            if (Directory.Exists(_outputPath))
            {
                foreach (var file in Directory.GetFiles(_outputPath)) File.Delete(file);
                Directory.Delete(_outputPath);
            }

            Directory.CreateDirectory(_outputPath);
            var process = new Process();
            process.StartInfo.FileName =
                "./data/gswin32c.exe"; // or the appropriate version of the executable for your system
            process.StartInfo.Arguments =
                $"-o \"{outputPattern}\" -I\"./font/a.ttg\" -sDEVICE=jpeg -dJPEGQ=100 -r150 -dPDFFitPage -c \"<< /Orientation 3 >> setpagedevice\" -dPrinted=false -dNOPAUSE -dBATCH \"{path}\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
        }

        /// <summary>
        /// Cette fonction permet de récupérer le texte d'un pdf
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string getTextePdf(string path)
        {
            var outputFile = "./output.txt";

            if (File.Exists(outputFile)) File.Delete(outputFile);

            var fs = File.Create(outputFile);
            fs.Close();

            var process = new Process();
            process.StartInfo.FileName = "./data/gswin32c.exe";
            process.StartInfo.Arguments =
                $"-o \"{outputFile}\" -dTextFormat=3 -sDEVICE=txtwrite -dNOPAUSE -dBATCH \"{path}\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            process.WaitForExit();

            var file = "";
            using (var sr = new StreamReader(outputFile))
            {
                file = sr.ReadToEnd();
            }

            return file;
        }

        /// <summary>
        /// Cette fonction permet de récupérer le nom et le prenom d'un eleve dans un pdf
        /// </summary>
        /// <param name="pdftext"></param>
        /// <returns></returns>
        public static List<string> getNomPrenomPdf(string pdftext)
        {
            var listeExtractPdf = new List<string>();

            // !! Recherche des lignes qui nous interesse !!

            // -- On commence au premier caractère de la chaine --
            var posDepart = 0;
            // -- La ligne s'arrete lorsqu'il y a un saut --
            var posFin = pdftext.IndexOf(Environment.NewLine, StringComparison.Ordinal);
            // -- Tant qu'on a pas attein la fin de la variable --

            while (posFin != -1)
            {
                var line = pdftext.Substring(posDepart, posFin - posDepart);
                // -- Si la ligne contient la mention "Elève" .. -- 
                if (line.Contains(" Elève "))
                {
                    line = line.Replace(" ", null);
                    line = line.Replace("/", null);
                    line = line.Replace("-", null);
                    line = line.Replace(Environment.NewLine, null);
                    line = line.Replace("Elève", null);
                    // -- .. Alors on affecte cette ligne a la liste --
                    listeExtractPdf.Add(line);
                }

                // -- La position de départ se place au début de la ligne suivante --
                posDepart = posFin + 1;
                // -- La position de fin se place au saut de ligne de la ligne suivante --
                posFin = pdftext.IndexOf("\r\n", posDepart + 1, StringComparison.Ordinal);
                // -- Toujours vrai sauf si erreur --
            }

            return listeExtractPdf;
        }

        /// <summary>
        /// Cette fonction permet de récupérer la classe d'un eleve dans un pdf
        /// </summary>
        /// <param name="pdftext"></param>
        /// <returns></returns>
        public static List<string> getClassePdf(string pdftext)
        {
            var listeExtractPdf = new List<string>();

            // !! Recherche des lignes qui nous interesse !!

            // -- On commence au premier caractère de la chaine --
            var posDepart = 0;
            // -- La ligne s'arrete lorsqu'il y a un saut --
            var posFin = pdftext.IndexOf(Environment.NewLine, StringComparison.Ordinal);
            // -- Tant qu'on a pas attein la fin de la variable --

            while (posFin != -1)
            {
                var line = pdftext.Substring(posDepart, posFin - posDepart);
                // -- Si la ligne contient la mention "Classe" .. -- 
                if (line.Contains("Classe"))
                {
                    line = line.Replace(" ", null);
                    line = line.Replace("/", null);
                    line = line.Replace("-", null);
                    line = line.Replace(Environment.NewLine, null);
                    line = line.Replace("Classe", null);
                    // -- .. Alors on affecte cette ligne a la liste --
                    listeExtractPdf.Add(line);
                }

                // -- La position de départ se place au début de la ligne suivante --
                posDepart = posFin + 1;
                // -- La position de fin se place au saut de ligne de la ligne suivante --
                posFin = pdftext.IndexOf("\r\n", posDepart + 1, StringComparison.Ordinal);
                // -- Toujours vrai sauf si erreur --
            }

            return listeExtractPdf;
        }

        /// <summary>
        /// Cette fonction permet de renommer les edt
        /// </summary>
        /// <param name="pdf"></param>
        public static void renameEdt(string pdf)
        {
            var name = new List<string>();

            if (Globale.Classe == 7)
                name = getClassePdf(getTextePdf(pdf));
            else
                name = getNomPrenomPdf(getTextePdf(pdf));
            MessageBox.Show(new Form {TopMost = true}, name.Count
                                                       + " emplois de temps ont été importés");
            var d = new DirectoryInfo(_outputPath);
            var infos = d.GetFiles();

            for (var i = 0; i < infos.Length; i++)
            {
                var nameWithoutExt = infos[i].Name.Substring(0, infos[i].Name.Length - 4);
                var index = nameWithoutExt.Substring(4, nameWithoutExt.Length - 4);
                var indexInt = Convert.ToInt32(index);

                var oldName = nameWithoutExt;
                var newName = name[indexInt - 1].Trim();
                File.Move(infos[i].FullName, infos[i].FullName.Replace(oldName, newName));
            }
        }

        /// <summary>
        /// Cette fonction permet de récupérer la date de la dernière importation
        /// </summary>
        /// <returns></returns>
        public static string getDateFile()
        {
            var dateFile = "Aucune Importation";
            var dir = new DirectoryInfo(_outputPath);
            if (dir.Exists) dateFile = dir.CreationTime.ToString(CultureInfo.InvariantCulture);

            return dateFile;
        }

        /// <summary>
        /// Cette fonction permet de remettre les valeurs par défaut
        /// </summary>
        public static void valeurParDefault()
        {
            _outputPath = "./data/image";
        }
    }
}