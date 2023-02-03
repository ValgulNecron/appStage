﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CartesAcces
{
    public partial class frmAccueil : Form
    {
        public static Timer timer;
        private Form frmPassword;

        public frmAccueil()
        {
            InitializeComponent();
            Globale._accueil = this;
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
            foreach (Control controle in Globale._accueil.Controls)
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
            foreach (Control controle in Controls)
                if (controle is Panel && controle.Name == "pnlMenu")
                    foreach (Control controle2 in controle.Controls)
                        if (controle2 is Button && controle2.Name != "btnTheme")
                            controle2.Enabled = false;

            Globale._actuelle = new frmConnexion();
            Text = "CARTE D'ACCES - CONNEXION";
            Globale._accueil.Invoke(new MethodInvoker(delegate { OpenChildForm(Globale._actuelle); }));

            lblVersion.Text = "version :" + Globale._version + " du " + Globale._versionDate;
            var dir = new DirectoryInfo("./data/image");
            if (dir.CreationTime.Add(TimeSpan.FromDays(15)) <= DateTime.Now)
                MessageBox.Show("15j ou plus depuis le denier import des edt");

            var dir2 = new DirectoryInfo(Chemin.CheminPhotoEleve);
            if (dir2.CreationTime.Add(TimeSpan.FromDays(15)) <= DateTime.Now)
                MessageBox.Show("15j ou plus depuis le dernier import de photo");

            var dir3 = new DirectoryInfo(Chemin.CheminListeEleve);
            if (dir3.CreationTime.Add(TimeSpan.FromDays(15)) <= DateTime.Now)
                MessageBox.Show("15j ou plus depuis le dernier import des listes eleves");
            
            timer = new Timer(this);

            try
            {
                var image = Image.FromFile("./data/FichierCartesFace/logo.png");
                pictureBox1.Image = image;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        //Création de menu de navigation

        private void btnCreerCarte_Click(object sender, EventArgs e)
        {
            Globale._actuelle = new frmCarteProvisoire();
            Text = "CARTE D'ACCES - CARTE PROVISOIRE";
            timer.ajoutEvenement();
            Globale._accueil.Invoke(new MethodInvoker(delegate { OpenChildForm(Globale._actuelle); }));
        }

        private void btnCarteParClasse_Click(object sender, EventArgs e)
        {
            Globale._actuelle = new frmCarteParClasseNiveau();
            Text = "CARTE D'ACCES - CARTE PAR CLASSE";
            timer.ajoutEvenement();
            Globale._accueil.Invoke(new MethodInvoker(delegate { OpenChildForm(Globale._actuelle); }));
        }

        private void btnParametres_Click(object sender, EventArgs e)
        {
            Globale._actuelle = new frmImportation();
            Text = "CARTE D'ACCES - IMPORTATION";
            timer.ajoutEvenement();
            Globale._accueil.Invoke(new MethodInvoker(delegate { OpenChildForm(Globale._actuelle); }));
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            Globale.EstEnModeSombre = !Globale.EstEnModeSombre;

            Couleur.setCouleurFenetre(this);
            Couleur.setCouleurFenetre(Globale._actuelle);
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

        private void btnChangeMdp_Click(object sender, EventArgs e)
        {
            frmPassword?.Close();
            frmPassword = new frmChangeMotDePasse();
            frmPassword.Show();
        }

        private void btnAfficheListeEleve_Click(object sender, EventArgs e)
        {
            Globale._actuelle = new frmCartesParListe();
            Text = "CARTE D'ACCES - CARTE PAR LISTE";
            timer.ajoutEvenement();
            Globale._accueil.Invoke(new MethodInvoker(delegate { OpenChildForm(Globale._actuelle); }));
        }
    }
}