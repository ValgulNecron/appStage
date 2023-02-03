using System.Collections.Generic;
using System.Text.RegularExpressions;
using CartesAcces;

namespace CarteAccesLib
{
    public static class Trie
    {
        /*
         * Cette fonction permet de rechercher un eleve dans la liste des eleves
         * Elle prend en parametre le filtre de recherche et la liste des eleves
         * Elle retourne une liste de string contenant le nom, le prenom et la classe de l'eleve
         */
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