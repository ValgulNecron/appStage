using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartesAcces
{
    public partial class progressBarForm : Form
    {
        public progressBarForm()
        {
            InitializeComponent();
        }

        private void progressBarForm_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Globale.currentProgress = 0;
            // Globale.totalSteps = 2;

            ReadCSV.setLesEleves("exportCSVExtraction.csv");
            //Globale.currentProgress = 1;
            //backgroundWorker1.ReportProgress((int)((float) Globale.currentProgress / Globale.totalSteps * 100));

            frmParametres.setLesClasses();
            //Globale.currentProgress = 2;
            //backgroundWorker1.ReportProgress((int)((float)Globale.currentProgress / Globale.totalSteps * 100));
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
