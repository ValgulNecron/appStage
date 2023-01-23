using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CartesAcces
{
    public partial class progressBarForm : Form
    {
        public progressBarForm()
        {
            InitializeComponent();
            ControlSize.SetSizeTextControl(this);
            Couleur.setCouleurFenetre(this);
        }

        private void progressBarForm_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Globale.accueil.Invoke(new MethodInvoker(delegate { Globale.accueil.Enabled = false; }));
            Globale.actuelle.Invoke(new MethodInvoker(delegate { Globale.actuelle.Enabled = false; }));
            Globale.currentProgress = 1;
            Globale.totalSteps = 3;
            // backgroundWorker1.ReportProgress((int)((float)Globale.currentProgress / Globale.totalSteps * 100));

            ReadCSV.setLesEleves(Chemin.pathListeEleve);
            // backgroundWorker1.ReportProgress((int)((float)Globale.currentProgress / Globale.totalSteps * 100));
            Globale.currentProgress = 2;

            Eleve.setLesClasses();
            Globale.currentProgress = 3;
            // backgroundWorker1.ReportProgress((int)((float)Globale.currentProgress / Globale.totalSteps * 100));
            Globale.accueil.Invoke(new MethodInvoker(delegate { Globale.accueil.Enabled = true; }));
            Globale.actuelle.Invoke(new MethodInvoker(delegate { Globale.actuelle.Enabled = true; }));
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }
    }
}