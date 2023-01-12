using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CartesAcces
{
    public partial class frmAccueil : Form
    {
        public frmAccueil()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
            if (Globale._estEnModeSombre)
            {
                pnlMenu.BackColor = Color.FromArgb(255, Globale._couleurBandeauxSombre[0],
                    Globale._couleurBandeauxSombre[1], Globale._couleurBandeauxSombre[2]);
            }
            else
            {
                pnlMenu.BackColor = Color.FromArgb(255, Globale._couleurBandeauxClaire[0],
                    Globale._couleurBandeauxClaire[1], Globale._couleurBandeauxClaire[2]);
            }
        }

        private void OpenChildForm(Form childForm)
        {
            childForm.TopLevel = false; 
            childForm.FormBorderStyle = FormBorderStyle.None; // pour faire stylax
            childForm.Dock = DockStyle.Fill; // le WF appelé va prendre tout l'espace du panel
            pnlContent.Controls.Add(childForm); // reprend les éléments de l'ITF du windows forms
            pnlContent.Tag = childForm; // reprend les propriétés de chaque éléments de l'ITF de la classe(WF)
            childForm.BringToFront(); // ramène la WF appélé en avant-plan pour une WF déjà appelé
            childForm.Show(); // lorsque la WF est appelé pour la première fois
        }

        private void frmAccueil_Load(object sender, EventArgs e)
        {
            progressBarForm frmWait = new progressBarForm();
            frmWait.StartPosition = FormStartPosition.Manual;
            frmWait.Location = new Point(800, 300);
            frmWait.Show();
            frmWait.TopMost = true;
        }

        //Création de menu de navigation

        private void btnCreerCarte_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCarteIndividuelle());
        }

        private void btnCarteParClasse_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMultiplesCartes());
        }

        private void btnParametres_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmParametres());
        }

        private void btnAccueil_Click(object sender, EventArgs e)
        {
  
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
