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
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Globale._accueil = new frmAccueil();
                Application.Run(Globale._accueil);
            }
            catch(Exception e)
            {
                MessageBox.Show("y a une erreur pas prevue note la.");
                MessageBox.Show(e.Message);
                Main();
            }
        }
    }
}