using System.Drawing;

namespace CartesAcces
{
    public static class Edition
    {
        // ** VARIABLES : Pour l'édition de l'emploi du temps (rognage) **
        public static bool selectionClick = false;     // -> Est ce que le bouton "Selectionner" a été cliqué ? Si oui passe à true
        public static int cropX;       // -> Abscisse de départ du rognage
        public static int cropY;       // -> Ordonnée de départ du rognage
        public static int cropWidth;       // -> Largeur du rognage
        public static int cropHeight;      // -> Hauteur du rognage
        public static Pen cropPen;     // -> Stylo qui dessine le rectangle correspondant au rognage

        // ** VARIABLES  : Déplacement de la photo
        public static bool drag = false;       // -> Est ce que l'utilisateur a cliqué sur la photo ? (clique maintenue : drag passera a true)
        public static int posX;        // -> Abscisse initiale, sauvegardée quand l'utilisateur commence le déplacement (clic maintenu sur la photo)
        public static int posY;        // -> Ordonnée initialie, sauvegardée quand l'utilisateur commence le déplacement (clic maintenu sur la photo)

        // ** VARIABLES : Provisoires.. **
        public static string affichageTest;

        public static string cheminImpressionFinal;
    }
}