using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CarteAccesLib;

namespace CartesAcces
{
    public partial class frmCartesParListe : Form
    {
        public static List<String> eleveSelectionner;
        public static List<String> nomPrenomEleve;
        public frmCartesParListe()
        {
            InitializeComponent();
        }

        public static void eleveEnString()
        {
            foreach (Eleve eleve in Globale._listeEleve)
            {
                nomPrenomEleve.Add(eleve.NomEleve + " " + eleve.PrenomEleve + " " + eleve.ClasseEleve);
            }
        }

        private void frmCartesParListe_Load(object sender, EventArgs e)
        {
            try
            {
                eleveSelectionner = new List<String>();
                nomPrenomEleve = new List<String>();
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
            {
                if (selectioner == ajout)
                    return false;
            }
            
            return true;
        }
        
        private void ajoutEleve(object sender, EventArgs e)
        {
            try
            {
                string eleve = Eleves.SelectedItem.ToString();
                if (verifDoublon(eleve))
                {
                    eleveSelectionner.Add(eleve);
                    Impression.DataSource = eleveSelectionner;
                }
            }
            catch
            {

            }
            
        }

        private void retirerEleve(object sender, EventArgs e)
        {
            eleveSelectionner.Remove(Impression.SelectedItem.ToString());
            Eleves.DataSource = nomPrenomEleve;
            Eleves.Refresh();
            Impression.ClearSelected();
        }

        private void recheche(object sender, EventArgs e)
        {
            List<String> el = Trie.recherche(txtRecherche.Text);
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
    }
}