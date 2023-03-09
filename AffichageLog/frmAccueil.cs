using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CarteAccesLib;
using CartesAcces;

namespace AffichageLog
{
    public partial class frmAccueil : Form
    {
        public frmAccueil()
        {
            InitializeComponent();
            Globale.Accueil = this;
            Couleur.setCouleurFenetre(this);
            if (Globale.EstEnModeSombre)
            {
                pnlMenu.BackColor = Color.FromArgb(255, Globale.CouleurBandeauxSombre[0],
                    Globale.CouleurBandeauxSombre[1], Globale.CouleurBandeauxSombre[2]);
                pnlContent.BackColor = Color.FromArgb(255, Globale.CouleurDeFondSombre[0],
                    Globale.CouleurDeFondSombre[1], Globale.CouleurDeFondSombre[2]);
            }
            else
            {
                pnlMenu.BackColor = Color.FromArgb(255, Globale.CouleurBandeauxClaire[0],
                    Globale.CouleurBandeauxClaire[1], Globale.CouleurBandeauxClaire[2]);
                pnlContent.BackColor = Color.FromArgb(255, Globale.CouleurDeFondClaire[0],
                    Globale.CouleurDeFondClaire[1], Globale.CouleurDeFondClaire[2]);
            }

            TailleControle.setTailleBouton(this);
            TailleControle.setTailleControleTexte(this);
        }

        public static void OpenChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None; // pour faire stylax
            childForm.Dock = DockStyle.Fill; // le WF appelé va prendre tout l'espace du panel  
            foreach (Control controle in Globale.Accueil.Controls)
                if (controle is Panel && controle.Name == "pnlContent")
                {
                    var pnlContent = (Panel) controle;
                    pnlContent.Controls.Clear();
                    pnlContent.Controls.Add(childForm);
                    pnlContent.Tag = childForm;
                    childForm.BringToFront(); // ramène la WF appélé en avant-plan pour une WF déjà appelé
                    childForm.Show(); // lorsque la WF est appelé pour la première fois
                }
        }


        private void frmAccueil_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "version :" + Globale.Version + " du " + Globale.VersionDate;
            try
            {
                var image = Image.FromFile("./data/logo.png");
                pictureBox1.Image = image;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                var image2 = Image.FromFile("./data/github.png");
                pictureBox2.Image = image2;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ValgulNecron/appStage/");
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            Globale.EstEnModeSombre = !Globale.EstEnModeSombre;

            Couleur.setCouleurFenetre(Globale.Accueil);
            Couleur.setCouleurFenetre(Globale.Actuelle);
            foreach (Control control in Controls)
                if (control is Panel && control.Name == "pnlMenu")
                {
                    if (Globale.EstEnModeSombre)
                        control.BackColor = Color.FromArgb(255, Globale.CouleurBandeauxSombre[0],
                            Globale.CouleurBandeauxSombre[1], Globale.CouleurBandeauxSombre[2]);
                    else
                        control.BackColor = Color.FromArgb(255, Globale.CouleurBandeauxClaire[0],
                            Globale.CouleurBandeauxClaire[1], Globale.CouleurBandeauxClaire[2]);
                }

            var user = new Utilisateurs();
            user.ThemeBool = Globale.EstEnModeSombre;
        }
    }
}