﻿using System;
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
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            using (SentrySdk.Init(o =>
                   { 
                       o.Dsn = "https://a4a3d0bd171f4e5a9fd0e136f7b8d973@o4504629047263232.ingest.sentry.io/4504629056438272";
                       // When configuring for the first time, to see what the SDK is doing:
                       o.Debug = true;
                       // Set traces_sample_rate to 1.0 to capture 100% of transactions for performance monitoring.
                       // We recommend adjusting this value in production.
                       o.TracesSampleRate = 1.0;
                       // Enable Global Mode if running in a client app
                       o.IsGlobalModeEnabled = true;
                   }))
            {
                // App code goes here. Dispose the SDK before exiting to flush events.
                ClassSql.init();
                Globale.Accueil = new frmAccueil();
                Application.Run(Globale.Accueil);
            }
        }
    }
}