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
        public frmImportPhotoUnique()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // -- Curseur en croix pour symboliser le mode selection
            Cursor = Cursors.Cross;

            // -- On est dans le mode selection
            Photo.selectionClick = true;

            // -- On peut cliquer sur rogner
            btnCrop.Enabled = true;

            btnCancel.Enabled = true;
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Photo.selectionClick = false;

            Photo.cropLaPhoto(pbPhotoUnique);

            btnCrop.Enabled = false;
        }

        private void pbPhotoUnique_MouseDown(object sender, MouseEventArgs e)
        {
            // -- Si le bouton selectionné est cliqué --
            if (Photo.selectionClick == true)
            {
                // -- Si il y a clic gauche --
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    // -- On prend les coordonnées de départ --
                    Photo.cropX = e.X;
                    Photo.cropY = e.Y;
                    Photo.cropPen = new Pen(Color.Black, 1);
                    Photo.cropPen.DashStyle = DashStyle.DashDotDot;
                }
                // -- Refresh constant pour avoir un apperçu pendant la selection --
                pbPhotoUnique.Refresh();
            }
        }

        private void pbPhotoUnique_MouseMove(object sender, MouseEventArgs e)
        {
            // -- Si le bouton selection est cliqué --
            if (Photo.selectionClick == true)
            {
                // -- Si pas d'image, on sort --
                if (pbPhotoUnique.Image == null)
                    return;

                // -- Glissement à la fin du premier clic gauche --
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    // -- On prend les dimensions a la fin du déplacement de la souris
                    pbPhotoUnique.Refresh();
                    Photo.cropWidth = e.X - Photo.cropX;
                    Photo.cropHeight = e.Y - Photo.cropY;
                    pbPhotoUnique.CreateGraphics().DrawRectangle(Photo.cropPen, Photo.cropX, Photo.cropY, Photo.cropWidth, Photo.cropHeight);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // -- Le curseur revient à la normal --
            Cursor = Cursors.Default;

            // -- On est plus dans la selection --
            Photo.selectionClick = false;

            // -- On remet les paramètres et l'image de base --
            pbPhotoUnique.Image = Image.FromFile(Photo.FilePath);
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
