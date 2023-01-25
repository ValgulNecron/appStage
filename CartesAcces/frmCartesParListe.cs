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
        }

        private void ajoutEleve(object sender, EventArgs e)
        {
            eleveSelectionner.Add(Eleves.SelectedItem.ToString());
            Impression.DataSource = eleveSelectionner;
        }
    }
}