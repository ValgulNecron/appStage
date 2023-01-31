using System;
using System.Linq;
using System.Windows.Forms;
using LinqToDB;

namespace CartesAcces
{
    public partial class frmChangeMotDePasse : Form
    {
        public frmChangeMotDePasse()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
        }

        private void frmChangeMotDePasse_Load(object sender, EventArgs e)
        {
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                var user = ClassSql.db.GetTable<Utilisateur>().FirstOrDefault(u => u.NomUtilisateur == Globale._nomUtilisateur);
                if (Securite.verificationHash(ancienMdp.Text, user.Hash))
                {
                    if (nouveauMdp.Text == nouveauMdpValid.Text)
                    {
                        user.Hash = Securite.creationHash(nouveauMdp.Text);
                        ClassSql.db.Update(user);
                        MessageBox.Show("mot de passe changé");
                        Close();
                    }
                    else
                    {   
                        MessageBox.Show("les deux mots de passe ne sont pas identiques");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}