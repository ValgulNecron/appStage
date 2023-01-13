using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartesAcces
{
    public partial class frmImportPhotoUnique : Form
    {
        // ** VARIABLES : Pour l'édition de l'emploi du temps (rognage) **
        public bool selectionClick = false;     // -> Est ce que le bouton "Selectionner" a été cliqué ? Si oui passe à true
        public int cropX;       // -> Abscisse de départ du rognage
        public int cropY;       // -> Ordonnée de départ du rognage
        public int cropWidth;       // -> Largeur du rognage
        public int cropHeight;      // -> Hauteur du rognage
        public Pen cropPen;     // -> Stylo qui dessine le rectangle correspondant au rognage

        // ** VARIABLES : Chemin de l'image **
        string FilePath;

        public frmImportPhotoUnique()
        {
            InitializeComponent();
        }

        public void setLaPhoto(string path)
        {
            pbPhotoUnique.Image = Image.FromFile(path);
            FilePath = path;
        }

        public void cropLaPhoto()
        {
            // -- Si la largeur a rogner est trop faible, on sort --
            if (cropWidth < 1)
            {
                return;
            }

            /* -- Rectangle pour stocker l'image rognée avec les points calculés --
                Les dimensions calculées ci dessous utilisent les dimensions 920 x 604 (calcul par proportionnalité)
                qui sont celles des vrai fichier EDT !
                Cela permet d'éviter les problèmes de résolution d'image après le rognage */

            int widthSave = pbPhotoUnique.Width;
            int heightSave = pbPhotoUnique.Height;


            int cropWidthReal = (cropWidth * pbPhotoUnique.Image.Width) / pbPhotoUnique.Width;
            int cropHeightReal = (cropHeight * pbPhotoUnique.Image.Height) / pbPhotoUnique.Height;
            int cropXReal = (cropX * pbPhotoUnique.Image.Width) / pbPhotoUnique.Width;
            int cropYReal = (cropY * pbPhotoUnique.Image.Height) / pbPhotoUnique.Height;

            Rectangle rect = new Rectangle(cropXReal, cropYReal, cropWidthReal, cropHeightReal);

            // -- On stock l'image original dans un bitmap --
            Bitmap OriginalImage = new Bitmap(Bitmap.FromFile(FilePath));

            // -- Bitmap pour l'image rognée --
            Bitmap _img = new Bitmap(cropWidthReal, cropHeightReal);

            // -- Création d'un graphique depuis l'image rognée
            Graphics g = Graphics.FromImage(_img);

            // -- Attributs de l'image --
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;

            // -- On dessine l'image original, avec les dimensions rognées dans le graphique 
            g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);

            // -- Affichage dans la picturebox
            pbPhotoUnique.Image = _img;
            pbPhotoUnique.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPhotoUnique.Width = widthSave;
            pbPhotoUnique.Height = heightSave;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // -- Curseur en croix pour symboliser le mode selection
            Cursor = Cursors.Cross;

            // -- On est dans le mode selection
            selectionClick = true;

            // -- On peut cliquer sur rogner
            btnCrop.Enabled = true;

            btnCancel.Enabled = true;
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            selectionClick = false;

            cropLaPhoto();

            btnCrop.Enabled = false;
        }

        private void pbPhotoUnique_MouseDown(object sender, MouseEventArgs e)
        {
            // -- Si le bouton selectionné est cliqué --
            if (selectionClick == true)
            {
                // -- Si il y a clic gauche --
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    // -- On prend les coordonnées de départ --
                    cropX = e.X;
                    cropY = e.Y;
                    cropPen = new Pen(Color.Black, 1);
                    cropPen.DashStyle = DashStyle.DashDotDot;
                }
                // -- Refresh constant pour avoir un apperçu pendant la selection --
                pbPhotoUnique.Refresh();
            }
        }

        private void pbPhotoUnique_MouseMove(object sender, MouseEventArgs e)
        {
            // -- Si le bouton selection est cliqué --
            if (selectionClick == true)
            {
                // -- Si pas d'image, on sort --
                if (pbPhotoUnique.Image == null)
                    return;

                // -- Glissement à la fin du premier clic gauche --
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    // -- On prend les dimensions a la fin du déplacement de la souris
                    pbPhotoUnique.Refresh();
                    cropWidth = e.X - cropX;
                    cropHeight = e.Y - cropY;
                    pbPhotoUnique.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // -- Le curseur revient à la normal --
            Cursor = Cursors.Default;

            // -- On est plus dans la selection --
            selectionClick = false;

            // -- On remet les paramètres et l'image de base --
            pbPhotoUnique.Image = Image.FromFile(FilePath);
            btnCrop.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, "..\\..\\..\\FichiersPhoto\\");
            string sFilePath = Path.GetFullPath(sFile);

            if (txtNom.Text == null || txtPrenom.Text == null)
            {
                MessageBox.Show("Veuillez bien saisir le nom et le prenom de l'élève");
            }

            else
            {
                pbPhotoUnique.Image.Save(sFilePath + "\\" + txtNom.Text.ToUpper() + " " + txtPrenom.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {
            if (txtNom.Text != "" && txtPrenom.Text != "")
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void txtPrenom_TextChanged(object sender, EventArgs e)
        {
            if (txtNom.Text != "" && txtPrenom.Text != "")
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }
    }
}
