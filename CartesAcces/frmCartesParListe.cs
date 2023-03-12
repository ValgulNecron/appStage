using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CarteAccesLib;

namespace CartesAcces
{
    /// <summary>
    /// Permet de créer des cartes d'accès pour une liste d'élèves personnalisée
    /// </summary>
    public partial class FrmCartesParListe : Form
    {
        /// <summary>
        /// Liste des élèves
        /// </summary>
        public static List<Eleve> ListeEleve;
        /// <summary>
        /// Liste des élèves sélectionnés
        /// </summary>
        public static List<string> EleveSelectionner;
        /// <summary>
        /// Liste des noms et prénoms des élèves
        /// </summary>
        public static List<string> NomPrenomEleve;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public FrmCartesParListe()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
        }

        /// <summary>
        /// Convertit la liste des élèves en une liste de string
        /// </summary>
        public static void EleveEnString()
        {
            foreach (var eleve in ListeEleve)
                NomPrenomEleve.Add(eleve.NomEleve + " " + eleve.PrenomEleve + " " + eleve.ClasseEleve);
        }

        private void frmCartesParListe_Load(object sender, EventArgs e)
        {
            try
            {
                EleveSelectionner = new List<string>();
                NomPrenomEleve = new List<string>();
                ListeEleve = Globale.ListeEleve;
                EleveEnString();
                lblCount.Text = NomPrenomEleve.Count.ToString();
                Eleves.DataSource = NomPrenomEleve;
                btnAjout.Click += AjoutEleve;
                btnRetirer.Click += RetirerEleve;
                txtRecherche.TextChanged += Recheche;
                Globale.ListeEleves6Eme = new List<Eleve>();
                Globale.ListeEleves5Eme = new List<Eleve>();
                Globale.ListeEleves4Eme = new List<Eleve>();
                Globale.ListeEleves3Eme = new List<Eleve>();
                foreach (Control VARIABLE in groupBox1.Controls) (VARIABLE as RadioButton).CheckedChanged += RbChanged;

                foreach (var el in Globale.ListeEleve)
                    if (el.ClasseEleve.Substring(0, 1) == 6.ToString())
                        Globale.ListeEleves6Eme.Add(el);
                foreach (var el in Globale.ListeEleve)
                    if (el.ClasseEleve.Substring(0, 1) == 5.ToString())
                        Globale.ListeEleves5Eme.Add(el);
                foreach (var el in Globale.ListeEleve)
                    if (el.ClasseEleve.Substring(0, 1) == 4.ToString())
                        Globale.ListeEleves4Eme.Add(el);
                foreach (var el in Globale.ListeEleve)
                    if (el.ClasseEleve.Substring(0, 1) == 3.ToString())
                        Globale.ListeEleves3Eme.Add(el);
            }
            catch
            {
            }
        }

        private bool VerifDoublon(string ajout)
        {
            foreach (string selectioner in Impression.Items)
                if (selectioner == ajout)
                    return false;

            return true;
        }

        private void AjoutEleve(object sender, EventArgs e)
        {
            try
            {
                var eleve = Eleves.SelectedItem.ToString();
                if (VerifDoublon(eleve))
                {
                    EleveSelectionner.Add(eleve);
                    Impression.DataSource = null;
                    Impression.DataSource = EleveSelectionner;
                    Impression.Refresh();
                }
            }
            catch
            {
            }
        }

        private void RetirerEleve(object sender, EventArgs e)
        {
            try
            {
                EleveSelectionner.Remove(Impression.SelectedItem.ToString());
                Impression.DataSource = null;
                Impression.DataSource = EleveSelectionner;
                Eleves.Refresh();
                Impression.Refresh();
                Impression.ClearSelected();
            }
            catch
            {
            }
        }

        private void Recheche(object sender, EventArgs e)
        {
            try
            {
                var pattern = ".*" + txtRecherche.Text + ".*";
                var el = XTrie.Recherche(pattern, ListeEleve);
                if (el != null)
                {
                    lblCount.Text = el.Count.ToString();
                    Eleves.DataSource = el;
                    Eleves.Refresh();
                }
                else
                {
                    lblCount.Text = ListeEleve.Count.ToString();
                    Eleves.DataSource = NomPrenomEleve;
                    Eleves.Refresh();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Convertit une liste de string en une liste d'élèves
        /// </summary>
        /// <param name="convertir"></param>
        /// <returns></returns>
        public static List<Eleve> ConvertionListeStringEleveEnEleve(List<string> convertir)
        {
            var e = new List<Eleve>();
            foreach (var ee in convertir)
            foreach (var eee in Globale.ListeEleve)
            {
                var eeee = eee.NomEleve + " " + eee.PrenomEleve + " " + eee.ClasseEleve;
                if (ee == eeee) e.Add(eee);
            }

            return e;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                Globale.ListeEleveImpr = ConvertionListeStringEleveEnEleve(EleveSelectionner);
                Form frmMultipleCarteEdi = new FrmMultiplesCartesEdition();
                frmMultipleCarteEdi.Show();
            }
            catch
            {
            }
        }

        private void RbChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
                if ((sender as RadioButton).Checked)
                    switch ((sender as RadioButton).Name)
                    {
                        case "tout":
                            ToutF();
                            break;
                        case "Seme":
                            SemeF();
                            break;
                        case "Ceme":
                            CemeF();
                            break;
                        case "Qeme":
                            QemeF();
                            break;
                        case "Teme":
                            TemeF();
                            break;
                    }
        }

        private void ToutF()
        {
            ListeEleve = Globale.ListeEleve;
            NomPrenomEleve = new List<string>();
            EleveEnString();
            lblCount.Text = ListeEleve.Count.ToString();
            Eleves.DataSource = NomPrenomEleve;
        }

        private void SemeF()
        {
            ListeEleve = Globale.ListeEleves6Eme;
            NomPrenomEleve = new List<string>();
            EleveEnString();
            lblCount.Text = ListeEleve.Count.ToString();
            Eleves.DataSource = NomPrenomEleve;
        }

        private void CemeF()
        {
            ListeEleve = Globale.ListeEleves5Eme;
            NomPrenomEleve = new List<string>();
            EleveEnString();
            lblCount.Text = ListeEleve.Count.ToString();
            Eleves.DataSource = NomPrenomEleve;
        }

        private void QemeF()
        {
            ListeEleve = Globale.ListeEleves4Eme;
            NomPrenomEleve = new List<string>();
            EleveEnString();
            lblCount.Text = ListeEleve.Count.ToString();
            Eleves.DataSource = NomPrenomEleve;
        }

        private void TemeF()
        {
            ListeEleve = Globale.ListeEleves3Eme;
            NomPrenomEleve = new List<string>();
            EleveEnString();
            lblCount.Text = ListeEleve.Count.ToString();
            Eleves.DataSource = NomPrenomEleve;
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            txtRecherche.Text = "";
        }
    }
}