using System;
using System.Windows.Forms;
using CarteAccesLib;

namespace CartesAcces
{
    /// <summary>
    ///     Form pour le mot de passe de chiffrement
    /// </summary>
    public partial class FrmMotDePasse : Form
    {
        /// <summary>
        ///     Constructeur de la classe
        /// </summary>
        public FrmMotDePasse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Globale.MotsDePasseChifffrement = textBox1.Text;
                //if(Globale.MotsDePasseChifffrement == "")
                //throw new Exception("Mot de passe vide");

                if (Globale.ChangementMotDePasseChiffrement)
                {
                }
                else
                {
                    Globale.Cas = 1;
                    var frmWait = new BarDeProgression();
                    frmWait.StartPosition = FormStartPosition.CenterScreen;
                    frmWait.Show();
                    frmWait.TopMost = true;

                    Globale.Actuelle = new FrmImportation();
                    FrmAccueil.OpenChildForm(Globale.Actuelle);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmMotDePasse_Load(object sender, EventArgs e)
        {
            Couleur.setCouleurFenetre(this);
        }
    }
}