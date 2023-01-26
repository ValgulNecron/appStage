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
            // ClassSql.init();
            Globale._accueil = new frmAccueil();
            Application.Run(Globale._accueil);
        }
    }
}