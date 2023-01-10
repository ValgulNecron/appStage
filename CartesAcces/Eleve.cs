﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartesAcces
{
    public class Eleve
    {
        private string nomEleve;
        private string prenomEleve;
        private string classeEleve;
        private string regimeEleve;
        private string optionUnEleve;
        private string optionDeuxEleve;
        private string optionTroisEleve;
        private string optionQuatreEleve;
        private string mefEleve;
        private bool sansEDT;

        public Eleve()
        {
            this.NomEleve = "null";
            this.PrenomEleve = "null";
            this.ClasseEleve = "null";
            this.RegimeEleve = "null";
            this.OptionUnEleve = "null";
            this.OptionDeuxEleve = "null";
            this.OptionTroisEleve = "null";
            this.OptionQuatreEleve = "null";
            this.mefEleve = "null";
            this.sansEDT = false;
        }

        public string NomEleve { get => nomEleve; set => nomEleve = value; }
        public string PrenomEleve { get => prenomEleve; set => prenomEleve = value; }
        public string ClasseEleve { get => classeEleve; set => classeEleve = value; }
        public string RegimeEleve { get => regimeEleve; set => regimeEleve = value; }
        public string OptionUnEleve { get => optionUnEleve; set => optionUnEleve = value; }
        public string OptionDeuxEleve { get => optionDeuxEleve; set => optionDeuxEleve = value; }
        public string OptionTroisEleve { get => optionTroisEleve; set => optionTroisEleve = value; }
        public string OptionQuatreEleve { get => optionQuatreEleve; set => optionQuatreEleve = value; }
        public string MefEleve { get => mefEleve; set => mefEleve = value; }
        public bool SansEDT { get => sansEDT; set => sansEDT = value; }
        
        public static List<string> getEleveSection(string section)
        {
            // l'idée est de récupérer le premier caractère d'une propriété de l'objet, ici on veut le premier caractère de la classe de l'élève, on choisit
            //section "3ème" par exemple, on veut prendre que le caractère "3" puis on le compare au premier caractère de la classe de chaque élève de la liste
            //si "3" est le premier caractère alors cette élève est ajouté à la liste des élèves à imprimer
            List<string> LesEleves = new List<string>();

            section = section.Substring(0, 1);
            foreach (Eleve eleve in Globale.listeEleve)
            {
                if (eleve.ClasseEleve.Substring(0,1) == section)
                {
                    LesEleves.Add(eleve.NomEleve);
                }
            }

            return LesEleves;
        }
        
        public static void setLesClasses(ComboBox cbbImprClasse)
        {
            List<string> listeClassesAll = new List<string>();

            //Pour cacher la valeur par défaut, aussi car la valeur par défaut sans cela prend le premier index qui est 3GALILEE par exemple
            //cependant dans ce cas là, la liste n'est pas récupérée par défaut même si le premier objet est sélectionné par défaut
            listeClassesAll.Add("");

            foreach (string classe in Globale.classes3eme)
            {
                listeClassesAll.Add(classe);
            }
            foreach (string classe in Globale.classes4eme)
            {
                listeClassesAll.Add(classe);
            }
            foreach (string classe in Globale.classes5eme)
            {
                listeClassesAll.Add(classe);
            }
            foreach (string classe in Globale.classes6eme)
            {
                listeClassesAll.Add(classe);
            }

            cbbImprClasse.DataSource = listeClassesAll;
        }
        
        public static List<string> getEleveClasse(string classe)
        {
            List<string> LesEleves = new List<string>();

            foreach(Eleve eleve in Globale.listeEleve)
            {
                if(eleve.ClasseEleve == classe)
                {
                    LesEleves.Add(eleve.NomEleve);
                }
            }

            return LesEleves;
        }

        // -- Pour l'impression par classe, les élève de la liste initiale dont la classe
        // correspond à la selection seront collectés --
        public static void affecterElevesClasses(string uneClasse)
        {
            foreach(Eleve eleve in Globale.listeEleve)
            {
                if (eleve.ClasseEleve == uneClasse)
                    Globale.listeEleveImpr.Add(eleve);
            }
        }
        
        // -- Idem pour la section -- 
        public static void affecterElevesSections(string uneSection)
        {
            foreach(Eleve eleve in Globale.listeEleve)
            {
                string numSection = eleve.ClasseEleve.Substring(0,1); //solution?
                if (numSection == uneSection.Substring(0, 1))
                {
                    Globale.listeEleveImpr.Add(eleve);
                }
            }
        }
    }
}
