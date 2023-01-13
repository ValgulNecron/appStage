using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace CartesAcces
{
    public partial class frmMultiplesCartes : Form
    {
        public frmMultiplesCartes()
        {
            InitializeComponent();
        }
        
        private void rdbClasseSection_CheckedChanged(object sender, EventArgs e)
        {
            cbbImprClasse.Enabled = true;
            cbbImprSection.Enabled = true;
            lsbListeEleve.DataSource = null;

            txtRechercheDataGrid.Enabled = false;
            btnRechercheDataGrid.Enabled = false;
            btnCopierDataGrid.Enabled = false;
            btnReset.Enabled = false;
            DataGridParametres.Enabled = false;
            DataGridResultats.Enabled = false;
            DataGridParametres.DataSource = null;
        }

        private void rdbListePerso_CheckedChanged(object sender, EventArgs e)
        {
            cbbImprClasse.Enabled = false;
            cbbImprSection.Enabled = false;
            lsbListeEleve.DataSource = null;

            txtRechercheDataGrid.Enabled = true;
            btnRechercheDataGrid.Enabled = true;
            btnCopierDataGrid.Enabled = true;
            btnReset.Enabled = true;
            DataGridParametres.Enabled = true;
            DataGridResultats.Enabled = true;
            DataGridParametres.DataSource = Globale.listeEleve;
        }

        private void cbbImprClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> listeEleveParClasse = new List<string>();
            foreach (Eleve eleve in Globale.listeEleve)
            {
                if (eleve.ClasseEleve == cbbImprClasse.Text)
                {
                    listeEleveParClasse.Add(eleve.NomEleve + " " + eleve.PrenomEleve);
                }
            }
            listeEleveParClasse.Sort();
            
            cbbImprSection.SelectedItem = null;
            lsbListeEleve.DataSource = null;
            lsbListeEleve.DataSource = listeEleveParClasse;
            btnValiderImpr.Enabled = true;
        }

        private void cbbImprSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> listeEleveParSection = new List<string>();
            foreach (Eleve eleve in Globale.listeEleve)
            {
                if (eleve.ClasseEleve.Substring(0,1) == cbbImprSection.Text.Substring(0,1))
                {
                    listeEleveParSection.Add(eleve.NomEleve + " " + eleve.PrenomEleve);
                }
            }

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
            frmMultiplesCartesEdition frmMultiplesCartesEdition = new frmMultiplesCartesEdition();
            frmMultiplesCartesEdition.Show();
        }

        private void frmMultiplesCartes_Load(object sender, EventArgs e)
        {
            cbbImprClasse.DataSource = Globale.classes3eme;
            cbbImprClasse.SelectedItem = null;
        }
    }
}
