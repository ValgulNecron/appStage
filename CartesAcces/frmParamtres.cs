using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Rectangle = System.Drawing.Rectangle;

namespace CartesAcces
{
    public partial class frmParametres : Form
    {
        // -- DLL et procédure nécéssaires pour le module d'importation du fichier PDF --
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public frmParametres()
        {
            InitializeComponent();
            initDataGrid();
            lblDateImport.Text = Properties.Settings.Default.DateImport;
        }

        // -- Obtention du chemin --
        public static string getFilePath(string file)
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, ".\\" + file + "\\");
            string sFilePath = Path.GetFullPath(sFile);

            return sFilePath;
        }

        // -- Une fois la feuille excel copiée, on récupère les classes et on les trie par niveaux --
        public static void setLesClasses()
        {

            foreach (Eleve eleve in frmAccueil.listeEleve)
            {
                string numClasse = eleve.ClasseEleve.Substring(0, 1);

                if (numClasse == "6" && !(frmAccueil.classes6eme.Contains(eleve.ClasseEleve)))
                    frmAccueil.classes6eme.Add(eleve.ClasseEleve);
                else if (numClasse == "5" && !(frmAccueil.classes5eme.Contains(eleve.ClasseEleve)))
                    frmAccueil.classes5eme.Add(eleve.ClasseEleve);
                else if (numClasse == "4" && !(frmAccueil.classes4eme.Contains(eleve.ClasseEleve)))
                    frmAccueil.classes4eme.Add(eleve.ClasseEleve);
                else if (numClasse == "3" && !(frmAccueil.classes3eme.Contains(eleve.ClasseEleve)))
                    frmAccueil.classes3eme.Add(eleve.ClasseEleve);
                else
                    frmAccueil.classesUnknown.Add(eleve.ClasseEleve);
            }

            frmAccueil.classes3eme.Sort();
            frmAccueil.classes4eme.Sort();
            frmAccueil.classes5eme.Sort();
            frmAccueil.classes6eme.Sort();

        }

        // -- Initialisation de la grille contenant la liste des élèves
        public void initDataGrid()
        {
            DataGridParametres.Columns.Clear();
            DataGridParametres.DataSource = null;
            DataGridParametres.DataSource = frmAccueil.listeEleve;
        }

        // -- Permet a l'utilisateur de donner le chemin du fichier excel a importer --
        public void setPathImportFileEXCEL(TextBox txtBox, Button valider)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files Only | *xlsx; *.xls";
                ofd.Title = "Choose the File";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtBox.Text = ofd.FileName;
                    valider.Enabled = true;
                }
            }
        }

        // -- Permet a l'utilisateur de donner le chemin du fichier PDF a importer --
        public void setPathImportFilePDF(TextBox txtBox, Button valider)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PDF Files Only | *.pdf; *.PDF";
                ofd.Title = "Choose the File";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtBox.Text = ofd.FileName;
                    valider.Enabled = true;
                }
            }
        }

        // -- Permet a l'utilisateur de donner le chemin du dossier de photo a importer
        public void setPathImportFolder(TextBox txtBox, Button valider)
        {
            FolderBrowserDialog diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                txtBox.Text = diag.SelectedPath;
                valider.Enabled = true;
            }
        }

        // -- Importation des élève (copie du fichier pdf cible vers le fichier de l'application) --
        public void importEleves()
        {
            frmAccueil.listeEleve.Clear(); // vide les objets de la liste pour ajouter les nouveaux objets par la suite afin que
            // le DataGridView écrase l'ancien importEleves()

            Excel.Application excelApplication = new Excel.Application();
            Excel.Workbook excelWorkbookDestination = excelApplication.Workbooks.Add();
            Excel.Worksheet excelWorksheetDestination = excelWorkbookDestination.Worksheets.Add();
            Excel.Range excelRangeDestination = excelWorksheetDestination.UsedRange;

            excelRangeDestination.Cells[1, 1] = "NomEleve";
            excelRangeDestination.Cells[1, 2] = "PrenomEleve";
            excelRangeDestination.Cells[1, 3] = "ClasseEleve";
            excelRangeDestination.Cells[1, 4] = "RegimeEleve";
            excelRangeDestination.Cells[1, 5] = "Option1";
            excelRangeDestination.Cells[1, 6] = "Option2";
            excelRangeDestination.Cells[1, 7] = "Option3";
            excelRangeDestination.Cells[1, 8] = "Option4";
            excelRangeDestination.Cells[1, 9] = "MEF Eleve";

            Excel.Workbook workbookOriginal = excelApplication.Workbooks.Open(txtPathEleve.Text);
            Excel.Worksheet worksheetOriginal = workbookOriginal.Worksheets[1];
            Excel.Range rangeOriginal = worksheetOriginal.UsedRange;

            int rowCount = rangeOriginal.Rows.Count;
            int j = 2;

            for (int i = 2; i < rowCount + 1; i++)
            {
                if (rangeOriginal.Cells[i, 37].Text != "")
                {
                    excelRangeDestination.Cells[j, 1] = rangeOriginal.Cells[i, 5];
                    excelRangeDestination.Cells[j, 2] = rangeOriginal.Cells[i, 7];
                    excelRangeDestination.Cells[j, 3] = rangeOriginal.Cells[i, 35];
                    excelRangeDestination.Cells[j, 4] = rangeOriginal.Cells[i, 25];
                    excelRangeDestination.Cells[j, 5] = rangeOriginal.Cells[i, 38];
                    excelRangeDestination.Cells[j, 6] = rangeOriginal.Cells[i, 42];
                    excelRangeDestination.Cells[j, 7] = rangeOriginal.Cells[i, 46];
                    excelRangeDestination.Cells[j, 8] = rangeOriginal.Cells[i, 50];

                    if (rangeOriginal.Cells[i, 34].Text.Length > 4)
                    {
                        if (rangeOriginal.Cells[i, 34].Text.Substring(5) == "ULIS")
                        {
                            excelRangeDestination.Cells[j, 9] = "ULIS";
                        }
                        else if (rangeOriginal.Cells[i, 34].Text.Substring(5) == "ELEVES ALLOPHONES")
                        {
                            excelRangeDestination.Cells[j, 9] = "UPE2A";
                        }
                        else
                        {
                            excelRangeDestination.Cells[j, 9] = "";
                        }
                    }
                    else
                    {
                        excelRangeDestination.Cells[j, 9] = "";
                    }

                    j++;
                }
            }

            string sFilePath = getFilePath("ListeEleve");

            workbookOriginal.Close();

            File.Delete(sFilePath + "ImportEleve.xls");
            excelWorkbookDestination.SaveAs(sFilePath + "ImportEleve.xls", AccessMode: Excel.XlSaveAsAccessMode.xlNoChange);
            Marshal.FinalReleaseComObject(excelRangeDestination);
            Marshal.FinalReleaseComObject(rangeOriginal);
            Marshal.FinalReleaseComObject(excelWorksheetDestination);
            Marshal.FinalReleaseComObject(worksheetOriginal);
            excelWorkbookDestination.Close();
            excelApplication.Quit();

            Properties.Settings.Default.DateImport = DateTime.Today.ToShortDateString();
            Properties.Settings.Default.Save();

            setLesEleves();
            setLesClasses();

            initDataGrid();

            GC.Collect();

            MessageBox.Show("Importation réussie !");
        }

        // -- Importation des fichier PDF (capture d'écran de chaques pages, l'utilisateur devra définir un rognage plus tard dans l'application) --
        //public void importEDT()
        //{
        //    List<string> listeExtractPDF = new List<string>();
        //    string sFilePath = txtPathEDT.Text;

        //    // -- Message d'avertissement / prévention pour le bon déroulement du programme --
        //    MessageBox.Show("Durant cette manipulation, merci de ne pas toucher a la souris.." + Environment.NewLine + "Un message vous indiquera lorsque l'importation sera terminée");

        //    // -- Nettoyage du presse papier --
        //    Clipboard.Clear();

        //    // -- Nouvel objet process --
        //    Process Adope = new Process();

        //    // -- Le process lancera le fichier pdf ciblé --
        //    Adope.StartInfo.FileName = sFilePath;
        //    Adope.StartInfo.Arguments = sFilePath;

        //    // -- Ouverture du fichier et mise en avant plan --
        //    Adope.Start();

        //    System.Threading.Thread.Sleep(3000);

        //    Adope.WaitForInputIdle();

        //    System.Threading.Thread.Sleep(3000);

        //    IntPtr s = Adope.MainWindowHandle;

        //    System.Threading.Thread.Sleep(3000);

        //    SetForegroundWindow(s);

        //    // -- L'application attendra 3s avant de passer a la suite --
        //    System.Threading.Thread.Sleep(3000);

        //    // -- Selection de tout le text de la page PDF --
        //    SendKeys.SendWait("^(a)");

        //    // -- 3s le temps que la selection se fasse --
        //    System.Threading.Thread.Sleep(3000);

        //    // -- Copie du text selectionné dans le presse papier --
        //    SendKeys.SendWait("^(c)");

        //    // -- 3s le temps de la copie .. --
        //    System.Threading.Thread.Sleep(8000);

        //    // -- Stockage de la copie dans une variable et on nettoie le presspapier --
        //    string textPDF = Clipboard.GetText();
        //    Clipboard.Clear();

        //    // !! Recherche des lignes qui nous interesse !!

        //    // -- La ligne s'arrete lorsqu'il y a un saut --
        //    int posFin = textPDF.IndexOf("\r\n");

        //    // -- On commence au premier caractère de la chaine --
        //    int posDepart = 0;

        //    // -- Tant qu'on a pas attein la fin de la variable --
        //    while (posFin != -1)
        //    {
        //        // -- Toujours vrai sauf si erreur --
        //        if (posDepart >= 0)
        //        {
        //            // -- Si la ligne contient la mention "Elève" .. --
        //            if (textPDF.Substring(posDepart, 6).Contains("Elève"))
        //            {
        //                // -- .. Alors on affecte cette ligne a la liste --
        //                listeExtractPDF.Add(textPDF.Substring(posDepart + 1, posFin - posDepart - 1));
        //            }
        //            // -- La position de départ se place au début de la ligne suivante --
        //            posDepart = posFin + 1;
        //            // -- La position de fin se place au saut de ligne de la ligne suivante --
        //            posFin = textPDF.IndexOf("\r\n", posDepart + 1);
        //        }
        //    }

        //    MessageBox.Show(listeExtractPDF.Count.ToString());

        //    // !! Comptage du nombre de page du fichier !!

        //    // -- Initialisation --
        //    int pages = 0;

        //    using (StreamReader sr = new StreamReader(File.OpenRead(sFilePath)))
        //    {

        //        Regex regex = new Regex(@"/Type\s*/Page[^s]");
        //        MatchCollection matches = regex.Matches(sr.ReadToEnd());

        //        pages = matches.Count;
        //    }

        //    // !! Captures de chaques pages du PDF !!
        //    // -- Pour elever la selection, on actualise la page --
        //    SendKeys.SendWait("{F5}");

        //    // -- 3s le temps de l'actualisation .. --
        //    System.Threading.Thread.Sleep(3000);

        //    // -- Au cas ou le fichier pdf ne soit pas ouvert directement sur la premiere page, on remonte tout en haut --
        //    for (int j = 0; j < pages; j++)
        //    {
        //        SendKeys.SendWait("{LEFT}");
        //    }

        //    // -- Pour trier les captures en fonction de niveau de l'élève --
        //    string folder = "";
        //    if (txtPathEDT.Text.Contains("3EME"))
        //    {
        //        folder = "3EME";
        //    }
        //    else if (txtPathEDT.Text.Contains("4EME"))
        //    {
        //        folder = "4EME";
        //    }
        //    else if (txtPathEDT.Text.Contains("5EME"))
        //    {
        //        folder = "5EME";
        //    }
        //    else
        //    {
        //        folder = "6EME";
        //    }

        //    // -- Nettoyage des dossiers avant enregistrement des captures --
        //    DirectoryInfo directory = new DirectoryInfo(getFilePath("FichiersEDT\\" + folder));

        //    foreach (var file in directory.GetFiles())
        //    {
        //        file.Delete();
        //    }

        //    // -- Captures --

        //    // -- Pour chaques pages du pdf --
        //    for (int i = 0; i < pages; i++)
        //    {
        //        // -- Rectangle pour determiner la résolution de l'écran de l'utilisateur --
        //        Rectangle resolution = Screen.PrimaryScreen.Bounds;

        //        // -- Nouveau bitmap, reprennant les dimensions de l'écran --
        //        Bitmap captureBitmap = new Bitmap(resolution.Width, resolution.Height, PixelFormat.Format32bppArgb);

        //        // -- Création d'un rectangle contenu une capture de l'écran actif --

        //        Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
        //        // -- Nouvel objet Graphics --
        //        Graphics captureGraphics = Graphics.FromImage(captureBitmap);

        //        // -- Copie de la capture dans le rectangle --
        //        captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

        //        /* Si jamais il y a un "/" dans la chaine de caractère servant a renommer le fichier
        //         * le programme plantera car ce n'est pas un caractère autorisé par Windows, il faut donc l'enlever..
        //         */
        //        if (listeExtractPDF[i].Contains("/"))
        //        {
        //            listeExtractPDF[i] = listeExtractPDF[i].Substring(0, listeExtractPDF[i].IndexOf("/")) + listeExtractPDF[i].Substring(listeExtractPDF[i].IndexOf("/") + 1);
        //        }

        //        // -- Destination du fichier --
        //        string FileDest = getFilePath("FichiersEDT");
        //        FileDest = FileDest + folder + "\\" + listeExtractPDF[i] + ".png";

        //        // -- Enregistrement sous format PNG --
        //        captureBitmap.Save(FileDest, ImageFormat.Png);

        //        // -- Page suivante --
        //        SendKeys.SendWait("{RIGHT}");

        //        // -- 0.3s avant de reboucler --
        //        System.Threading.Thread.Sleep(300);
        //    }

        //    MessageBox.Show("Import réussie !", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

        //}

        public void importEDT()
        {
            List<string> listeExtractPDF = new List<string>();
            string sFilePath = txtPathEDT.Text;

            // -- Message d'avertissement / prévention pour le bon déroulement du programme --
            MessageBox.Show("Durant cette manipulation, merci de ne pas toucher a la souris.." + Environment.NewLine + "Un message vous indiquera lorsque l'importation sera terminée");

            // -- Nettoyage du presse papier --
            Clipboard.Clear();

            // -- Nouvel objet process --
            Process Adope = new Process();

            // -- Le process lancera le fichier pdf ciblé --
            Adope.StartInfo.FileName = sFilePath;
            Adope.StartInfo.Arguments = sFilePath;

            // -- Ouverture du fichier et mise en avant plan --
            Adope.Start();
            IntPtr s = Adope.MainWindowHandle;
            SetForegroundWindow(s);

            // -- L'application attendra 3s avant de passer a la suite --
            System.Threading.Thread.Sleep(3000);

            // -- Selection de tout le text de la page PDF --
            SendKeys.SendWait("^(a)");

            // -- 3s le temps que la selection se fasse --
            System.Threading.Thread.Sleep(3000);

            // -- Copie du text selectionné dans le presse papier --
            SendKeys.SendWait("^(c)");

            // -- 3s le temps de la copie .. --
            System.Threading.Thread.Sleep(5000);

            // -- Stockage de la copie dans une variable et on nettoie le presspapier --
            string textPDF = Clipboard.GetText();
            Clipboard.Clear();

            // !! Recherche des lignes qui nous interesse !!

            // -- La ligne s'arrete lorsqu'il y a un saut --
            int posFin = textPDF.IndexOf("\r\n");

            // -- On commence au premier caractère de la chaine --
            int posDepart = 0;

            // -- Tant qu'on a pas attein la fin de la variable --
            while (posFin != -1)
            {
                // -- Toujours vrai sauf si erreur --
                if (posDepart >= 0)
                {
                    // -- Si la ligne contient la mention "Elève" .. -- 
                    if (textPDF.Substring(posDepart, 6).Contains("Elève"))
                    {
                        // -- .. Alors on affecte cette ligne a la liste --
                        listeExtractPDF.Add(textPDF.Substring(posDepart + 1, posFin - posDepart - 1));
                    }
                    // -- La position de départ se place au début de la ligne suivante --
                    posDepart = posFin + 1;
                    // -- La position de fin se place au saut de ligne de la ligne suivante --
                    posFin = textPDF.IndexOf("\r\n", posDepart + 1);
                }
            }

            // !! Comptage du nombre de page du fichier !!

            // -- Initialisation --
            int pages = 0;

            using (StreamReader sr = new StreamReader(File.OpenRead(sFilePath)))
            {

                Regex regex = new Regex(@"/Type\s*/Page[^s]");
                MatchCollection matches = regex.Matches(sr.ReadToEnd());

                pages = matches.Count;
            }

            // !! Captures de chaques pages du PDF !!
            // -- Pour elever la selection, on actualise la page --
            SendKeys.SendWait("{F5}");

            // -- 3s le temps de l'actualisation .. --
            System.Threading.Thread.Sleep(5000);

            // -- Au cas ou le fichier pdf ne soit pas ouvert directement sur la premiere page, on remonte tout en haut --
            for (int j = 0; j < pages; j++)
            {
                SendKeys.SendWait("{LEFT}");
            }

            // -- Pour trier les captures en fonction de niveau de l'élève --
            string folder = "";
            if (txtPathEDT.Text.Contains("3EME"))
            {
                folder = "3EME";
            }
            else if (txtPathEDT.Text.Contains("4EME"))
            {
                folder = "4EME";
            }
            else if (txtPathEDT.Text.Contains("5EME"))
            {
                folder = "5EME";
            }
            else
            {
                folder = "6EME";
            }

            // -- Nettoyage des dossiers avant enregistrement des captures --
            DirectoryInfo directory = new DirectoryInfo(getFilePath("FichiersEDT\\" + folder));

            foreach (var file in directory.GetFiles())
            {
                file.Delete();
            }

            // -- Captures --

            // -- Pour chaques pages du pdf --
            for (int i = 0; i < pages; i++)
            {
                // -- Rectangle pour determiner la résolution de l'écran de l'utilisateur --
                Rectangle resolution = Screen.PrimaryScreen.Bounds;

                // -- Nouveau bitmap, reprennant les dimensions de l'écran --
                Bitmap captureBitmap = new Bitmap(resolution.Width, resolution.Height, PixelFormat.Format32bppArgb);

                // -- Création d'un rectangle contenu une capture de l'écran actif --

                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
                // -- Nouvel objet Graphics --
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                // -- Copie de la capture dans le rectangle --
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

                /* Si jamais il y a un "/" dans la chaine de caractère servant a renommer le fichier
                 * le programme plantera car ce n'est pas un caractère autorisé par Windows, il faut donc l'enlever..
                 */
                if (listeExtractPDF[i].Contains("/"))
                {
                    listeExtractPDF[i] = listeExtractPDF[i].Substring(0, listeExtractPDF[i].IndexOf("/")) + listeExtractPDF[i].Substring(listeExtractPDF[i].IndexOf("/") + 1);
                }

                // -- Destination du fichier --
                string FileDest = getFilePath("FichiersEDT");
                FileDest = FileDest + folder + "\\" + listeExtractPDF[i] + ".png";

                // -- Enregistrement sous format PNG --
                captureBitmap.Save(FileDest, ImageFormat.Png);

                // -- Page suivante --
                SendKeys.SendWait("{RIGHT}");

                // -- 0.3s avant de reboucler --
                System.Threading.Thread.Sleep(1000);
            }

            MessageBox.Show("Import réussie !", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

        }

        // -- Importation des photo des élèves --
        public void importPhoto()
        {

            DirectoryInfo directory = new DirectoryInfo(txtPathPhoto.Text);

            foreach (var dir in directory.GetDirectories())
            {
                foreach (var file in dir.GetFiles())
                {
                    string sFilePath = getFilePath("FichiersPHOTO");

                    Image img = Image.FromFile(file.FullName);
                    string nom = file.Name;

                    img.Save(sFilePath + nom, System.Drawing.Imaging.ImageFormat.Png);
                }
            }

            MessageBox.Show("Import réussie !");
        }

        // -- La liste des élève se met a jour a chaques saisies de l'utilisateur --
        public void rechercheDataGrid()
        {
            List<Eleve> listeRecherche = new List<Eleve>();

            initDataGrid();

            foreach (DataGridViewRow row in DataGridParametres.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Value.ToString().Contains(txtRechercheDataGrid.Text))
                    {
                        Eleve eleve = new Eleve();

                        eleve.NomEleve = row.Cells[0].Value.ToString();
                        eleve.PrenomEleve = row.Cells[1].Value.ToString();
                        eleve.ClasseEleve = row.Cells[2].Value.ToString();
                        eleve.RegimeEleve = row.Cells[3].Value.ToString();
                        eleve.OptionUnEleve = row.Cells[4].Value.ToString();
                        eleve.OptionDeuxEleve = row.Cells[5].Value.ToString();
                        eleve.OptionTroisEleve = row.Cells[6].Value.ToString();
                        eleve.OptionQuatreEleve = row.Cells[7].Value.ToString();
                        eleve.MefEleve = row.Cells[8].Value.ToString();

                        listeRecherche.Add(eleve);
                    }
                }
            }

            if (listeRecherche.Count() == 0)
            {
                MessageBox.Show("Unable to find " + txtRechercheDataGrid.Text, "Not Found");
                return;
            }
            else if (txtRechercheDataGrid.Text == "")
            {
                initDataGrid();
                listeRecherche.Clear();
            }
            else
            {
                DataGridParametres.Columns.Clear();
                DataGridParametres.DataSource = null;
                DataGridParametres.DataSource = listeRecherche;
            }
        }

        // -- Pour la photo uniques --
        public string getImportPath()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Jpeg Files Only | *.jpg";
                ofd.Title = "Selectionner une photo";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return ofd.FileName;
                }
                else
                {
                    return "null";
                }
            }
        }

        // ### Controls ###

        private void btnImporterEleves_Click(object sender, EventArgs e)
        {
            setPathImportFileEXCEL(txtPathEleve, btnValiderEleve);
        }

        private void btnValiderEleve_Click(object sender, EventArgs e)
        {
            labelV.Show();
            importEleves();
            lblDateImport.Text = Properties.Settings.Default.DateImport;
            labelV.Hide();
        }

        private void btnImportEDT_Click(object sender, EventArgs e)
        {
            setPathImportFilePDF(txtPathEDT, btnValiderEDT);
        }

        private void btnValiderEDT_Click(object sender, EventArgs e)
        {
            importEDT();
        }

        private void btnImportPhoto_Click(object sender, EventArgs e)
        {
            setPathImportFolder(txtPathPhoto, btnValiderPhoto);
        }

        private void btnValiderPhoto_Click(object sender, EventArgs e)
        {
            importPhoto();
        }

        private void btnAjoutEleve_Click(object sender, EventArgs e)
        {

        }

        private void btnModifClasse_Click(object sender, EventArgs e)
        {

        }

        private void btnSupprEleve_Click(object sender, EventArgs e)
        {

        }

        private void txtRechercheDataGrid_TextChanged(object sender, EventArgs e)
        {
            rechercheDataGrid();
        }

        private void DataGridParametres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmParametres_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnImportPhotoUnique_Click(object sender, EventArgs e)
        {
            string path = getImportPath();

            if (path == "null")
            {
                MessageBox.Show("Fichier invalide !");
                return;
            }

            frmImportPhotoUnique frm = new frmImportPhotoUnique();

            frm.setLaPhoto(path);



            frm.Show();
        }
    }
}
