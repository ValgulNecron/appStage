using System;
using System.Windows.Forms;

namespace CartesAcces
{
    public partial class frmCreationUtilisateur : Form
    {
        public frmCreationUtilisateur()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
        }

        private void btValid_Click(object sender, EventArgs e)
        {
            if (tbUser.Text == "")
            {
                return;
            }

            if (tbMdp.Text != tbValidMdp.Text)
            {
                return;
            }

            var user = new Utilisateurs();
            user.NomUtilisateur = tbUser.Text;
            user.Hash = Securite.creationHash(tbMdp.Text);
            foreach (Control var in gbTypeUser.Controls)
            {
                RadioButton rb = var as RadioButton;
                if (rb != null && rb.Checked)
                {
                    user.TypeUtilisateur = rb.Text;
                }
            }
        }
    }
}