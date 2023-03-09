using System.Collections.Generic;
using System.Text.RegularExpressions;
using CartesAcces;

namespace CarteAccesLib
{
    
    /// <summary>
    /// Cette fonction permet de rechercher un eleve dans la liste des eleves
    /// Elle prend en parametre le filtre de recherche et la liste des eleves
    /// Elle retourne une liste de string contenant le nom, le prenom et la classe de l'eleve
    /// </summary>
    public static class XTrie
    {
        /// <summary>
        /// Cette fonction permet de rechercher un eleve dans la liste des eleves
        /// Elle prend en parametre le filtre de recherche et la liste des eleves
        /// </summary>
        /// <param name="filtre"></param>
        /// <param name="eleves"></param>
        /// <returns></returns>
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