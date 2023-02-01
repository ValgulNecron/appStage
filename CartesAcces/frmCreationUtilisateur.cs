using System;
using System.Linq;
using System.Windows.Forms;
using LinqToDB;

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
            var user = ClassSql.db.GetTable<Utilisateurs>().FirstOrDefault(u => u.NomUtilisateur == Globale._nomUtilisateur);
            if(user.TypeUtilisateur != "admin")
            {
                MessageBox.Show("Vous n'avez pas les droits pour créer un utilisateur");
                return;
            }
            if (tbUser.Text == "")
            {
                return;
            }

            if (tbMdp.Text != tbValidMdp.Text)
            {
                return;
            }

            var userCree = new Utilisateurs();
            userCree.NomUtilisateur = tbUser.Text;
            userCree.Hash = Securite.creationHash(tbMdp.Text);
            foreach (Control var in gbTypeUser.Controls)
            {
                RadioButton rb = var as RadioButton;
                if (rb != null && rb.Checked)
                {
                    userCree.TypeUtilisateur = rb.Text;
                }
            }
            userCree.ThemeBool = false;
            ClassSql.db.Insert(userCree);
        }

    }
}