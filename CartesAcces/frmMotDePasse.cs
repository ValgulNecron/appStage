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
            
            Globale.Cas = 1;
            var frmWait = new barDeProgression();
            frmWait.StartPosition = FormStartPosition.CenterScreen;
            frmWait.Show();
            frmWait.TopMost = true;

            Globale.Actuelle = new frmImportation();
            frmAccueil.OpenChildForm(Globale.Actuelle);
            
            Close();
        }
    }   
}