using System;
using System.Windows.Forms;

namespace CartesAcces
{
    public partial class frmSelectSection : Form
    {
        public frmSelectSection()
        {
            InitializeComponent();
        }


        private void btnValider_Click(object sender, EventArgs e)
        {
            if (rdb3eme.Checked)
            {
                Globale._classe = 3;
                Close();
            }

            else if (rdb4eme.Checked)
            {
                Globale._classe = 4;
                Close();
            }

            else if (rdb5eme.Checked)
            {
                Globale._classe = 5;
                Close();
            }

            else if (rdb6eme.Checked)
            {
                Globale._classe = 6;
                Close();
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une section...");
            }
        }
    }
}