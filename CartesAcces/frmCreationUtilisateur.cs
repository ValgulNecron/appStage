using System;
using System.Linq;
using System.Windows.Forms;
using LinqToDB;

namespace CartesAcces
{
    /*
     * cette classe permet de créer un utilisateur
     * elle est accessible uniquement par un utilisateur admin
     * elle permet de créer un utilisateur avec un nom et un mot de passe
     * elle permet de choisir le type d'utilisateur
     */
    public partial class frmCreationUtilisateur : Form
    {
        public frmCreationUtilisateur()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
        }

        private void btValid_Click(object sender, EventArgs e)
        {
            var user = ClassSql.Db.GetTable<Utilisateurs>()
                .FirstOrDefault(u => u.NomUtilisateur == Globale.NomUtilisateur);
            if (user.TypeUtilisateur != "admin")
            {
                MessageBox.Show("Vous n'avez pas les droits pour créer un utilisateur");
                return;
            }
            
            if (tbUser.Text == "") return;

            if (tbMdp.Text != tbValidMdp.Text) return;

            if (Securite.validationPrerequisMdp(tbMdp.Text)) return;

            var userCree = new Utilisateurs();
            userCree.NomUtilisateur = tbUser.Text;
            userCree.Hash = Securite.creationHash(tbMdp.Text);
            foreach (Control var in gbTypeUser.Controls)
            {
                var rb = var as RadioButton;
                if (rb != null && rb.Checked) userCree.TypeUtilisateur = rb.Text;
            }

            userCree.ThemeBool = false;
            ClassSql.Db.InsertOrReplace(userCree);
            MessageBox.Show("Utilisateur créé avec succès");
        }

        private void frmCreationUtilisateur_Load(object sender, EventArgs e)
        {
            tbMdp.PasswordChar = '*';
            tbValidMdp.PasswordChar = '*';
        }
    }
}