using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CarteAcces;
using Application = Microsoft.Office.Interop.Word.Application;

namespace CartesAcces
{
    public partial class frmCarteProvisoire : Form
    {
        public frmCarteProvisoire() // -- Main, constructeur de l'application --
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
            ControlSize.SetSizeTextControl(this);
        }

        private void changementTexte(object sender, EventArgs e)
        {
            string prenom = txtPrenom.Text;
            string nom = txtNom.Text;
                
            Edition.fondCarteSection(pbCarteFace, cbbSection);

            if (nom.Length < 15)
            {
                var font = new Font("times new roman", 28, FontStyle.Bold);
                Edition.dessineTextCarteFace(font, 250, 960, nom, pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
            }
            else
            {
                var font = new Font("times new roman", 25, FontStyle.Bold);
                Edition.dessineTextCarteFace(font, 250, 960, nom, pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
            }

            if (prenom.Length < 15)
            {
                var font = new Font("times new roman", 28, FontStyle.Bold);
                Edition.dessineTextCarteFace(font, 350, 1075, prenom, pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
            }
            else
            {
                var font = new Font("times new roman", 25, FontStyle.Bold);
                Edition.dessineTextCarteFace(font, 350, 1075, prenom, pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Edition.fondCarteSection(pbCarteFace, cbbSection);
            Edt.afficheEmploiDuTemps(cbbClasse, pbCarteArriere);
            txtPrenom.Text = "";
            txtNom.Text = "";
            groupBox2.Enabled = true;
            rdbUlis.Checked = false;
            rdbUPE2A.Checked = false;
            rdbRas.Checked = true;
        }

        // -- Lors du changement de la liste déroulante "Section" --
        private void cbbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edition.classePourSection(cbbSection, cbbClasse);
            Edition.fondCarteSection(pbCarteFace, cbbSection);
            btnReset.Enabled = true;
            txtNom.Enabled = true;
            txtPrenom.Enabled = true;
            rdbUlis.Enabled = true;
            rdbUPE2A.Enabled = true;
            rdbClRelais.Enabled = true;
            rdbRas.Enabled = true;
        }

        private void cbbClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edt.afficheEmploiDuTemps(cbbClasse, pbCarteArriere);
            btnSelect.Enabled = true;
        }

        // #### Rognage de l'emploi du temps ####
        private void btnSelect_Click(object sender, EventArgs e)
        {
            // -- Curseur en croix pour symboliser le mode selection
            Cursor = Cursors.Cross;

            // -- On est dans le mode selection
            Edition.selectionClick = true;

            // -- On peut cliquer sur rogner
            btnCrop.Enabled = true;

            btnCancel.Enabled = true;
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            var classe = cbbClasse.Text;
            var pathEdt = "./data/FichierEdtClasse/" + classe + ".png";
            Edition.selectionClick = false;
            Edt.cropEdt(pbCarteArriere, pathEdt);
            btnCrop.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // -- Le curseur revient à la normal --
            Cursor = Cursors.Default;

            // -- On est plus dans la selection --
            Edition.selectionClick = false;

            // -- On remet les paramètres et l'image de base --
            pbCarteArriere.Width = 540;
            pbCarteArriere.Height = 354;
            Edt.afficheEmploiDuTemps(cbbClasse, pbCarteArriere);
            pbCarteArriere.Refresh();
            btnCrop.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void pbCarteArriere_MouseDown(object sender, MouseEventArgs e)
        {
            // -- Si le bouton selectionné est cliqué --
            if (Edition.selectionClick)
            {
                // -- Si il y a clic gauche --
                if (e.Button == MouseButtons.Left)
                {
                    // -- On prend les coordonnées de départ --
                    Edition.cropX = e.X;
                    Edition.cropY = e.Y;
                    Edition.cropPen = new Pen(Color.Black, 1);
                    Edition.cropPen.DashStyle = DashStyle.DashDotDot;
                }

                // -- Refresh constant pour avoir un apperçu pendant la selection --
                pbCarteArriere.Refresh();
            }
        }

        private void pbCarteArriere_MouseMove(object sender, MouseEventArgs e)
        {
            // -- Si le bouton selection est cliqué --
            if (Edition.selectionClick)
            {
                // -- Si pas d'image, on sort --
                if (pbCarteArriere.Image == null)
                    return;

                // -- Glissement à la fin du premier clic gauche --
                if (e.Button == MouseButtons.Left)
                {
                    // -- On prend les dimensions a la fin du déplacement de la souris
                    pbCarteArriere.Refresh();
                    Edition.cropWidth = e.X - Edition.cropX;
                    Edition.cropHeight = e.Y - Edition.cropY;
                    pbCarteArriere.CreateGraphics().DrawRectangle(Edition.cropPen, Edition.cropX, Edition.cropY,
                        Edition.cropWidth, Edition.cropHeight);
                }
            }
        }

        // #### Ajout & Edition de la photo ####

        private void btnAjouterPhoto_Click(object sender, EventArgs e)
        {
            // -- Parcours des fichiers...
            var opf = new OpenFileDialog();

            var opfPath = "";

            opf.InitialDirectory = @"\..\..\..\CartesAcces\FichiersPHOTO";
            opf.Filter = "Images (*.png, *.jpg) | *.png; *.jpg";
            opf.FilterIndex = 1;
            opf.RestoreDirectory = true;

            if (opf.ShowDialog() == DialogResult.OK)
            {
                opfPath = opf.FileName;
                // -- Ajout de l'image dans la picturebox, celle ci devient visible
                pbPhoto.Image = new Bitmap(opfPath);
                pbPhoto.Size = new Size(110, 165);
                pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                pbPhoto.Visible = true;
            }
        }

        private void btnAnnulerPhoto_Click(object sender, EventArgs e)
        {
            // -- La picturebox redevient invisible et l'image est effacée, le cadre reviendra a la position 5,5
            pbPhoto.Visible = false;
            pbPhoto.Image = null;
            pbPhoto.Location = new Point(5, 5);
        }

        private void pbPhoto_MouseMove(object sender, MouseEventArgs e)
        {
            // -- Lorsque l'utilisateur clique sur la photo de l'élève --
            if (Edition.drag)
            {
                // -- La position de la photo change --
                pbPhoto.Left = e.X + pbPhoto.Left - Edition.posX;
                pbPhoto.Top = e.Y + pbPhoto.Top - Edition.posY;
            }
        }

        private void pbPhoto_MouseDown(object sender, MouseEventArgs e)
        {
            // -- Lorsque l'utilisateur clic, la position initiale est sauvegardée, drag passe a true
            if (e.Button == MouseButtons.Left)
            {
                Edition.posX = e.X;
                Edition.posY = e.Y;
                Edition.drag = true;
            }

            // -- Actualisation pour voir le déplacement en temps réel --
            Refresh();
        }

        private void pbPhoto_MouseUp(object sender, MouseEventArgs e)
        {
            // -- Le drag est fini lorsque le clic est relevé  --
            Edition.drag = false;
        }

        private void tkbTaillePhoto_Scroll(object sender, EventArgs e)
        {
            if (pbPhoto != null)
            {
                // -- La largeur en pixel de la photo change et prend la valeur de la trackbar
                pbPhoto.Width = tkbTaillePhoto.Value;
                pbPhoto.Height = Convert.ToInt32(tkbTaillePhoto.Value * 1.5);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                Edition.cheminImpressionFinal = diag.SelectedPath;
            }

            else
            {
                MessageBox.Show(
                    "Merci de choisir un dossier de destination pour les fichiers générés par l'application");
                return;
            }

            if (pbCarteArriere.Image != null && pbCarteFace.Image != null && pbPhoto.Image != null)
            {
                var realLocX = pbPhoto.Location.X * pbCarteArriere.Image.Width / pbCarteArriere.Width;
                var realLocY = pbPhoto.Location.Y * pbCarteArriere.Image.Height / pbCarteArriere.Height;
                var realWidth = pbPhoto.Width * pbCarteArriere.Image.Width / pbCarteArriere.Width;
                var realHeight = pbPhoto.Height * pbCarteArriere.Image.Height / pbCarteArriere.Height;

                var ObjGraphics = Graphics.FromImage(pbCarteArriere.Image);
                ObjGraphics.DrawImage(pbPhoto.Image, realLocX, realLocY, realWidth, realHeight);

                Edition.cheminImpressionFinal = Edition.cheminImpressionFinal + "\\";

                pbCarteArriere.Image.Save(Edition.cheminImpressionFinal + txtNom.Text + txtPrenom.Text + "EDT.png",
                    ImageFormat.Png);
                pbCarteFace.Image.Save(Edition.cheminImpressionFinal + txtNom.Text + txtPrenom.Text + "Carte.png",
                    ImageFormat.Png);

                var WordApp = new Application();
                WordApp.Documents.Add();
                WordApp.ActiveDocument.PageSetup.TopMargin = 15;
                WordApp.ActiveDocument.PageSetup.RightMargin = 15;
                WordApp.ActiveDocument.PageSetup.LeftMargin = 15;
                WordApp.ActiveDocument.PageSetup.BottomMargin = 15;

                var shapeCarte = WordApp.ActiveDocument.Shapes.AddPicture(
                    Edition.cheminImpressionFinal + txtNom.Text + txtPrenom.Text + "Carte.png", Type.Missing,
                    Type.Missing, Type.Missing);

                WordApp.Selection.EndKey();
                WordApp.Selection.InsertNewPage();

                var shapeEDT = WordApp.ActiveDocument.Shapes.AddPicture(
                    Edition.cheminImpressionFinal + txtNom.Text + txtPrenom.Text + "EDT.png", Type.Missing,
                    Type.Missing, Type.Missing);

                shapeCarte.Top = 0;
                shapeCarte.Left = 0;

                shapeEDT.Top = 0;
                shapeEDT.Height = shapeCarte.Height;

                File.Delete(Edition.cheminImpressionFinal + txtNom.Text + txtPrenom.Text + "EDT.png");
                File.Delete(Edition.cheminImpressionFinal + txtNom.Text + txtPrenom.Text + "Carte.png");

                WordApp.ActiveDocument.SaveAs(
                    Edition.cheminImpressionFinal + txtNom.Text + txtPrenom.Text + " Carte.doc", Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                WordApp.ActiveDocument.Close();
                WordApp.Quit();
                Marshal.FinalReleaseComObject(WordApp);

                GC.Collect();

                MessageBox.Show("Saved !");
            }
        }

        private void rdbUlis_CheckedChanged(object sender, EventArgs e)
        {
            Edition.checkMef(rdbUlis, rdbUPE2A, rdbClRelais, pbCarteFace, cbbSection, btnEdtPerso, txtNom, txtPrenom);
        }

        private void rdbUPE2A_CheckedChanged(object sender, EventArgs e)
        {
            Edition.checkMef(rdbUlis, rdbUPE2A, rdbClRelais, pbCarteFace, cbbSection, btnEdtPerso, txtNom, txtPrenom);
        }

        private void rdbRas_CheckedChanged(object sender, EventArgs e)
        {
            Edition.checkMef(rdbUlis, rdbUPE2A, rdbClRelais, pbCarteFace, cbbSection, btnEdtPerso, txtNom, txtPrenom);
        }

        private void btnEdtPerso_Click(object sender, EventArgs e)
        {
            Edt.ajouterEdtPerso(pbCarteArriere);
            groupBox2.Enabled = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void frmCarteProvisoire_Load(object sender, EventArgs e)
        {
            txtNom.TextChanged += changementTexte;
            txtPrenom.TextChanged += changementTexte;
        }
    }
}