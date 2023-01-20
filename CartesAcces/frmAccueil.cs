using System;
using System.Drawing;
using System.Windows.Forms;

namespace CartesAcces
{
    public partial class frmAccueil : Form
    {
        public frmAccueil()
        {
            InitializeComponent();
            ControlSize.SetSizeTextControl(this);
            Couleur.setCouleurFenetre(this);
            if (Globale._estEnModeSombre)
            {
                pnlMenu.BackColor = Color.FromArgb(255, Globale._couleurBandeauxSombre[0],
                    Globale._couleurBandeauxSombre[1], Globale._couleurBandeauxSombre[2]);
                pnlContent.BackColor = Color.FromArgb(255, Globale._couleurDeFondSombre[0],
                    Globale._couleurDeFondSombre[1], Globale._couleurDeFondSombre[2]);
            }
            else
            {
                pnlMenu.BackColor = Color.FromArgb(255, Globale._couleurBandeauxClaire[0],
                    Globale._couleurBandeauxClaire[1], Globale._couleurBandeauxClaire[2]);
                pnlContent.BackColor = Color.FromArgb(255, Globale._couleurDeFondClaire[0],
                    Globale._couleurDeFondClaire[1], Globale._couleurDeFondClaire[2]);
            }
        }

        private void OpenChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None; // pour faire stylax
            childForm.Dock = DockStyle.Fill; // le WF appelé va prendre tout l'espace du panel
            pnlContent.Controls.Add(childForm); // reprend les éléments de l'ITF du windows forms
            pnlContent.Tag = childForm; // reprend les propriétés de chaque éléments de l'ITF de la classe(WF)
            childForm.BringToFront(); // ramène la WF appélé en avant-plan pour une WF déjà appelé
            childForm.Show(); // lorsque la WF est appelé pour la première fois
        }

        private void frmAccueil_Load(object sender, EventArgs e)
        {
            var frmWait = new progressBarForm();
            frmWait.StartPosition = FormStartPosition.Manual;
            frmWait.Location = new Point(800, 300);
            frmWait.Show();
            frmWait.TopMost = true;
            lblVersion.Text = "version :" + Globale._version + " du " + Globale._versionDate;
            var time = new Timer(this);
            
            Globale.actuelle = new frmParametres();
            OpenChildForm(Globale.actuelle);
        }

        //Création de menu de navigation

        private void btnCreerCarte_Click(object sender, EventArgs e)
        {
            Globale.actuelle = new frmCarteIndividuelle();
            OpenChildForm(Globale.actuelle);
        }

        private void btnCarteParClasse_Click(object sender, EventArgs e)
        {
            Globale.actuelle = new frmMultiplesCartes();
            OpenChildForm(Globale.actuelle);
        }

        private void btnParametres_Click(object sender, EventArgs e)
        {
            Globale.actuelle = new frmParametres();
            OpenChildForm(Globale.actuelle);
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            Globale._estEnModeSombre = !Globale._estEnModeSombre;
            
            Couleur.setCouleurFenetre(this);
            Couleur.setCouleurFenetre(Globale.actuelle);
            foreach (Control control in this.Controls)
                if (control is Panel && control.Name == "pnlMenu")
                {
                    if (Globale._estEnModeSombre)
                        control.BackColor = Color.FromArgb(255, Globale._couleurBandeauxSombre[0],
                            Globale._couleurBandeauxSombre[1], Globale._couleurBandeauxSombre[2]);
                    else
                        control.BackColor = Color.FromArgb(255, Globale._couleurBandeauxClaire[0],
                            Globale._couleurBandeauxClaire[1], Globale._couleurBandeauxClaire[2]);
                }
        }

        private void btnChangeMdp_Click(object sender, EventArgs e)
        {
            frmChangeMotDePasse frmPassword = new frmChangeMotDePasse();
            frmPassword.Show();
        }

        private void btnAfficheListeEleve_Click(object sender, EventArgs e)
        {
            Globale.actuelle = new frmListeEleve();
            OpenChildForm(Globale.actuelle);
        }
    }
}