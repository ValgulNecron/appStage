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
        // ** VARIABLES : Listes des classes **
        public static List<string> classes6eme = new List<string>();
        public static List<string> classes5eme = new List<string>();
        public static List<string> classes4eme = new List<string>();
        public static List<string> classes3eme = new List<string>();
        public static List<string> classesUnknown = new List<string>();

        // ** VARIABLES : Liste d'élèves **
        public static List<Eleve> listeEleve = new List<Eleve>();

        public frmAccueil()
        {
            InitializeComponent();
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
