using System;
using System.Linq;
using System.Windows.Forms;
using CarteAccesLib;
using LinqToDB;

namespace CartesAcces
{
    /// <summary>
    ///     cette classe permet de créer un utilisateur
    ///     elle est accessible uniquement par un utilisateur admin
    ///     elle permet de créer un utilisateur avec un nom et un mot de passe
    ///     elle permet de choisir le type d'utilisateur
    /// </summary>
    public partial class FrmCreationUtilisateur : Form
    {
        /// <summary>
        ///     Constructeur de la classe
        /// </summary>
        public FrmCreationUtilisateur()
        {
            InitializeComponent();
            Couleur.SetCouleurFenetre(this);
        }

        private void btValid_Click(object sender, EventArgs e)
        {
            var user = ClassSql.Db.GetTable<Utilisateurs>()
                .FirstOrDefault(u => u.NomUtilisateur == Globale.NomUtilisateur);
            if (user.TypeUtilisateur != "admin")
            {
                MessageBox.Show(new Form {TopMost = true}, "Vous n'avez pas les droits pour créer un utilisateur");
                return;
            }

            if (tbUser.Text == "") return;

            if (tbMdp.Text != tbValidMdp.Text) return;

            if (!(Securite.ValidationPrerequisMdp(tbMdp.Text))) return;

            var userCree = new Utilisateurs();
            userCree.NomUtilisateur = tbUser.Text;
            userCree.Hash = Securite.CreationHash(tbMdp.Text);
            foreach (Control var in gbTypeUser.Controls)
            {
                var rb = var as RadioButton;
                if (rb != null && rb.Checked) userCree.TypeUtilisateur = rb.Text;
            }

            userCree.ThemeBool = false;
            userCree.Active = true;
            ClassSql.Db.InsertOrReplace(userCree);
            MessageBox.Show("Utilisateur créé avec succès");
        }

        private void frmCreationUtilisateur_Load(object sender, EventArgs e)
        {
            tbMdp.PasswordChar = '*';
            tbValidMdp.PasswordChar = '*';
        }

        private void btnSuppr_Click(object sender, EventArgs e)
        {
            var user = ClassSql.Db.GetTable<Utilisateurs>()
                .FirstOrDefault(u => u.NomUtilisateur == Globale.NomUtilisateur);
            if (user.TypeUtilisateur != "admin")
            {
                MessageBox.Show(new Form {TopMost = true}, "Vous n'avez pas les droits pour supprimer un utilisateur");
                return;
            }

            var user2 = ClassSql.Db.GetTable<Utilisateurs>()
                .FirstOrDefault(u => u.NomUtilisateur == tbUser.Text);
            user2.Active = false;
            ClassSql.Db.InsertOrReplace(user2);
            MessageBox.Show("Utilisateur supprimé avec succès");
        }
    }
}