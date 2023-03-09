using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CarteAccesLib;

namespace CartesAcces
{
    /*
     * Permet de créer des cartes d'accès pour une liste d'élèves personnalisée
     * 
     */
    public partial class frmCartesParListe : Form
    {
        public static List<Eleve> listeEleve;
        public static List<string> eleveSelectionner;
        public static List<string> nomPrenomEleve;

        public frmCartesParListe()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
        }

        public static void eleveEnString()
        {
            foreach (var eleve in listeEleve)
                nomPrenomEleve.Add(eleve.NomEleve + " " + eleve.PrenomEleve + " " + eleve.ClasseEleve);
        }

        private void frmCartesParListe_Load(object sender, EventArgs e)
        {
            try
            {
                eleveSelectionner = new List<string>();
                nomPrenomEleve = new List<string>();
                listeEleve = Globale.ListeEleve;
                eleveEnString();
                lblCount.Text = nomPrenomEleve.Count.ToString();
                Eleves.DataSource = nomPrenomEleve;
                btnAjout.Click += ajoutEleve;
                btnRetirer.Click += retirerEleve;
                txtRecherche.TextChanged += recheche;
                Globale.ListeEleves6Eme = new List<Eleve>();
                Globale.ListeEleves5Eme = new List<Eleve>();
                Globale.ListeEleves4Eme = new List<Eleve>();
                Globale.ListeEleves3Eme = new List<Eleve>();
                foreach (Control VARIABLE in groupBox1.Controls) (VARIABLE as RadioButton).CheckedChanged += rbChanged;

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

        private bool verifDoublon(string ajout)
        {
            foreach (string selectioner in Impression.Items)
                if (selectioner == ajout)
                    return false;

            return true;
        }

        private void ajoutEleve(object sender, EventArgs e)
        {
            try
            {
                var eleve = Eleves.SelectedItem.ToString();
                if (verifDoublon(eleve))
                {
                    eleveSelectionner.Add(eleve);
                    Impression.DataSource = null;
                    Impression.DataSource = eleveSelectionner;
                    Impression.Refresh();
                }
            }
            catch
            {
            }
        }

        private void retirerEleve(object sender, EventArgs e)
        {
            try
            {
                eleveSelectionner.Remove(Impression.SelectedItem.ToString());
                Impression.DataSource = null;
                Impression.DataSource = eleveSelectionner;
                Eleves.Refresh();
                Impression.Refresh();
                Impression.ClearSelected();
            }
            catch
            {
            }
        }

        private void recheche(object sender, EventArgs e)
        {
            try
            {
                var pattern = ".*" + txtRecherche.Text + ".*";
                var el = Trie.recherche(pattern, listeEleve);
                if (el != null)
                {
                    lblCount.Text = el.Count.ToString();
                    Eleves.DataSource = el;
                    Eleves.Refresh();
                }
                else
                {
                    lblCount.Text = listeEleve.Count.ToString();
                    Eleves.DataSource = nomPrenomEleve;
                    Eleves.Refresh();
                }
            }
            catch
            {
            }
        }

        public static List<Eleve> convertionListeStringEleveEnEleve(List<string> convertir)
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
                Globale.ListeEleveImpr = convertionListeStringEleveEnEleve(eleveSelectionner);
                Form frmMultipleCarteEdi = new FrmMultiplesCartesEdition();
                frmMultipleCarteEdi.Show();
            }
            catch
            {
            }
        }

        private void rbChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
                if ((sender as RadioButton).Checked)
                    switch ((sender as RadioButton).Name)
                    {
                        case "tout":
                            toutF();
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

        private void toutF()
        {
            listeEleve = Globale.ListeEleve;
            nomPrenomEleve = new List<string>();
            eleveEnString();
            lblCount.Text = listeEleve.Count.ToString();
            Eleves.DataSource = nomPrenomEleve;
        }

        private void SemeF()
        {
            listeEleve = Globale.ListeEleves6Eme;
            nomPrenomEleve = new List<string>();
            eleveEnString();
            lblCount.Text = listeEleve.Count.ToString();
            Eleves.DataSource = nomPrenomEleve;
        }

        private void CemeF()
        {
            listeEleve = Globale.ListeEleves5Eme;
            nomPrenomEleve = new List<string>();
            eleveEnString();
            lblCount.Text = listeEleve.Count.ToString();
            Eleves.DataSource = nomPrenomEleve;
        }

        private void QemeF()
        {
            listeEleve = Globale.ListeEleves4Eme;
            nomPrenomEleve = new List<string>();
            eleveEnString();
            lblCount.Text = listeEleve.Count.ToString();
            Eleves.DataSource = nomPrenomEleve;
        }

        private void TemeF()
        {
            listeEleve = Globale.ListeEleves3Eme;
            nomPrenomEleve = new List<string>();
            eleveEnString();
            lblCount.Text = listeEleve.Count.ToString();
            Eleves.DataSource = nomPrenomEleve;
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            txtRecherche.Text = "";
        }
    }
}