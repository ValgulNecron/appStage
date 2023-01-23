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
    public partial class progressBarForm2 : Form
    {
            public progressBarForm2()
            {
                InitializeComponent();
                ControlSize.SetSizeTextControl(this);
                Couleur.setCouleurFenetre(this);
            }

            private void progressBarForm_Load(object sender, EventArgs e)
            {
                backgroundWorker2.RunWorkerAsync();
            }

            private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                //Globale.accueil.Invoke(new MethodInvoker(delegate { Globale.accueil.Enabled = false; }));
                //Globale.actuelle.Invoke(new MethodInvoker(delegate { Globale.actuelle.Enabled = false; }));

                Edition.importEleves(Globale._textPath);
            // backgroundWorker1.ReportProgress((int)((float)Globale.currentProgress / Globale.totalSteps * 100));
                //Globale.accueil.Invoke(new MethodInvoker(delegate { Globale.accueil.Enabled = true; }));
                //Globale.actuelle.Invoke(new MethodInvoker(delegate { Globale.actuelle.Enabled = true; }));
            }

            private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                Close();
            }

        private void progressBarForm2_Load(object sender, EventArgs e)
        {
            backgroundWorker2.RunWorkerAsync();
            
        }
    }
    }

