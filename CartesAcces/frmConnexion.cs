using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace CartesAcces
{
    public partial class frmConnexion : Form
    {
        public frmConnexion()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
            ControlSize.SetSizeTextControl(this);
            VisibleChanged += on_Visibility_Change;
            txtMotDePasse.PasswordChar = '*';
        }

        public void on_Visibility_Change(object sender, EventArgs e)
        {
            txtMotDePasse.Text = "";
            txtIdentifiant.Text = "";
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            /*
            if (txtIdentifiant.Text != ClassSQL.getUser())
            {
                MessageBox.Show("mot de passe ou nom d'utilisateur invalide");
                return;
            }
            */
            try
            {
                if (Securite.verificationHash(txtMotDePasse.Text, "FnSloktSNJKrygDP+NG84m6gJ3pz/zmI1Edbyb5wG/b66T/e"))
                {
                    Globale._estConnecter = true;
                    Globale.accueil = new frmAccueil();
                    txtMotDePasse.Text = "";
                    txtIdentifiant.Text = "";
                    Hide();
                    Globale.accueil.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("mot de passe ou nom d'utilisateur invalide");
                txtMotDePasse.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = Securite.creationHash(maskedTextBox1.Text);
        }

        private void btnChiffre_Click(object sender, EventArgs e)
        {
            var key = new byte[192];
            new RNGCryptoServiceProvider().GetBytes(key);
            txtIdentifiant.Text = Convert.ToBase64String(key);
            // Securite.chiffrerDossier();
        }

        private void btnDechiffre_Click(object sender, EventArgs e)
        {
            Securite.dechiffrerDossier();
        }
    }
}