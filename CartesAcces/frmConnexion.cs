using System;
using System.Drawing;
using System.Windows.Forms;

namespace CartesAcces
{
    public partial class frmConnexion : Form
    {
        public frmConnexion()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
            TailleCotrole.setTailleControleTexte(this);
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
                    txtMotDePasse.Text = "";
                    txtIdentifiant.Text = "";
                    foreach (Control controle in Globale._accueil.Controls)
                    {
                        if(controle is Panel && controle.Name == "pnlMenu")
                        {
                            foreach (Control controle2 in controle.Controls)
                            {
                                if (controle2 is Button)
                                {
                                    controle2.Enabled = true;
                                }
                            }
                        }
                    }
                    Globale._cas = 1;
                    var frmWait = new barDeProgression();
                    frmWait.StartPosition = FormStartPosition.Manual;
                    frmWait.Location = new Point(800, 300);
                    frmWait.Show();
                    frmWait.TopMost = true;
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
            Securite.chiffrerDossier();
        }

        private void btnDechiffre_Click(object sender, EventArgs e)
        {
            Securite.dechiffrerDossier();
        }
    }
}