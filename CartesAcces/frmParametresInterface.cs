using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartesAcces
{
    public partial class frmParametresInterface : Form
    {
        public frmParametresInterface()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
            ControlSize.SetSizeTextControl(this);
            btnBascule.Click += btnBascule_Click;
        }

        private void btnBascule_Click(object sender, EventArgs e)
        {
            Globale._estEnModeSombre = !(Globale._estEnModeSombre);
            Couleur.setCouleurFenetre(this);
            Couleur.setCouleurFenetre(Globale.accueil);
            foreach (Control control in Globale.accueil.Controls)
            {
                if (control is Panel && control.Name == "pnlMenu")
                {
                    if (Globale._estEnModeSombre)
                    {
                        control.BackColor = Color.FromArgb(255, Globale._couleurBandeauxSombre[0],
                            Globale._couleurBandeauxSombre[1], Globale._couleurBandeauxSombre[2]);
                    }
                    else
                    {
                        control.BackColor = Color.FromArgb(255, Globale._couleurBandeauxClaire[0],
                            Globale._couleurBandeauxClaire[1], Globale._couleurBandeauxClaire[2]);
                    }
                }
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {

        }
    }
}
