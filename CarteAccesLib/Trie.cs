using System.Collections.Generic;
using System.Text.RegularExpressions;
using CartesAcces;

namespace CarteAccesLib
{
    public static class Trie
    {
        public static List<Eleve> search(List<Eleve> listeEleve, string filtre)
        {
            var listeEleveResultat = new List<Eleve>();
            Regex regex = new Regex(filtre);
            foreach (Eleve eleve in listeEleve)
            {
                string nomPrenom = eleve.NomEleve + " " + eleve.PrenomEleve;
                Match match = regex.Match(nomPrenom);
                if (match.Success)
                {
                    listeEleveResultat.Add(eleve);
                }
            }

            return listeEleveResultat;
        }
    }
}