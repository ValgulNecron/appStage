﻿using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using CarteAccesLib;
using CartesAcces;
using LinqToDB;

namespace AffichageLog
{
    /*
     * fenetre de connexion
     * elle permet de se connecter a l'application
     * elle stocke le nom d'utilisateur dans la variable globale _nomUtilisateur
     * et lance la barre de progression avec le cas 1
     */
    public partial class frmConnexion : Form
    {
        public static Timer timer;

        public frmConnexion()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);

            VisibleChanged += on_Visibility_Change;
            txtMotDePasse.PasswordChar = '*';
        }

        public void on_Visibility_Change(object sender, EventArgs e)
        {
            txtMotDePasse.Text = "";
            txtIdentifiant.Text = "";
        }


        /*
         * cette fonction permet de se connecter
         * elle verifie si le nom d'utilisateur existe dans la base de donnee
         * si oui elle verifie si le mot de passe est correct
         * si oui elle lance la barre de progression avec le cas 1
         * et elle stocke le nom d'utilisateur dans la variable globale _nomUtilisateur
         * et elle active les boutons du menu
         * et elle enregistre l'action dans la base de donnee
         * si non elle affiche un message d'erreur
         * et elle vide les champs
         * si le nom d'utilisateur n'existe pas elle affiche un message d'erreur
         * et elle vide les champs
         */
        private void Connexion()
        {
            try
            {
                var user = ClassSql.Db.GetTable<Utilisateurs>()
                    .FirstOrDefault(u => u.NomUtilisateur == txtIdentifiant.Text);
                if (!user.Active)
                {
                    MessageBox.Show(new Form {TopMost = true}, "Le nom d'utilisateur ou le mot de passe est invalide");
                    txtIdentifiant.Text = "";
                    txtMotDePasse.Text = "";
                    return;
                }

                if (txtIdentifiant.Text != user?.NomUtilisateur)
                {
                    MessageBox.Show(new Form {TopMost = true}, "Le nom d'utilisateur ou le mot de passe est invalide");
                    txtIdentifiant.Text = "";
                    txtMotDePasse.Text = "";
                    return;
                }

                try
                {
                    if (Securite.VerificationHash(txtMotDePasse.Text, user?.Hash))
                    {
                        Globale.EstConnecter = true;
                        Globale.NomUtilisateur = txtIdentifiant.Text;
                        txtMotDePasse.Text = "";
                        txtIdentifiant.Text = "";

                        Globale.Actuelle = new AffichageLogAction();
                        frmAccueil.OpenChildForm(Globale.Actuelle);

                        var macAddress = string.Empty;
                        foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
                            if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                                 nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&
                                nic.OperationalStatus == OperationalStatus.Up)
                            {
                                macAddress += nic.GetPhysicalAddress().ToString();
                                break;
                            }

                        var log = new LogActions();
                        log.DateAction = DateTime.Now;
                        log.NomUtilisateur = Globale.NomUtilisateur;
                        log.Action = "C'est connecter au logiciel";
                        log.AdMac = macAddress;
                        ClassSql.Db.Insert(log);
                        timer = new Timer(Globale.Accueil);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(new Form {TopMost = true}, "Le nom d'utilisateur ou le mot de passe est invalide");
                    txtMotDePasse.Text = "";
                    txtIdentifiant.Text = "";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                txtMotDePasse.Text = "";
                txtIdentifiant.Text = "";
            }
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMotDePasse.Text))
            {
                MessageBox.Show(new Form {TopMost = true}, "Veuillez saisir un mot de passe", ":(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtMotDePasse.Focus();
            }
            else
            {
                Connexion();
            }
        }

        private void frmConnexion_Load(object sender, EventArgs e)
        {
            ActiveControl = txtIdentifiant;
            foreach (Control controle in Globale.Accueil.Controls)
                if (controle is Panel && controle.Name == "pnlMenu")
                    foreach (Control controle2 in controle.Controls)
                        if (controle2 is Button && controle2.Name != "btnTheme")
                            controle2.Enabled = false;
        }


        private void txtMotDePasse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtMotDePasse.Text))
                {
                    MessageBox.Show(new Form {TopMost = true}, "Veuillez saisir un mot de passe", ":(",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtMotDePasse.Focus();
                }
                else
                {
                    Connexion();
                }
            }
        }
    }
}