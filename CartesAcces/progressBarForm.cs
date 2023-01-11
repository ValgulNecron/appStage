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
            if (Globale._estEnModeSombre)
            {
                BackColor = Color.FromArgb(255, Globale._couleurDeFondSombre[0],
                    Globale._couleurDeFondSombre[1], Globale._couleurDeFondSombre[2]);
                foreach (Control controle in Controls)
                {
                    if (controle is Button)
                    {
                        Button controle2 = controle as Button;
                        controle.BackColor = Color.FromArgb(255, Globale._couleurBoutonsSombre[0],
                            Globale._couleurBoutonsSombre[1], Globale._couleurBoutonsSombre[2]);
                        controle2.FlatStyle = FlatStyle.Flat;
                    }

                    if (controle is TextBox)
                    {
                        TextBox controle2 = controle as TextBox;
                        controle.BackColor = Color.FromArgb(255, Globale._couleurTextBoxSombre[0],
                            Globale._couleurTextBoxSombre[1], Globale._couleurTextBoxSombre[2]);
                        controle2.BorderStyle = BorderStyle.None;
                    }
                    controle.ForeColor = Color.FromArgb(255, Globale._couleurDuTexteSombre[0],
                        Globale._couleurDuTexteSombre[1], Globale._couleurDuTexteSombre[2]);
                }
            }
            else
            {
                BackColor = Color.FromArgb(255, Globale._couleurDeFondClaire[0],
                    Globale._couleurDeFondClaire[1], Globale._couleurDeFondClaire[2]);
                foreach (Control controle in Controls)
                {
                    if (controle is Button)
                    {
                        Button controle2 = controle as Button;
                        controle.BackColor = Color.FromArgb(255, Globale._couleurBoutonsClaire[0],
                            Globale._couleurBoutonsClaire[1], Globale._couleurBoutonsClaire[2]);
                        controle2.FlatStyle = FlatStyle.Flat;
                    }

                    if (controle is TextBox)
                    {
                        TextBox controle2 = controle as TextBox;
                        controle.BackColor = Color.FromArgb(255, Globale._couleurTextBoxClaire[0],
                            Globale._couleurTextBoxClaire[1], Globale._couleurTextBoxClaire[2]);
                        controle2.BorderStyle = BorderStyle.None;
                    }
                    controle.ForeColor = Color.FromArgb(255, Globale._couleurDuTexteclaire[0],
                        Globale._couleurDuTexteclaire[1], Globale._couleurDuTexteclaire[2]);
                }
            }
        }

        private void progressBarForm_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Globale.currentProgress = 1;
            Globale.totalSteps = 3;
            // backgroundWorker1.ReportProgress((int)((float)Globale.currentProgress / Globale.totalSteps * 100));

            ReadCSV.setLesEleves("exportCSVExtraction.csv");
            // backgroundWorker1.ReportProgress((int)((float)Globale.currentProgress / Globale.totalSteps * 100));
            Globale.currentProgress = 2;

            Eleve.setLesClasses();
            Globale.currentProgress = 3;
            // backgroundWorker1.ReportProgress((int)((float)Globale.currentProgress / Globale.totalSteps * 100));

            MessageBox.Show("Continuer");

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
