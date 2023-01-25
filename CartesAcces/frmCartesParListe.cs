using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            eleveSelectionner = new List<String>();
            nomPrenomEleve = new List<String>();
            eleveEnString();
            Eleves.DataSource = nomPrenomEleve;
            btnAjout.Click += ajoutEleve;
            btnRetirer.Click += retirerEleve;
            
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
            if (verifDoublon(Eleves.SelectedItem.ToString()))
            {
                eleveSelectionner.Add(Eleves.SelectedItem.ToString());
                            Impression.DataSource = eleveSelectionner;
            }
        }

        private void retirerEleve(object sender, EventArgs e)
        {
            eleveSelectionner.Remove(Impression.SelectedItem.ToString());
            Eleves.DataSource = nomPrenomEleve;
            Eleves.Refresh();
            Impression.ClearSelected();
        }
    }
}