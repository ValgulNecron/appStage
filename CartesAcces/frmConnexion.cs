using System;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using LinqToDB;

namespace CartesAcces
{
    /*
     * fenetre de connexion
     * elle permet de se connecter a l'application
     * elle stocke le nom d'utilisateur dans la variable globale _nomUtilisateur
     * et lance la barre de progression avec le cas 1
     */
    public partial class frmConnexion : Form
    {
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
                var user = ClassSql.db.GetTable<Utilisateurs>()
                    .FirstOrDefault(u => u.NomUtilisateur == txtIdentifiant.Text);
                if (txtIdentifiant.Text != user?.NomUtilisateur)
                {
                    MessageBox.Show("nom d'utilisateur ou mot de passe invalide");
                    txtIdentifiant.Text = "";
                    txtMotDePasse.Text = "";
                    return;
                }

                try
                {
                    if (Securite.verificationHash(txtMotDePasse.Text, user?.Hash))
                    {
                        Globale._estConnecter = true;
                        Globale._nomUtilisateur = txtIdentifiant.Text;
                        txtMotDePasse.Text = "";
                        txtIdentifiant.Text = "";
                        foreach (Control controle in Globale._accueil.Controls)
                            if (controle is Panel && controle.Name == "pnlMenu")
                                foreach (Control controle2 in controle.Controls)
                                    if (controle2 is Button)
                                        controle2.Enabled = true;
                        Globale._cas = 1;
                        var frmWait = new barDeProgression();
                        frmWait.StartPosition = FormStartPosition.CenterScreen;
                        frmWait.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - 
                            frmWait.Width / 2, Screen.PrimaryScreen.Bounds.Height / 50 - frmWait.Height);
                        frmWait.Show();
                        frmWait.TopMost = true;
                        Globale._actuelle = new frmImportation();
                        frmAccueil.OpenChildForm(Globale._actuelle);
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
                        log.NomUtilisateur = Globale._nomUtilisateur;
                        log.Action = "C'est connecter au logiciel";
                        log.AdMac = macAddress;
                        ClassSql.db.Insert(log);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("nom d'utilisateur ou mot de passe invalide");
                    txtMotDePasse.Text = "";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMotDePasse.Text))
            {
                MessageBox.Show("Veuillez saisir un mot de passe", ":(", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtMotDePasse.Focus();
            }
            else
            {
                Connexion();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = Securite.creationHash(maskedTextBox1.Text);
        }

        private void btnChiffre_Click(object sender, EventArgs e)
        {
            Securite.chiffrerDossier(); 
        }

        private void btnDechiffre_Click(object sender, EventArgs e)
        {
            Securite.dechiffrerDossier();
        }

        private void frmConnexion_Load(object sender, EventArgs e)
        {
            ActiveControl = txtIdentifiant;
            foreach (Control controle in Globale._accueil.Controls)
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
                    MessageBox.Show("Veuillez saisir un mot de passe", ":(", MessageBoxButtons.OK,
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