using System;
using System.Drawing;
using System.Windows.Forms;

namespace CartesAcces
{
    /*
     * Cette classe permet de selectionner le niveau de la classe
     * elle stocke le niveau dans la variable globale _classe
     * et lance la barre de progression avec le cas 3
     */
    public partial class frmSelectNiveau : Form
    {
        public frmSelectNiveau()
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

            if (Globale._pasDeBar)
            {
                try
                {
                    Edition.importCarteFace(Globale._cheminFaceCarte);
                    MessageBox.Show("Import réussi");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
            else
            {
                Globale._cas = 3;
                var frmWait = new barDeProgression();
                frmWait.StartPosition = FormStartPosition.Manual;
                frmWait.Location = new Point(0, 0);
                frmWait.Show();
                frmWait.TopMost = true;
            }
        }
    }
}