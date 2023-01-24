using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CartesAcces
{
    public partial class barDeProgression : Form
    {
        public barDeProgression()
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
            Globale._accueil.Invoke(new MethodInvoker(delegate { Globale._accueil.Enabled = false; }));
            Globale._actuelle.Invoke(new MethodInvoker(delegate { Globale._actuelle.Enabled = false; }));
            switch (Globale._cas)
            {

                case 1:
                    cas_1();
                    break;
                case 2:
                    cas_2();
                    break;
                case 3 :
                    cas_3();
                    break;
                case 4:
                    cas_4();
                    break;
            }
            Globale._accueil.Invoke(new MethodInvoker(delegate { Globale._accueil.Enabled = true; }));
            Globale._actuelle.Invoke(new MethodInvoker(delegate { Globale._actuelle.Enabled = true; }));
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        private void cas_1()
        {
            ReadCSV.setLesEleves(Chemin.pathListeEleve);
            Eleve.setLesClasses();
        }
    
        private void cas_2()
        {
            Edition.importEleves(Globale._cheminTexte);
    
        }

        private void cas_3()
        {
            PdfGs.getImageFromPdf(Globale._cheminPdf, Globale._classe);
            PdfGs.renameEdt(Globale._cheminPdf);
        }

        private void cas_4()
        {
            Edition.importPhoto(Globale._cheminPhoto);
        }
    }
}