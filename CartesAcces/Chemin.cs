﻿using System;
using System.IO;
using System.Windows.Forms;

namespace CartesAcces
{
    public static class Chemin
    {
        public static string pathListeEleve = "./data/ImportListeEleve/ImportEleve.csv";
        
        public static string pathEdtEleve6e = "./data/image/6eme/";
        public static string pathEdtEleve5e = "./data/image/5eme/";
        public static string pathEdtEleve4e = "./data/image/4eme/";
        public static string pathEdtEleve3e = "./data/image/3eeme";
    
        // -- Obtention du chemin --
        public static string getFilePath(string file)
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, ".\\" + file + "\\");
            string sFilePath = Path.GetFullPath(sFile);

            return sFilePath;
        }
        
        // -- Permet a l'utilisateur de donner le chemin du fichier excel a importer --
        public static string setPathImportFileEXCEL()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV Files Only | *.csv";
                ofd.Title = "Choose the File";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return ofd.FileName;
                }
                return "failed";
            }
        }
        
        // -- Permet a l'utilisateur de donner le chemin du fichier PDF a importer --
        public static string setPathImportFilePDF()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PDF Files Only | *.pdf; *.PDF";
                ofd.Title = "Choose the File";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return ofd.FileName;
                }
                return "failed";
            }
        }
        
        // -- Permet a l'utilisateur de donner le chemin du dossier de photo a importer
        public static string setPathImportFolder()
        {
            FolderBrowserDialog diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                return diag.SelectedPath;
            }
            return "failed";
        }
        
        
    }
}