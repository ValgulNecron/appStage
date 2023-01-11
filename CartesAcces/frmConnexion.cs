using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;

namespace CartesAcces
{
    public partial class frmConnexion : Form
    {
        public frmConnexion()
        {
            InitializeComponent();
            if (Globale._estEnModeSombre)
            {
                BackColor = Color.FromArgb(255, Globale._couleurDeFondSombre[0],
                    Globale._couleurDeFondSombre[1], Globale._couleurDeFondSombre[2]);
                foreach (Control controle in Controls)
                {
                    if (controle is Button)
                    {
                        Button controle2 = controle as Button;
                        controle.BackColor = Color.FromArgb(255, Globale._couleurBoutonsSombre[0],
                            Globale._couleurBoutonsSombre[1], Globale._couleurBoutonsSombre[2]);
                        controle2.FlatStyle = FlatStyle.Flat;
                    }

                    if (controle is TextBox)
                    {
                        TextBox controle2 = controle as TextBox;
                        controle.BackColor = Color.FromArgb(255, Globale._couleurTextBoxSombre[0],
                            Globale._couleurTextBoxSombre[1], Globale._couleurTextBoxSombre[2]);
                        controle2.BorderStyle = BorderStyle.None;
                    }
                    controle.ForeColor = Color.FromArgb(255, Globale._couleurDuTexteSombre[0],
                        Globale._couleurDuTexteSombre[1], Globale._couleurDuTexteSombre[2]);
                }
            }
            else
            {
                BackColor = Color.FromArgb(255, Globale._couleurDeFondClaire[0],
                    Globale._couleurDeFondClaire[1], Globale._couleurDeFondClaire[2]);
                foreach (Control controle in Controls)
                {
                    if (controle is Button)
                    {
                        Button controle2 = controle as Button;
                        controle.BackColor = Color.FromArgb(255, Globale._couleurBoutonsClaire[0],
                            Globale._couleurBoutonsClaire[1], Globale._couleurBoutonsClaire[2]);
                        controle2.FlatStyle = FlatStyle.Flat;
                    }

                    if (controle is TextBox)
                    {
                        TextBox controle2 = controle as TextBox;
                        controle.BackColor = Color.FromArgb(255, Globale._couleurTextBoxClaire[0],
                            Globale._couleurTextBoxClaire[1], Globale._couleurTextBoxClaire[2]);
                        controle2.BorderStyle = BorderStyle.None;
                    }
                    controle.ForeColor = Color.FromArgb(255, Globale._couleurDuTexteclaire[0],
                        Globale._couleurDuTexteclaire[1], Globale._couleurDuTexteclaire[2]);
                }
            }
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

        private void frmConnexion_Load(object sender, EventArgs e)
        {
            txtIdentifiant.Text = "";
            txtMotDePasse.Text = "";
        }
    }
}