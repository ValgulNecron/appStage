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

