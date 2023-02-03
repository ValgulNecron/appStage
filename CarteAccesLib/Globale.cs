using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CartesAcces
{
    public static class Globale
    {
        public static Label LblDate { get; set; }
        public static Label LblCount { get; set; }
        public static int Cas { get; set; } = 0;
        public static int Classe { get; set; } = 6;
        
        public static Form Connexion
        { get; set; }
        public static bool PasDeBar { get; set; } = false;
        // connexion
        public static bool EstConnecter { get; set; } = false;
        public static string NomUtilisateur { get; set; } = "";
        
        // Listes des classes 
        public static List<string> Classes6Eme { get; set; } = new List<string>();
        public static List<string> Classes5Eme { get; set; } = new List<string>();
        public static List<string> Classes4Eme { get; set; } = new List<string>();
        public static List<string> Classes3Eme { get; set; } = new List<string>();
        public static List<string> ClassesInconnue { get; set; } = new List<string>();

        // Liste d'élèves
        public static List<Eleve> ListeEleve { get; set; } = new List<Eleve>();
        public static List<Eleve> ListeEleveImpr { get; set; } = new List<Eleve>();
        public static List<Eleve> ListeEleveSansPhoto { get; set; } = new List<Eleve>();
        public static List<string> ListeElevesString { get; set; } = new List<string>();

        // theme 
        public static bool EstEnModeSombre { get; set; } = false;

        public static List<int> CouleurDeFondClaire { get; set; } = new List<int> {245, 252, 255};
        public static List<int> CouleurDuTexteclaire { get; set; } = new List<int> {31, 33, 48};
        public static List<int> CouleurBandeauxClaire { get; set; } = new List<int> {138, 138, 236};
        public static List<int> CouleurBoutonsClaire { get; set; } = new List<int> {197, 210, 243};
        public static List<int> CouleurTextBoxClaire { get; set; } = new List<int> {230, 232, 245};
        public static List<int> CouleurBoutonOffClaire { get; set; } = new List<int> {140, 143, 161};

        public static List<int> CouleurDeFondSombre { get; set; } = new List<int> {108, 112, 134};
        public static List<int> CouleurDuTexteSombre { get; set; } = new List<int> {205, 214, 244};
        public static List<int> CouleurBandeauxSombre { get; set; } = new List<int> {53, 54, 58};
        public static List<int> CouleurBoutonsSombre { get; set; } = new List<int> {88, 91, 112};
        public static List<int> CouleurTextBoxSombre { get; set; } = new List<int> {127, 132, 156};
        public static List<int> CouleurBoutonOffSombre { get; set; } = new List<int> {69, 71, 90};


        // variable lier au forme utiliser pour garder une reference 
        public static Form Actuelle { get; set; }
        public static Form Accueil { get; set; }

        // version
        public static string Version1 { get; set; } = "0.3.2";
        public static string VersionDate { get; set; } = "18/01/2023";

        // variable lier au bar de progres
        public static string CheminTexte { get; set; }
        public static string CheminPdf { get; set; }
        public static string CheminPhoto { get; set; }
        public static string CheminEdtClassique { get; set; }
        public static string CheminFaceCarte { get; set; }

        public static bool GitPoule { get; set; } = true;

        // carte provisoire 
        public static PictureBox PbPhoto { get; set; }

        public static Tuple<PictureBox, PictureBox, PictureBox, TextBox, TextBox> ListeSauvegardeProvisoire
        { get; set; }

        // liste d'eleve trier
        public static List<Eleve> ListeEleves6Eme { get; set; }
        public static List<Eleve> ListeEleves5Eme { get; set; }
        public static List<Eleve> ListeEleves4Eme { get; set; }
        public static List<Eleve> ListeEleves3Eme { get; set; }
    }
}