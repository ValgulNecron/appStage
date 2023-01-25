using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CartesAcces;

namespace CarteAccesLib
{
    public static class Trie
    {
        public static List<String> recherche(string filtre)
        {
            var listeEleveResultat = new List<String>();
            Regex regex = new Regex(filtre.ToLower());
            foreach (Eleve eleve in Globale._listeEleve)
            {
                string nomPrenom = eleve.NomEleve + " " + eleve.PrenomEleve;
                nomPrenom = nomPrenom.ToLower();
                Match match = regex.Match(nomPrenom);
                if (match.Success)
                {
                    listeEleveResultat.Add(eleve.NomEleve + " " + eleve.PrenomEleve + " " + eleve.ClasseEleve);
                }
            }

            return listeEleveResultat;
        }
    }
}