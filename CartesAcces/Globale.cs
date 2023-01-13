using System.Collections.Generic;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using Microsoft.Office.Interop.Word;

namespace CartesAcces
{
    public static class Globale
    {
        static public int _classe = 6;
    
        static public Form _connexion; 
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
        public static List<Eleve> listeEleveImpr = new List<Eleve>();
        public static List<Eleve> listeEleveSansPhoto = new List<Eleve>();
        
        // Liste des EDT
        public static List<PdfPage> listeEdt = new List<PdfPage>();
        public static List<Image> listeEdtImage = new List<Image>();

        // theme 
        static public bool _estEnModeSombre = false;

        static public List<int> _couleurDeFondClaire = new List<int>{220, 224, 232};
        static public List<int> _couleurDuTexteclaire = new List<int>{76, 79, 105};
        static public List<int> _couleurBandeauxClaire =new List<int>{32, 159, 181};
        static public List<int> _couleurBoutonsClaire = new List<int>{204, 208, 218};
        static public List<int> _couleurTextBoxClaire = new List<int> {239, 241, 245};
        static public List<int> _couleurBoutonOffClaire = new List<int> {172, 176, 190};
        
        static public List<int> _couleurDeFondSombre = new List<int>{30, 30, 46};
        static public List<int> _couleurDuTexteSombre = new List<int>{148, 226, 213};
        static public List<int> _couleurBandeauxSombre = new List<int>{116, 199, 236};
        static public List<int> _couleurBoutonsSombre = new List<int>{88, 91, 112};
        static public List<int> _couleurTextBoxSombre = new List<int> {127, 132, 156};
        static public List<int> _couleurBoutonOffSombre = new List<int> {49, 50, 68};
        
        //
        static public int currentProgress = 0;
        static public int totalSteps = 0;

        //
        static public frmAccueil accueil;
    }
}