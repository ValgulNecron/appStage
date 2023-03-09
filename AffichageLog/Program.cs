using System;
using System.Windows.Forms;
using CartesAcces;

namespace AffichageLog
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Globale.VersionDate = "16/02/2023";
            Globale.Version = "1.0";
            Application.Run(new frmAccueil());
        }
    }
}