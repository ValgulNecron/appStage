using System;
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
        /// <summary>
        ///     constructeur de la classe
        /// </summary>
        public frmSelectNiveau()
        {
            InitializeComponent();
            if (Globale.PasDeBar) rdbClassique.Visible = false;
        }

        /*
         * Cette fonction permet de valider la selection du niveau
         * elle lance la barre de progression avec le cas 3
         */
        private void btnValider_Click(object sender, EventArgs e)
        {
            if (rdb3eme.Checked)
            {
                Globale.Classe = 3;
                Close();
            }

            else if (rdb4eme.Checked)
            {
                Globale.Classe = 4;
                Close();
            }

            else if (rdb5eme.Checked)
            {
                Globale.Classe = 5;
                Close();
            }

            else if (rdb6eme.Checked)
            {
                Globale.Classe = 6;
                Close();
            }

            else if (rdbClassique.Checked)
            {
                Globale.Classe = 7;
                Close();
            }

            else
            {
                MessageBox.Show("Veuillez selectionner une section...");
            }

            if (Globale.PasDeBar)
            {
                try
                {
                    Edition.importCarteFace(Globale.CheminFaceCarte);
                    MessageBox.Show(new Form {TopMost = true}, "Import réussi");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
            else
            {
                Globale.Cas = 3;
                var frmWait = new barDeProgression();
                frmWait.StartPosition = FormStartPosition.CenterScreen;
                frmWait.Show();
                frmWait.TopMost = true;
            }
        }
    }
}