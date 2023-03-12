using System;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using CarteAccesLib;
using LinqToDB;

namespace CartesAcces
{
    /*
     * fenetre de connexion
     * elle permet de se connecter a l'application
     * elle stocke le nom d'utilisateur dans la variable globale _nomUtilisateur
     * et lance la barre de progression avec le cas 1
     */
    /// <summary>
    ///     fenetre de connexion
    ///     elle permet de se connecter a l'application
    ///     elle stocke le nom d'utilisateur dans la variable globale _nomUtilisateur
    ///     et lance la barre de progression avec le cas 1
    /// </summary>
    public partial class FrmConnexion : Form
    {
        public static Timer timer;

        /// <summary>
        ///     Constructeur de la classe
        /// </summary>
        public FrmConnexion()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);

            VisibleChanged += on_Visibility_Change;
            txtMotDePasse.PasswordChar = '*';
        }

        /// <summary>
        ///     Permet de vider les champs quand la fenetre est fermee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        private void connexion()
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
                    if (Securite.verificationHash(txtMotDePasse.Text, user?.Hash))
                    {
                        Globale.EstConnecter = true;
                        Globale.NomUtilisateur = txtIdentifiant.Text;
                        txtMotDePasse.Text = "";
                        txtIdentifiant.Text = "";
                        foreach (Control controle in Globale.Accueil.Controls)
                            if (controle is Panel && controle.Name == "pnlMenu")
                                foreach (Control controle2 in controle.Controls)
                                    if (controle2 is Button)
                                        controle2.Enabled = true;

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
                        
                        if (Globale.MotsDePasseChifffrement != "")
                        {
                            // Securite.dechiffrerDossier();

                            Globale.Cas = 1;
                            var frmWait = new BarDeProgression();
                            frmWait.StartPosition = FormStartPosition.CenterScreen;
                            frmWait.Show();
                            frmWait.TopMost = true;

                            Globale.Actuelle = new FrmImportation();
                            FrmAccueil.openChildForm(Globale.Actuelle);
                        }
                        else
                        {
                            Globale.ChangementMotDePasseChiffrement = false;
                            var mdpChiffrement = new FrmMotDePasse();
                            mdpChiffrement.ShowDialog();
                        }
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
                connexion();
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
            if (Globale.ConnectionBdd)
            {
                btnRetry.Visible = false;
                lbConnection.Text = "Connexion à la base de données réussie";
                lbConnection.ForeColor = Color.Green;
            }
            else
            {
                btnRetry.Visible = true;
                lbConnection.Text = "Connexion à la base de données échouée";
                lbConnection.ForeColor = Color.Red;
            }
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
                    connexion();
                }
            }
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            try
            {
                ClassSql.init();
                Globale.ConnectionBdd = true;
                var user = ClassSql.Db.GetTable<Utilisateurs>()
                    .FirstOrDefault();
            }
            catch (Exception exception)
            {
                Globale.ConnectionBdd = false;
                Globale.ConnectionBdd = false;
                MessageBox.Show("Connection impossible : " + exception.Message);
                MessageBox.Show("Veuiller verifier le fichier config.xml et relancer l'application");
            }
        }
    }
}