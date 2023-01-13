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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globale._estEnModeSombre = !(Globale._estEnModeSombre);
            Couleur.setCouleurFenetre(this);
            Couleur.setCouleurFenetre(Globale.accueil);

        }
    }
}
