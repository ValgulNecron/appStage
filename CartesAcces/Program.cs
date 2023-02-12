using System;
using System.Windows.Forms;
using Sentry;

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
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            // sentry permet de récupérer les erreurs et de les envoyer sur le serveur
            using (SentrySdk.Init(o =>
                   {
                       o.Dsn =
                           "https://a4a3d0bd171f4e5a9fd0e136f7b8d973@o4504629047263232.ingest.sentry.io/4504629056438272";
                       // When configuring for the first time, to see what the SDK is doing:
                       o.Debug = true;
                       // Set traces_sample_rate to 1.0 to capture 100% of transactions for performance monitoring.
                       // We recommend adjusting this value in production.
                       o.TracesSampleRate = 1.0;
                       // Enable Global Mode if running in a client app
                       o.IsGlobalModeEnabled = true;
                   }))
            {
                Globale.VersionDate = "12/02/2023";
                Globale.Version = "1.3.8";
                // App code goes here. Dispose the SDK before exiting to flush events.
                try
                {
                    ClassSql.init();
                }
                catch(Exception e)
                {
                    MessageBox.Show("fichier config ou connection impossible" + e.Message);
                }
                
                // mettre les fonction et le code a execute au lancement de l'application
                // avant de lancer le formulaire
                Globale.Accueil = new frmAccueil();
                Application.Run(Globale.Accueil);
            }
        }
    }
}