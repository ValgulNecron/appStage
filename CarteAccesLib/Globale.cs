using System.Collections.Generic;
using System.Windows.Forms;

namespace CartesAcces
{
    public static class Globale
    {
        public static Label _lblDate;

        public static int _cas = 0;

        public static int _classe = 6;

        public static Form _connexion;

        // connexion
        public static bool _estConnecter = false;
        public static string _nomUtilisateur = "";

        // Listes des classes 
        public static List<string> _classes6eme = new List<string>();
        public static List<string> _classes5eme = new List<string>();
        public static List<string> _classes4eme = new List<string>();
        public static List<string> _classes3eme = new List<string>();
        public static List<string> _classesInconnue = new List<string>();

        // Liste d'élèves
        public static List<Eleve> _listeEleve = new List<Eleve>();
        public static List<Eleve> _listeEleveImpr = new List<Eleve>();
        public static List<Eleve> _listeEleveSansPhoto = new List<Eleve>();
        public static List<string> _listeElevesString = new List<string>();

        // theme 
        public static bool _estEnModeSombre = false;

        public static List<int> _couleurDeFondClaire = new List<int> {220, 224, 232};
        public static List<int> _couleurDuTexteclaire = new List<int> {76, 79, 105};
        public static List<int> _couleurBandeauxClaire = new List<int> {70, 130, 180};
        public static List<int> _couleurBoutonsClaire = new List<int> {204, 208, 218};
        public static List<int> _couleurTextBoxClaire = new List<int> {239, 241, 245};
        public static List<int> _couleurBoutonOffClaire = new List<int> {140, 143, 161};

        public static List<int> _couleurDeFondSombre = new List<int> {49, 50, 68};

        public static List<int> _couleurDuTexteSombre = new List<int> {148, 226, 213};

        //public static List<int> _couleurBandeauxSombre = new List<int> {116, 199, 236};
        public static List<int> _couleurBandeauxSombre = new List<int> {70, 130, 180};
        public static List<int> _couleurBoutonsSombre = new List<int> {88, 91, 112};
        public static List<int> _couleurTextBoxSombre = new List<int> {127, 132, 156};
        public static List<int> _couleurBoutonOffSombre = new List<int> {69, 71, 90};


        // variable lier au forme utiliser pour garder une reference 
        public static Form _actuelle;
        public static Form _accueil;

        // version
        public static string _version = "0.2.1";
        public static string _versionDate = "18/01/2023";

        // variable lier au bar de progres
        public static string _cheminTexte;
        public static string _cheminPdf;
        public static string _cheminPhoto;
        public static string _cheminEdtClassique;
    }
}