﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CartesAcces
{
    public partial class frmAccueil : Form
    {
        private Form frmPassword;

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
            foreach (Control controle in Controls)
                if (controle is Panel && controle.Name == "pnlMenu")
                    foreach (Control controle2 in controle.Controls)
                        if (controle2 is Button && controle2.Name != "btnTheme")
                            controle2.Enabled = false;

            Globale.Actuelle = new FrmConnexion();
            Text = "CARTE D'ACCES - CONNEXION";
            Globale.Accueil.Invoke(new MethodInvoker(delegate { OpenChildForm(Globale.Actuelle); }));

            lblVersion.Text = "version :" + Globale.Version + " du " + Globale.VersionDate;
            var dir = new DirectoryInfo("./data/image");
            if (dir.CreationTime.Add(TimeSpan.FromDays(15)) <= DateTime.Now)
                MessageBox.Show(new Form {TopMost = true}, "15j ou plus depuis le denier import des edt");

            var dir2 = new DirectoryInfo(Chemin.CheminPhotoEleve);
            if (dir2.CreationTime.Add(TimeSpan.FromDays(15)) <= DateTime.Now)
                MessageBox.Show(new Form {TopMost = true}, "15j ou plus depuis le dernier import de photo");

            var dir3 = new DirectoryInfo(Chemin.CheminListeEleve);
            if (dir3.CreationTime.Add(TimeSpan.FromDays(15)) <= DateTime.Now)
                MessageBox.Show(new Form {TopMost = true}, "15j ou plus depuis le dernier import des listes eleves");

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
            
            var updateThread = new Thread(CheckForUpdate);
            updateThread.Start();
        }

        //Création de menu de navigation

        private void btnCreerCarte_Click(object sender, EventArgs e)
        {
            Globale.Actuelle = new frmCarteProvisoire();
            Text = "CARTE D'ACCES - CARTE PROVISOIRE";
            FrmConnexion.timer.ajoutEvenement();
            Globale.Accueil.Invoke(new MethodInvoker(delegate { OpenChildForm(Globale.Actuelle); }));
        }

        private void btnCarteParClasse_Click(object sender, EventArgs e)
        {
            Globale.Actuelle = new frmCarteParClasseNiveau();
            Text = "CARTE D'ACCES - CARTE PAR CLASSE";
            FrmConnexion.timer.ajoutEvenement();
            Globale.Accueil.Invoke(new MethodInvoker(delegate { OpenChildForm(Globale.Actuelle); }));
        }

        private void btnParametres_Click(object sender, EventArgs e)
        {
            Globale.Actuelle = new FrmImportation();
            Text = "CARTE D'ACCES - IMPORTATION";
            FrmConnexion.timer.ajoutEvenement();
            Globale.Accueil.Invoke(new MethodInvoker(delegate { OpenChildForm(Globale.Actuelle); }));
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {
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

        private void btnChangeMdp_Click(object sender, EventArgs e)
        {
            frmPassword?.Close();
            frmPassword = new frmChangeMotDePasse();
            frmPassword.Show();
        }

        private void btnAfficheListeEleve_Click(object sender, EventArgs e)
        {
            Globale.Actuelle = new frmCartesParListe();
            Text = "CARTE D'ACCES - CARTE PAR LISTE";
            FrmConnexion.timer.ajoutEvenement();
            Globale.Accueil.Invoke(new MethodInvoker(delegate { OpenChildForm(Globale.Actuelle); }));
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ValgulNecron/appStage/");
        }

        private void on_closing(object sender, FormClosingEventArgs e)
        {
            Securite.chiffrerDossier();
        }

        private void CheckForUpdate()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("User-Agent", "AutoUpdater"); // ajout de l'en-tête requis pour utiliser l'API GitHub

                var response = client.DownloadString(Globale.RepoUrl); // récupération de la réponse de l'API GitHub
                dynamic release =
                    JsonConvert
                        .DeserializeObject(response); // désérialisation de la réponse en objet dynamique

                string latestVersion = release.tag_name; // récupération de la dernière version

                if (latestVersion != Globale.Version)
                {
                    var dialogResult =
                        MessageBox.Show(
                            "Une nouvelle version est disponible. Voulez-vous la télécharger et installer la mise à jour ?",
                            "Mise à jour disponible", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // Télécharger la dernière version
                        var tempPath = Path.GetTempPath();
                        var tempFilePath = Path.Combine(tempPath, Globale.FileName);
                        client.DownloadFile(Globale.DownloadUrl, tempFilePath);

                        // Fermer l'application après une courte attente
                        Thread.Sleep(TimeSpan.FromSeconds(Globale.SecondsToWait));
                        Process.Start(tempFilePath);

                        Application.Exit();
                    }
                }
            }
        }
    }
}