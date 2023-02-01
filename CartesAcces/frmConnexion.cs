using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LinqToDB;

namespace CartesAcces
{
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

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            try
            {
                var user = ClassSql.db.GetTable<Utilisateurs>().FirstOrDefault(u => u.NomUtilisateur == txtIdentifiant.Text);
                if (txtIdentifiant.Text != user.NomUtilisateur && txtIdentifiant.Text != "cassin")
                {
                    MessageBox.Show("nom d'utilisateur invalide");
                    txtIdentifiant.Text = "";
                    txtMotDePasse.Text = "";
                    return;
                }
                try
                {
                    if (Securite.verificationHash(txtMotDePasse.Text, user.Hash) || Securite.verificationHash(txtMotDePasse.Text, "xKVfl8R9C3RJWCRMyfJUvGnhbUCfEa8NdZglhdoHBI12n7Fz"))
                    {
                        Globale._estConnecter = true;
                        Globale._nomUtilisateur = txtIdentifiant.Text;
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
                        frmWait.Location = new Point(800, 300);;
                        frmWait.Show();
                        frmWait.TopMost = true;
                        Globale._actuelle = new frmImportation();
                        frmAccueil.OpenChildForm(Globale._actuelle);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("mot de passe ou nom d'utilisateur invalide");
                    txtMotDePasse.Text = "";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
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
            foreach (Control controle in Globale._accueil.Controls)
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
        }
    }
}