using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CartesAcces
{
    public partial class frmAccueil : Form
    {
        public static Timer timer;
        public frmAccueil()
        {
            InitializeComponent();
            Globale._accueil = this;
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
            TailleControle.setTailleBouton(this);
            TailleControle.setTailleControleTexte(this);
        
        }

        public static void OpenChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None; // pour faire stylax
            childForm.Dock = DockStyle.Fill; // le WF appelé va prendre tout l'espace du panel  
            foreach (Control controle in Globale._accueil.Controls)
            {
                if (controle is Panel && controle.Name == "pnlContent")
                {
                    Globale._accueil.Invoke(new MethodInvoker(delegate
                    {
                        var pnlContent = (Panel) controle;
                        pnlContent.Controls.Clear();
                        pnlContent.Controls.Add(childForm);
                        pnlContent.Tag = childForm;
                        childForm.BringToFront(); // ramène la WF appélé en avant-plan pour une WF déjà appelé
                        childForm.Show(); // lorsque la WF est appelé pour la première fois
                    }));
                } 
            }
        }

        private void frmAccueil_Load(object sender, EventArgs e)
        {
            foreach (Control controle in Controls)
            {
                if(controle is Panel && controle.Name == "pnlMenu")
                {
                    foreach (Control controle2 in controle.Controls)
                    {
                        if (controle2 is Button && controle2.Name != "btnTheme")
                        {
                            controle2.Enabled = false;
                        }
                    }
                }
            }
            Globale._actuelle = new frmConnexion();
            OpenChildForm(Globale._actuelle);
            
            lblVersion.Text = "version :" + Globale._version + " du " + Globale._versionDate;
            var dir = new DirectoryInfo("./data/image");
            if (dir.CreationTime.Add(TimeSpan.FromDays(15)) <= DateTime.Now)
            {
                MessageBox.Show("15j ou plus depuis le denier import des edt");
            }
            
            var dir2 = new DirectoryInfo(Chemin.cheminPhotoEleve);
            if (dir2.CreationTime.Add(TimeSpan.FromDays(15)) <= DateTime.Now)
            {
                MessageBox.Show("15j ou plus depuis le dernier import de photo");
            }

            var dir3 = new DirectoryInfo(Chemin.cheminListeEleve);
            if (dir3.CreationTime.Add(TimeSpan.FromDays(15)) <= DateTime.Now)
            {
                MessageBox.Show("15j ou plus depuis le dernier import des listes eleves");
            }
            
            timer = new Timer(this);
        }

        //Création de menu de navigation

        private void btnCreerCarte_Click(object sender, EventArgs e)
        {
            Globale._actuelle = new frmCarteProvisoire();
            timer.ajoutEvenement();
            OpenChildForm(Globale._actuelle);
        }

        private void btnCarteParClasse_Click(object sender, EventArgs e)
        {
            Globale._actuelle = new frmCarteParClasseNiveau();
            timer.ajoutEvenement();
            OpenChildForm(Globale._actuelle);
        }

        private void btnParametres_Click(object sender, EventArgs e)
        {
            Globale._actuelle = new frmImportation();
            timer.ajoutEvenement();
            OpenChildForm(Globale._actuelle);
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            Globale._estEnModeSombre = !Globale._estEnModeSombre;

            Couleur.setCouleurFenetre(this);
            Couleur.setCouleurFenetre(Globale._actuelle);
            foreach (Control control in Controls)
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
            var frmPassword = new frmChangeMotDePasse();
            frmPassword.Show();
        }

        private void btnAfficheListeEleve_Click(object sender, EventArgs e)
        {
            Globale._actuelle = new frmCartesParListe();
            timer.ajoutEvenement();
            OpenChildForm(Globale._actuelle);
        }
    }
}