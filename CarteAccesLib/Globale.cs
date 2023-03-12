using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CarteAccesLib;

namespace CartesAcces
{
    public static class Globale
    {
        /// <summary>
        ///  
        /// </summary>
        public static bool EleveImpr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static bool TestBordure = true;

        /// <summary>
        /// 
        /// </summary>
        public static bool PositionPhotoClassique { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static readonly string Owner = "ValgulNecron"; // nom du propriétaire du dépôt GitHub
        /// <summary>
        /// 
        /// </summary>
        public static readonly string Repo = "appStage"; // nom du dépôt GitHub
        /// <summary>
        /// 
        /// </summary>
        public static readonly string FileName = "Release.zip"; // nom du fichier de la dernière version


        /// <summary>
        /// 
        /// </summary>
        public static Label LblDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static Label LblCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static int Cas { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public static int Classe { get; set; } = 6;

        /// <summary>
        /// 
        /// </summary>
        public static Form Connexion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static bool PasDeBar { get; set; } = false;

        // connexion
        /// <summary>
        /// 
        /// </summary>
        public static bool EstConnecter { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public static string NomUtilisateur { get; set; } = "";

        // Listes des classes 
        /// <summary>
        /// 
        /// </summary>
        public static List<string> Classes6Eme { get; set; } = new List<string>();
        /// <summary>
        /// 
        /// </summary>
        public static List<string> Classes5Eme { get; set; } = new List<string>();
        /// <summary>
        /// 
        /// </summary>
        public static List<string> Classes4Eme { get; set; } = new List<string>();
        /// <summary>
        /// 
        /// </summary>
        public static List<string> Classes3Eme { get; set; } = new List<string>();
        /// <summary>
        /// 
        /// </summary>
        public static List<string> ClassesInconnue { get; set; } = new List<string>();

        // Liste d'élèves
        /// <summary>
        /// 
        /// </summary>
        public static List<Eleve> ListeEleve { get; set; } = new List<Eleve>();
        /// <summary>
        /// 
        /// </summary>
        public static List<Eleve> ListeEleveImpr { get; set; } = new List<Eleve>();
        /// <summary>
        /// 
        /// </summary>
        public static List<Eleve> ListeEleveSansPhoto { get; set; } = new List<Eleve>();
        /// <summary>
        /// 
        /// </summary>
        public static List<string> ListeElevesString { get; set; } = new List<string>();

        // theme 
        /// <summary>
        /// 
        /// </summary>
        public static bool EstEnModeSombre { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public static List<int> CouleurDeFondClaire { get; } = new List<int> {245, 252, 255};
        /// <summary>
        /// 
        /// </summary>
        public static List<int> CouleurDuTexteclaire { get; } = new List<int> {31, 33, 48};
        /// <summary>
        /// 
        /// </summary>
        public static List<int> CouleurBandeauxClaire { get; } = new List<int> {138, 138, 236};
        /// <summary>
        /// 
        /// </summary>
        public static List<int> CouleurBoutonsClaire { get; } = new List<int> {197, 210, 243};
        /// <summary>
        /// 
        /// </summary>
        public static List<int> CouleurTextBoxClaire { get; } = new List<int> {230, 232, 245};
        /// <summary>
        /// 
        /// </summary>
        public static List<int> CouleurBoutonOffClaire { get; } = new List<int> {140, 143, 161};

        /// <summary>
        /// 
        /// </summary>
        public static List<int> CouleurDeFondSombre { get; } = new List<int> {108, 112, 134};
        /// <summary>
        /// 
        /// </summary>
        public static List<int> CouleurDuTexteSombre { get; } = new List<int> {205, 214, 244};
        /// <summary>
        /// 
        /// </summary>
        public static List<int> CouleurBandeauxSombre { get; } = new List<int> {53, 54, 58};
        /// <summary>
        /// 
        /// </summary>
        public static List<int> CouleurBoutonsSombre { get; } = new List<int> {88, 91, 112};
        /// <summary>
        /// 
        /// </summary>
        public static List<int> CouleurTextBoxSombre { get; } = new List<int> {127, 132, 156};
        /// <summary>
        /// 
        /// </summary>
        public static List<int> CouleurBoutonOffSombre { get; } = new List<int> {69, 71, 90};


        // variable lier au forme utiliser pour garder une reference 
        /// <summary>
        /// 
        /// </summary>
        public static Form Actuelle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static Form Accueil { get; set; }

        // version
        /// <summary>
        /// 
        /// </summary>
        public static string Version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static string VersionDate { get; set; }


        // variable lier au bar de progres
        /// <summary>
        /// 
        /// </summary>
        public static string CheminTexte { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static string CheminPdf { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static string CheminPhoto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static string CheminEdtClassique { get; set; }
        /// <summary>
        ///     
        /// </summary>
        public static string CheminFaceCarte { get; set; }

        /// <summary>
        /// Si la GitPoule est activé
        /// </summary>
        public static bool GitPoule { get; set; } = true;

        // carte provisoire 
        /// <summary>
        ///    PictureBox
        /// </summary>
        public static PictureBox PbPhoto { get; set; }

        /// <summary>
        ///  tuple de sauvegarde provisoire
        /// </summary>
        public static Tuple<PictureBox, PictureBox, PictureBox, TextBox, TextBox> ListeSauvegardeProvisoire
        {
            get;
            set;
        }

        // liste d'eleve trier
        /// <summary>
        ///     Liste des élèves de la 6eme
        /// </summary>
        public static List<Eleve> ListeEleves6Eme { get; set; }
        /// <summary>
        ///   Liste des élèves de la 5eme
        /// </summary>
        public static List<Eleve> ListeEleves5Eme { get; set; }
        /// <summary>
        ///   Liste des élèves de la 4eme
        /// </summary>
        public static List<Eleve> ListeEleves4Eme { get; set; }
        /// <summary>
        ///    Liste des élèves de la 3eme
        /// </summary>
        public static List<Eleve> ListeEleves3Eme { get; set; }

        /// <summary>
        ///     Le mot de passe de chiffrement
        /// </summary>
        public static string MotsDePasseChifffrement { get; set; } = "";

        /// <summary>
        ///     Si le mot de passe doit etre changer
        /// </summary>
        public static bool ChangementMotDePasseChiffrement { get; set; } = false;

        /// <summary>
        ///     si la connection a la base de donnée est etablie
        /// </summary>
        public static bool ConnectionBdd { get; set; } = false;
    }
}