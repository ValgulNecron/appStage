using System;
using System.Windows.Forms;

namespace CartesAcces
{
    public partial class frmMotDePasse : Form
    {
        public frmMotDePasse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globale.MotsDePasseChifffrement = textBox1.Text;
            if (Globale.ChiffrementDechiffrement)
            {
                Securite.chiffrerDossier();
            }
            else
            {
                Securite.dechiffrerDossier();
            }
            Close();
        }
    }   
}