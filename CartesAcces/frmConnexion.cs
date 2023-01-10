using System;
using System.Windows.Forms;

namespace CartesAcces
{
    public partial class frmConnexion : Form
    {
        public frmConnexion()
        {
            InitializeComponent();
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
                    Form frmAccueil = new frmAccueil();
                    this.Hide();
                    frmAccueil.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("mot de passe ou nom d'utilisateur invalide");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = Securite.creationHash(maskedTextBox1.Text);
        }
    }
}