using System;
using System.Windows.Forms;

namespace CartesAcces
{
    internal static class Program
    {
        /// <summary>
        ///     Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var db = new ClassSql())
            {
                var utilisateur = db.Utilisateurs.Find("keyuser");
                MessageBox.Show(utilisateur.NomUtilisateur + " " + utilisateur.Hash);
            }

            Globale._accueil = new frmAccueil();
            Application.Run(Globale._accueil);
        }
    }
}