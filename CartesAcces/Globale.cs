using System.Collections.Generic;

namespace CartesAcces
{
    public static class Globale
    {
        // connexion
        static public bool _estConnecter = false;
        static public string _nomUtilisateur = "";
        
        // Listes des classes 
        public static List<string> classes6eme = new List<string>();
        public static List<string> classes5eme = new List<string>();
        public static List<string> classes4eme = new List<string>();
        public static List<string> classes3eme = new List<string>();
        public static List<string> classesUnknown = new List<string>();

        // Liste d'élèves
        public static List<Eleve> listeEleve = new List<Eleve>();
        
        // theme 
        static public bool _estEnModeSombre = false;

        static public string _couleurDeFondClaire = "#eff1f5";
        static public string _couleurDuTexteclaire = "#4c4f69";
        static public string _couleurBandeauxClaire = "#179299";
        static public string _couleurBoutonsClaire = "#8c8fa1";
        
        static public string _couleurDeFondSombre = "#1e1e2e";
        static public string _couleurDuTexteSombre = "#cdd6f4";
        static public string _couleurBandeauxSombre = "#94e2d5";
        static public string _couleurBoutonsSombre = "#9399b2";
    }
}