using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using CarteAcces;
using CarteAccesLib;

namespace CartesAcces
{
    public partial class frmCarteProvisoire : Form
    {
        public frmCarteProvisoire() // -- Main, constructeur de l'application --
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
        }
        
        private void changementTexte(object sender, EventArgs e)
        {
            var prenom = txtPrenom.Text;
            var nom = txtNom.Text;

            Edition.fondCarteNiveau(pbCarteFace, cbbSection);

            if (nom.Length < 15)
            {
                var font = new Font("Calibri", 28, FontStyle.Bold);
                Edition.dessineTexteCarteFace(font, 250, 960, nom, pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
            }
            else
            {
                var font = new Font("Calibri", 25, FontStyle.Bold);
                Edition.dessineTexteCarteFace(font, 250, 960, nom, pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
            }

            if (prenom.Length < 15)
            {
                var font = new Font("Calibri", 28, FontStyle.Bold);
                Edition.dessineTexteCarteFace(font, 325, 1075, prenom, pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
            }
            else
            {
                var font = new Font("Calibri", 25, FontStyle.Bold);
                Edition.dessineTexteCarteFace(font, 325, 1075, prenom, pbCarteFace, cbbSection);
                pbCarteFace.Refresh();
            }

            GC.Collect();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Edition.fondCarteNiveau(pbCarteFace, cbbSection);
                Edt.afficheEmploiDuTemps(cbbClasse, pbCarteArriere);
                txtPrenom.Text = "";
                txtNom.Text = "";
                groupBox2.Enabled = true;
                rdbUlis.Checked = false;
                rdbUPE2A.Checked = false;
                rdbRas.Checked = true;
            }
            catch
            {
            }
        }

        // -- Lors du changement de la liste déroulante "Section" --
        private void cbbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnReset.Enabled = true;
                txtNom.Enabled = true;
                txtPrenom.Enabled = true;
                rdbUlis.Enabled = true;
                rdbUPE2A.Enabled = true;
                rdbClRelais.Enabled = true;
                rdbRas.Enabled = true;
                pbPhoto.Visible = false;
                pbPhoto.Image = null;
                pbPhoto.Location = new Point(5, 5);
                Edition.classePourNiveau(cbbSection, cbbClasse);
                Edition.fondCarteNiveau(pbCarteFace, cbbSection);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void cbbClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Edt.afficheEmploiDuTemps(cbbClasse, pbCarteArriere);
                btnSelect.Enabled = true;
            }
            catch
            {
            }
        }

        // #### Rognage de l'emploi du temps ####
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                // -- Curseur en croix pour symboliser le mode selection
                Cursor = Cursors.Cross;

                // -- On est dans le mode selection
                Edition.selectionClique = true;

                btnSelect.Enabled = false;
                btnCancel.Enabled = true;
            }
            catch
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                // -- Le curseur revient à la normal --
                Cursor = Cursors.Default;

                // -- On est plus dans la selection --
                Edition.selectionClique = false;

                // -- On remet les paramètres et l'image de base --
                pbCarteArriere.Width = 540;
                pbCarteArriere.Height = 354;
                Edt.afficheEmploiDuTemps(cbbClasse, pbCarteArriere);
                pbCarteArriere.Refresh();
                btnSelect.Enabled = true;
                btnCancel.Enabled = false;
            }
            catch
            {
            }
        }

        private void pbCarteArriere_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                // -- Si le bouton selectionné est cliqué --
                if (Edition.selectionClique)
                {
                    // -- Si il y a clic gauche --
                    if (e.Button == MouseButtons.Left)
                    {
                        // -- On prend les coordonnées de départ --
                        Edition.rognageX = e.X;
                        Edition.rognageY = e.Y;
                        Edition.rognagePen = new Pen(Color.Black, 1);
                        Edition.rognagePen.DashStyle = DashStyle.DashDotDot;
                    }

                    // -- Refresh constant pour avoir un apperçu pendant la selection --
                    pbCarteArriere.Refresh();
                }
            }
            catch
            {
            }
        }

        private void pbCarteArriere_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                // -- Si le bouton selection est cliqué --
                if (Edition.selectionClique)
                {
                    // -- Si pas d'image, on sort --
                    if (pbCarteArriere.Image == null)
                        return;

                    // -- Glissement à la fin du premier clic gauche --
                    if (e.Button == MouseButtons.Left)
                    {
                        // -- On prend les dimensions a la fin du déplacement de la souris
                        pbCarteArriere.Refresh();
                        Edition.rognageLargeur = e.X - Edition.rognageX;
                        Edition.rognageHauteur = e.Y - Edition.rognageY;

                        Edition.rognageLargeur = Math.Abs(Edition.rognageLargeur);
                        Edition.rognageHauteur = Math.Abs(Edition.rognageHauteur);

                        pbCarteArriere.CreateGraphics().DrawRectangle(Edition.rognagePen,
                            Math.Min(Edition.rognageX, e.X),
                            Math.Min(Edition.rognageY, e.Y),
                            Math.Abs(Edition.rognageLargeur),
                            Math.Abs(Edition.rognageHauteur));
                    }
                }
            }
            catch
            {
            }
        }

        private void pbCarteArriere_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (Edition.selectionClique)
                {
                    if(pbCarteArriere.ClientRectangle.Contains(pbCarteArriere.PointToClient(Control.MousePosition)))
                    {
                        Edition.rognageX = Math.Min(Edition.rognageX, e.X);
                        Edition.rognageY = Math.Min(Edition.rognageY, e.Y);
                        Cursor = Cursors.Default;
                        var classe = cbbClasse.Text;
                        var pathEdt = "./data/FichierEdtClasse/" + classe + ".png";
                        Edition.selectionClique = false;
                        Edt.rognageEdt(pbCarteArriere, pathEdt);
                    }
                    else
                    {
                        Cursor = Cursors.Default;
                        var classe = cbbClasse.Text;
                        var pathEdt = "./data/FichierEdtClasse/" + classe + ".png";
                        Edition.selectionClique = false;
                        pbCarteArriere.Image = Image.FromFile(pathEdt);
                        
                        Edition.rognageX = 0;
                        Edition.rognageY = 0;
                        Edition.rognageHauteur = 0;
                        Edition.rognageLargeur = 0;
                        
                        btnSelect.Enabled = true;
                        btnCancel.Enabled = false;
                    }
                }
            }
            catch
            {
            }
        }

        // #### Ajout & Edition de la photo ####

        private void btnAjouterPhoto_Click(object sender, EventArgs e)
        {
            try
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
                    // changement
                    Globale._pbPhoto = pbPhoto;
                }
            }
            catch
            {
            }
        }

        private void btnAnnulerPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                // -- La picturebox redevient invisible et l'image est effacée, le cadre reviendra a la position 5,5
                pbPhoto.Visible = false;
                pbPhoto.Image = null;
                pbPhoto.Location = new Point(5, 5);
            }
            catch
            {
            }
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

            if (e.Button == MouseButtons.Right) return;

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
            FichierWord.getDossierCarteProvisoire();
            Globale._listeSauvegardeProvisoire = new Tuple<PictureBox, PictureBox, PictureBox, TextBox, TextBox>
                (pbCarteArriere, pbPhoto, pbCarteFace, txtNom, txtPrenom);
            Globale._cas = 5;
            Globale._actuelle = this;
            // backgroundWorker
            var frmWait = new barDeProgression();
            frmWait.Show();
            frmWait.TopMost = true;
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
        }

        private void frmCarteProvisoire_Load(object sender, EventArgs e)
        {
            txtNom.TextChanged += changementTexte;
            txtPrenom.TextChanged += changementTexte;
            pbCarteArriere.MouseWheel += pictureBox1_MouseWheel;
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
        }

        private void rdbClRelais_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}