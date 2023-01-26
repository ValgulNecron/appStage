using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CartesAcces
{
    public partial class frmCarteParClasseNiveau : Form
    {
        public frmCarteParClasseNiveau()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
        }

        private void rdbClasseSection_CheckedChanged(object sender, EventArgs e)
        {
            cbbImprClasse.Enabled = true;
            cbbImprSection.Enabled = true;
            lsbListeEleve.DataSource = null;

            btnReset.Enabled = false;
        }

        private void rdbListePerso_CheckedChanged(object sender, EventArgs e)
        {
            cbbImprClasse.Enabled = false;
            cbbImprSection.Enabled = false;
            lsbListeEleve.DataSource = null;
            
            btnReset.Enabled = true;
        }

        private void cbbImprClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            Globale._listeEleveImpr.Clear();
            var listeEleveParClasse = new List<string>();
            foreach (var eleve in Globale._listeEleve)
                if (eleve.ClasseEleve == cbbImprClasse.Text)
                {
                    listeEleveParClasse.Add(eleve.NomEleve + " " + eleve.PrenomEleve);
                    Globale._listeEleveImpr.Add(eleve);
                }

            listeEleveParClasse.Sort();
            lblCount.Text = listeEleveParClasse.Count.ToString();

            cbbImprSection.SelectedItem = null;
            lsbListeEleve.DataSource = null;
            lsbListeEleve.DataSource = listeEleveParClasse;
            btnValiderImpr.Enabled = true;
        }

        private void cbbImprSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Globale._listeEleveImpr.Clear();
            var listeEleveParSection = new List<string>();
            foreach (var eleve in Globale._listeEleve)
                if (eleve.ClasseEleve.Substring(0, 1) == cbbImprSection.Text.Substring(0, 1))
                {
                    listeEleveParSection.Add(eleve.NomEleve + " " + eleve.PrenomEleve);
                    Globale._listeEleveImpr.Add(eleve);
                }
            listeEleveParSection.Sort();
            lblCount.Text = listeEleveParSection.Count.ToString();

            cbbImprClasse.SelectedItem = null;
            lsbListeEleve.DataSource = null;
            lsbListeEleve.DataSource = listeEleveParSection;
            btnValiderImpr.Enabled = true;
        }

        private void btnCopierDataGrid_Click(object sender, EventArgs e)
        {
        }

        private void btnRechercheDataGrid_Click(object sender, EventArgs e)
        {
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
        }

        private void txtRechercheDataGrid_TextChanged(object sender, EventArgs e)
        {
        }

        private void DataGridResultats_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void DataGridResultats_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
        }

        public void btnValiderImpr_Click(object sender, EventArgs e)
        {
            var frmMultiplesCartesEdition = new frmMultiplesCartesEdition();
            frmMultiplesCartesEdition.Show();
        }

        private void frmMultiplesCartes_Load(object sender, EventArgs e)
        {
            var lesClasses = new List<string>();

            lesClasses.AddRange(Globale._classes3eme);
            lesClasses.AddRange(Globale._classes4eme);
            lesClasses.AddRange(Globale._classes5eme);
            lesClasses.AddRange(Globale._classes6eme);

            cbbImprClasse.DataSource = lesClasses;
            cbbImprClasse.SelectedItem = null;
            lblCount.Text = "";
        }
    }
}