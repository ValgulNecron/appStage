using System.Collections.Generic;
using System.Text.RegularExpressions;
using CartesAcces;

namespace CarteAccesLib
{
    public static class Trie
    {
        public static List<string> recherche(string filtre, List<Eleve> eleves)
        {
            var listeEleveResultat = new List<string>();
            var regex = new Regex(filtre.ToLower());
            foreach (var eleve in eleves)
            {
                var nomPrenom = eleve.NomEleve + " " + eleve.PrenomEleve;
                nomPrenom = nomPrenom.ToLower();
                var match = regex.Match(nomPrenom);
                if (match.Success)
                    listeEleveResultat.Add(eleve.NomEleve + " " + eleve.PrenomEleve + " " + eleve.ClasseEleve);
            }

            return listeEleveResultat;
        }
    }
}