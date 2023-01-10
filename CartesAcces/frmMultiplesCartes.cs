﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CartesAcces
{
    public partial class frmMultiplesCartes : Form
    {
        // ** VARIBALES : booléens selection **
        public bool imprSection = false;
        public bool imprClasse = false;
        public bool imprListe = false;

        public frmMultiplesCartes()
        {
            InitializeComponent();
            Eleve.setLesClasses(cbbImprClasse);
            checkedSectionClasse();
        }

        public void checkedSectionClasse()
        {
            DataGridParametres.Columns.Clear();
            DataGridParametres.DataSource = null;
            DataGridResultats.Columns.Clear();
            DataGridResultats.DataSource = null;

            DataGridParametres.Enabled = false;
            txtRechercheDataGrid.Enabled = false;
            btnRechercheDataGrid.Enabled = false;
            btnCopierDataGrid.Enabled = false;
            DataGridResultats.Enabled = false;
            btnReset.Enabled = false;

            cbbImprClasse.Enabled = true;
            cbbImprSection.Enabled = true;
            lsbListeEleve.Enabled = true;
        }
        
        public void checkedListePerso()
        {
            // dans le cas où l'utilsateur sélectionne une classe / section puis ensuite une listeperso
            // il faut que pour l'impression (WordAImprimer) clear la liste créee lors de la sélection
            // de la classe / section, EX : sélection 3ALPHA puis sélection listeperso puis ajout de 3 élèves
            // lors de l'impression cette liste comportera 3ALPHA + les 3 élèves, les 3 lignes suivantes
            // permettent de corriger ce cas là
            imprListe = true;
            imprClasse = false;
            imprSection = false;
            
            DataGridParametres.Columns.Clear();
            DataGridParametres.DataSource = null;
            DataGridParametres.DataSource = Globale.listeEleve;

            DataGridParametres.Enabled = true;
            txtRechercheDataGrid.Enabled = true;
            btnRechercheDataGrid.Enabled = true;
            btnCopierDataGrid.Enabled = true;
            DataGridResultats.Enabled = true;
            btnReset.Enabled = true;

            cbbImprClasse.Enabled = false;
            cbbImprSection.Enabled = false;
            lsbListeEleve.Enabled = false;
        }

        public void initDataGrid()
        {
            DataGridParametres.Columns.Clear();
            DataGridParametres.DataSource = null;
            DataGridParametres.DataSource = Globale.listeEleve;
        }

        public void rechercheDataGrid()
        {
            List<Eleve> listeRecherche = new List<Eleve>();

            initDataGrid();

            foreach (DataGridViewRow row in DataGridParametres.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Value.ToString().Contains(txtRechercheDataGrid.Text))
                    {
                        Eleve eleve = new Eleve();
                        eleve.NomEleve = row.Cells[0].Value.ToString();
                        eleve.PrenomEleve = row.Cells[1].Value.ToString();
                        eleve.ClasseEleve = row.Cells[2].Value.ToString();
                        eleve.RegimeEleve = row.Cells[3].Value.ToString();
                        eleve.OptionUnEleve = row.Cells[4].Value.ToString();
                        eleve.OptionDeuxEleve = row.Cells[5].Value.ToString();
                        eleve.OptionTroisEleve = row.Cells[6].Value.ToString();
                        eleve.OptionQuatreEleve = row.Cells[7].Value.ToString();
                        eleve.MefEleve = row.Cells[8].Value.ToString();

                        listeRecherche.Add(eleve);
                    }
                }
            }

            if (listeRecherche.Count() == 0)
            {
                MessageBox.Show("Unable to find " + txtRechercheDataGrid.Text, "Not Found");
                return;
            }
            else if (txtRechercheDataGrid.Text == "")
            {
                initDataGrid();
                listeRecherche.Clear();
            }
            else
            {
                DataGridParametres.Columns.Clear();
                DataGridParametres.DataSource = null;
                DataGridParametres.DataSource = listeRecherche;
            }
        }

        public void btnValiderImpr_Click(object sender, EventArgs e)
        {
            if (imprClasse == true)
                Eleve.affecterElevesClasses(cbbImprClasse.Text);

            if (imprSection == true)
                Eleve.affecterElevesSections(cbbImprSection.Text);

            Globale.listeEleveSansPhoto.Clear();

            if (Globale.listeEleveImpr.Count == 0)
            {
                MessageBox.Show("Veuillez selectionner une classe, une section ou bien une liste personnalisée d'élèves.");
            }

            else
            {
                foreach (Eleve eleve in Globale.listeEleveImpr)
                {
                    Photo.verifPhotoEleve(eleve);
                }

                if (Globale.listeEleveSansPhoto.Count != 0)
                {
                    string msg = "Attention ! Les élèves suivant n'ont pas de photo : ";
                    foreach (Eleve eleve in Globale.listeEleveSansPhoto)
                    {
                        msg = msg + Environment.NewLine + eleve.NomEleve + " " + eleve.PrenomEleve;
                    }

                    msg += Environment.NewLine + "Voulez vous quand même continuer ?";

                    DialogResult dialogResult = MessageBox.Show(msg, "Some Title", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        frmMultiplesCartesEdition frm = new frmMultiplesCartesEdition();

                        frm.imprClasse = imprClasse;
                        frm.imprListe = imprListe;
                        frm.imprSection = imprSection;

                        frm.listeEleve = Globale.listeEleveImpr;

                        frm.affecterListeClee();

                        int index = 0;
                        while (Globale.listeEleveImpr[index].SansEDT == true)
                        {
                            index++;
                            if (index >= Globale.listeEleveImpr.Count - 1)
                            {
                                break;
                            }
                        }

                        frm.afficheEmploiDuTemps(index);
                        frm.affichePhotoProvisoire();

                        frm.Show();

                    }

                }
                else
                {
                    frmMultiplesCartesEdition frm = new frmMultiplesCartesEdition();

                    frm.imprClasse = imprClasse;
                    frm.imprListe = imprListe;
                    frm.imprSection = imprSection;

                    frm.listeEleve = Globale.listeEleveImpr;

                    frm.affecterListeClee();

                    int index = 0;
                    while (Globale.listeEleveImpr[index].SansEDT == true)
                    {
                        index++;
                        if (index >= Globale.listeEleveImpr.Count - 1)
                        {
                            break;
                        }
                    }

                    frm.afficheEmploiDuTemps(index);
                    frm.affichePhotoProvisoire();

                    frm.Show();
                }

            }

        }


        private void cbbImprClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nettoie la liste afin que lors de l'édition de photo (après avoir cliquer sur le bouton valider
            // que l'emploi du temps choisi soit la bonne plutôt que la première sélection, ex : je choisis "3ARIANE", puis "3GALILEE"
            // lors de la validation sur l'édition photo l'emploi du temps associé à la création du Word est "3ARIANE" à la place de
            // "3GALILEE"
            btnValiderImpr.Enabled = true;
            Globale.listeEleveImpr.Clear();

            // -- Booléen de selection --
            imprSection = false;
            imprClasse = true;
            imprListe = false;

        // -- REFRESH --
            cbbImprSection.SelectedItem = null;
            cbbImprSection.Refresh();

        // -- Affiche liste eleve
            lsbListeEleve.DataSource = Eleve.getEleveClasse(cbbImprClasse.Text);
            lsbListeEleve.Refresh();

            // -- Comptage du nombre d'élève de la liste
            NbComptageEleveCS.Text = "Nombre d'élève de la section ou de la classe choisie : " + lsbListeEleve.Items.Count.ToString();
        }

        private void cbbImprSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nettoie la liste afin que lors de l'édition de photo (après avoir cliquer sur le bouton valider
            // que l'emploi du temps choisi soit la bonne plutôt que la première sélection, ex : je choisis "3ème", puis "4ème"
            // lors de la validation sur l'édition photo l'emploi du temps associé à la création du Word est "3ALPHA" à la place de
            // "4ORION" par exemple
            btnValiderImpr.Enabled = true;
            Globale.listeEleveImpr.Clear();

            // -- Booléen de selection --
            imprSection = true;
            imprClasse = false;
            imprListe = false;

        // -- REFRESH --
            cbbImprClasse.SelectedItem = null;
            cbbImprClasse.Refresh();

        // -- Affiche liste eleve
            lsbListeEleve.DataSource = Eleve.getEleveSection(cbbImprSection.Text);
            lsbListeEleve.Refresh();

         // -- Comptage du nombre d'élève de la liste
            NbComptageEleveCS.Text = "Nombre d'élève de la section ou de la classe choisie : " + lsbListeEleve.Items.Count.ToString();
        }

        private void rdbClasseSection_CheckedChanged(object sender, EventArgs e)
        {
            checkedSectionClasse();
            btnValiderImpr.Enabled = false;
        }

        private void rdbListePerso_CheckedChanged(object sender, EventArgs e)
        {
            Globale.listeEleveImpr.Clear(); // permet de clear la liste qui aurait été construite par la sélection d'une classe / d'une section avec/ou non de la validation
            // si je n'ai pas cette ligne, le DataGridView (liste personnalisée) affichera une liste qui n'était pas souhaité par l'utilisateur

            checkedListePerso();
        }

        private void btnCopierDataGrid_Click(object sender, EventArgs e)
        {
            btnValiderImpr.Enabled = true;
            foreach (DataGridViewRow row in DataGridParametres.SelectedRows)
            {
                Eleve eleve = new Eleve();
                eleve.NomEleve = row.Cells[0].Value.ToString();
                eleve.PrenomEleve = row.Cells[1].Value.ToString();
                eleve.ClasseEleve = row.Cells[2].Value.ToString();
                eleve.RegimeEleve = row.Cells[3].Value.ToString();
                eleve.OptionUnEleve = row.Cells[4].Value.ToString();
                eleve.OptionDeuxEleve = row.Cells[5].Value.ToString();
                eleve.OptionTroisEleve = row.Cells[6].Value.ToString();
                eleve.OptionQuatreEleve = row.Cells[7].Value.ToString();
                eleve.MefEleve = row.Cells[8].Value.ToString();

                Globale.listeEleveImpr.Add(eleve);
            }
            DataGridResultats.DataSource = null;
            DataGridResultats.Refresh();
            DataGridResultats.DataSource = Globale.listeEleveImpr;

        }

        private void btnRechercheDataGrid_Click(object sender, EventArgs e)
        {
            DataGridParametres.ClearSelection(); // permet de ne pas ajouter la sélection d'avant afin d'éviter des doublons
            DataGridParametres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            bool valueResult = false;
            foreach (DataGridViewRow row in DataGridParametres.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Value.ToString().Equals(txtRechercheDataGrid.Text))
                    {
                        DataGridParametres.Rows[row.Index].Selected = true;
                        valueResult = true;
                        break;
                    }
                }

            }
            if (!valueResult)
            {
                MessageBox.Show("Unable to find " + txtRechercheDataGrid.Text, "Not Found");
                return;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Globale.listeEleveImpr.Clear();
            DataGridResultats.DataSource = null;
        }



        private void frmMultiplesCartes_Load(object sender, EventArgs e)
        {

        }

        private void lsbListeEleve_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void txtRechercheDataGrid_TextChanged(object sender, EventArgs e)
        {
            rechercheDataGrid();
        }

        private void DataGridResultats_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // -- Comptage du nombre d'élève de la liste
            NbComptageEleveLP.Text = "Nombre d'élève de la liste personnalisée : " + DataGridResultats.Rows.Count.ToString();
        }

        private void DataGridResultats_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // -- Comptage du nombre d'élève de la liste
            NbComptageEleveLP.Text = "Nombre d'élève de la liste personnalisée : " + DataGridResultats.Rows.Count.ToString();
        }
    }
}
