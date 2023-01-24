using System.Collections.Generic;
using System.Windows.Forms;

namespace CartesAcces
{
    public static class Globale
    {
        public static int _cas = 0; 
        
        public static int _classe = 6;

        public static Form _connexion;

        // connexion
        public static bool _estConnecter = false;
        public static string _nomUtilisateur = "";

        // Listes des classes 
        public static List<string> classes6eme = new List<string>();
        public static List<string> classes5eme = new List<string>();
        public static List<string> classes4eme = new List<string>();
        public static List<string> classes3eme = new List<string>();
        public static List<string> classesUnknown = new List<string>();

        // Liste d'élèves
        public static List<Eleve> listeEleve = new List<Eleve>();
        public static List<Eleve> listeEleveImpr = new List<Eleve>();
        public static List<Eleve> listeEleveSansPhoto = new List<Eleve>();
        public static List<string> listeElevesString = new List<string>();

        // theme 
        public static bool _estEnModeSombre = false;

        public static List<int> _couleurDeFondClaire = new List<int> {220, 224, 232};
        public static List<int> _couleurDuTexteclaire = new List<int> {76, 79, 105};
        public static List<int> _couleurBandeauxClaire = new List<int> {32, 159, 181};
        public static List<int> _couleurBoutonsClaire = new List<int> {204, 208, 218};
        public static List<int> _couleurTextBoxClaire = new List<int> {239, 241, 245};
        public static List<int> _couleurBoutonOffClaire = new List<int> {140, 143, 161};

        public static List<int> _couleurDeFondSombre = new List<int> {30, 30, 46};
        public static List<int> _couleurDuTexteSombre = new List<int> {148, 226, 213};
        public static List<int> _couleurBandeauxSombre = new List<int> {116, 199, 236};
        public static List<int> _couleurBoutonsSombre = new List<int> {88, 91, 112};
        public static List<int> _couleurTextBoxSombre = new List<int> {127, 132, 156};
        public static List<int> _couleurBoutonOffSombre = new List<int> {49, 50, 68};

        //
        public static int currentProgress = 0;
        public static int totalSteps = 0;

        //e
        public static Form actuelle;
        public static Form accueil;

        // version
        public static string _version = "0.2.1";
        public static string _versionDate = "18/01/2023";

        // progressBarForm2_DoWork
        public static string _textPath;
        public static string _cheminPdf;
        public static string _pathPhoto;

    }
}