using System;
using System.Linq;
using System.Windows.Forms;
using CarteAccesLib;
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
            Globale.VersionDate = "09/03/2023";
            Globale.Version = "1.4.5";
            // App code goes here. Dispose the SDK before exiting to flush events.
            try
            {
                ClassSql.Init();
                Globale.ConnectionBdd = true;
                var user = ClassSql.Db.GetTable<Utilisateurs>()
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                Globale.ConnectionBdd = false;
                MessageBox.Show("Connection impossible : " + e.Message);
                MessageBox.Show("Veuiller verifier le fichier config.xml et relancer l'application");
            }

            // mettre les fonction et le code a execute au lancement de l'application
            // avant de lancer le formulaire
            Globale.Accueil = new FrmAccueil();
            Application.Run(Globale.Accueil);
        }
    }
}