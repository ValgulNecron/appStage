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
                    Impression = new ListBox();
                    eleveSelectionner.Add(eleve);
                    Impression.DataSource = eleveSelectionner;
                    Impression.Refresh();
                    MessageBox.Show(eleveSelectionner.Count.ToString());
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
                Eleves.DataSource = nomPrenomEleve;
                Eleves.Refresh();
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
    }
}