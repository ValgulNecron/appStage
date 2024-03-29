﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CartesAcces
{
    /// <summary>
    /// Permet de créer des cartes d'accès par classe et niveau
    /// </summary>
    public partial class FrmCarteParClasseNiveau : Form
    {
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public FrmCarteParClasseNiveau()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
        }

        private void cbbImprClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            Globale.ListeEleveImpr.Clear();
            var listeEleveParClasse = new List<string>();
            foreach (var eleve in Globale.ListeEleve)
                if (eleve.ClasseEleve == cbbImprClasse.Text)
                {
                    listeEleveParClasse.Add(eleve.NomEleve + " " + eleve.PrenomEleve);
                    Globale.ListeEleveImpr.Add(eleve);
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
            Globale.ListeEleveImpr.Clear();
            var listeEleveParSection = new List<string>();
            foreach (var eleve in Globale.ListeEleve)
                if (eleve.ClasseEleve.Substring(0, 1) == cbbImprSection.Text.Substring(0, 1))
                {
                    listeEleveParSection.Add(eleve.NomEleve + " " + eleve.PrenomEleve);
                    Globale.ListeEleveImpr.Add(eleve);
                }

            listeEleveParSection.Sort();
            lblCount.Text = listeEleveParSection.Count.ToString();

            cbbImprClasse.SelectedItem = null;
            lsbListeEleve.DataSource = null;
            lsbListeEleve.DataSource = listeEleveParSection;
            btnValiderImpr.Enabled = true;
        }

        private void btnValiderImpr_Click(object sender, EventArgs e)
        {
            try
            {
                var frmMultiplesCartesEdition = new FrmMultiplesCartesEdition();
                frmMultiplesCartesEdition.Show();
            }
            catch
            {
            }
        }

        private void frmMultiplesCartes_Load(object sender, EventArgs e)
        {
            var lesClasses = new List<string>();

            lesClasses.AddRange(Globale.Classes3Eme);
            lesClasses.AddRange(Globale.Classes4Eme);
            lesClasses.AddRange(Globale.Classes5Eme);
            lesClasses.AddRange(Globale.Classes6Eme);

            cbbImprClasse.DataSource = lesClasses;
            cbbImprClasse.SelectedItem = null;
            lblCount.Text = "";
        }
    }
}