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
                Globale.section = 3;
                this.Close();
            }

            if (rdb4eme.Checked)
            {
                Globale.section = 4;
                this.Close();
            }

            if (rdb5eme.Checked)
            {
                Globale.section = 5;
                this.Close();
            }

            if (rdb6eme.Checked)
            {
                Globale.section = 6;
                this.Close();
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une section...");
            }
        }
    }
}