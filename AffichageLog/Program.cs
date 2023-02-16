using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CartesAcces;

namespace AffichageLog
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Globale.VersionDate = "16/02/2023";
            Globale.Version = "1.0";
            Application.Run(new frmAccueil());
        }
    }
}