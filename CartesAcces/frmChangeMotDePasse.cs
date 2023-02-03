
using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using LinqToDB;

namespace CartesAcces
{
    /*
     * fenetre de changement de mot de passe
     * elle permet de changer le mot de passe de l'utilisateur
     * elle verifie si le mot de passe est correct
     * elle verifie si le nouveau mot de passe est different de l'ancien
     * elle verifie si le nouveau mot de passe est conforme aux prerequis
     * elle verifie si le nouveau mot de passe est identique a la confirmation
     * si oui elle modifie le mot de passe dans la base de donnee
     * et elle enregistre l'action dans la base de donnee
     * si non elle affiche un message d'erreur
     */
    public partial class frmChangeMotDePasse : Form
    {
        public frmChangeMotDePasse()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
        }

        private void frmChangeMotDePasse_Load(object sender, EventArgs e)
        {
            nouveauMdp.PasswordChar = '*';
            nouveauMdpValid.PasswordChar = '*';
            ancienMdp.PasswordChar = '*';
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                if (nouveauMdp.Text == ancienMdp.Text)
                {
                    MessageBox.Show("Le nouveau mot de passe doit être différent de l'ancien");
                    return;
                }

                if (Securite.validationPrerequisMdp(nouveauMdp.Text))
                {
                    var user = ClassSql.db.GetTable<Utilisateurs>()
                        .FirstOrDefault(u => u.NomUtilisateur == Globale._nomUtilisateur);
                    if (Securite.verificationHash(ancienMdp.Text, user.Hash))
                    {
                        if (nouveauMdp.Text == nouveauMdpValid.Text)
                        {
                            var macAddress = string.Empty;
                            foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
                                if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                                     nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&
                                    nic.OperationalStatus == OperationalStatus.Up)
                                {
                                    macAddress += nic.GetPhysicalAddress().ToString();
                                    break;
                                }

                            var log = new LogActions();
                            log.DateAction = DateTime.Now;
                            log.NomUtilisateur = Globale._nomUtilisateur;
                            log.Action = "Changement de mot de passe";
                            log.AdMac = macAddress;
                            ClassSql.db.Insert(log);
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
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}