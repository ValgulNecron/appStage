using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CarteAccesLib;

namespace CartesAcces
{
    public partial class frmCartesParListe : Form
    {
        public static List<string> eleveSelectionner;
        public static List<string> nomPrenomEleve;

        public frmCartesParListe()
        {
            InitializeComponent();
        }

        public static void eleveEnString()
        {
            foreach (var eleve in Globale._listeEleve)
                nomPrenomEleve.Add(eleve.NomEleve + " " + eleve.PrenomEleve + " " + eleve.ClasseEleve);
        }

        private void frmCartesParListe_Load(object sender, EventArgs e)
        {
            try
            {
                eleveSelectionner = new List<string>();
                nomPrenomEleve = new List<string>();
                eleveEnString();
                Eleves.DataSource = nomPrenomEleve;
                btnAjout.Click += ajoutEleve;
                btnRetirer.Click += retirerEleve;
                txtRecherche.TextChanged += recheche;
                btnValider.Click += valider;
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
                String eleve = Eleves.SelectedItem.ToString();
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
                var el = Trie.recherche(pattern);
                if (el != null)
                {
                    Eleves.DataSource = el;
                    Eleves.Refresh();
                }
                else
                {
                    Eleves.DataSource = nomPrenomEleve;
                    Eleves.Refresh();
                }
            }
            catch
            {
            }
        }

        public static List<Eleve> convertionListeStringEleveEnEleve(List<String> convertir)
        {
            List<Eleve> e = new List<Eleve>();
            foreach (String ee in convertir)
            {
                foreach (Eleve eee in Globale._listeEleve)
                {
                    string eeee = eee.NomEleve + " " + eee.PrenomEleve + " " + eee.ClasseEleve;
                    if (ee == eeee)
                    {
                        e.Add(eee);
                    }
                }
            }
            return e;
        }

        private void valider(object sender, EventArgs e)
        {
            Globale._listeEleveImpr = convertionListeStringEleveEnEleve(eleveSelectionner);
            Form frmMultipleCarteEdi = new frmMultiplesCartesEdition();
            frmMultipleCarteEdi.Show();
        }
    }
}