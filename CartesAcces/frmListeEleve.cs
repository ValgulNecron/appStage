using System;
using System.Windows.Forms;

namespace CartesAcces
{
    public partial class frmListeEleve : Form
    {
        public frmListeEleve()
        {
            InitializeComponent();
        }

        private void frmListeEleve_Load(object sender, EventArgs e)
        {
            Liste.DataSource = Globale.listeElevesString;
            lblNombre.Text = Globale.listeElevesString.Count.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}