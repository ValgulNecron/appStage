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
            if (Securite.verificationHash(txtMotDePasse.Text, "jesaispas"))
            {
                Form frmAccueil = new Form();
                frmAccueil.Show();
                this.Close();
            }
        }
    }
}