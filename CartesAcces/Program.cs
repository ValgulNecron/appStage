using System;
using System.Linq;
using System.Windows.Forms;
using LinqToDB;

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
            ClassSql.init();
            Globale._accueil = new frmAccueil();    
            Application.Run(Globale._accueil);
        }
    }
}