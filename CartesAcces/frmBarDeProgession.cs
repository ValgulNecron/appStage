using System;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using CarteAcces;
using CarteAccesLib;
using LinqToDB;

namespace CartesAcces
{
    public partial class barDeProgression : Form
    {
        public barDeProgression()
        {
            InitializeComponent();
            TailleControle.setTailleControleTexte(this);
            Couleur.setCouleurFenetre(this);
        }

        private void progressBarForm_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            ControlBox = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
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
                    case 3:
                        cas_3();
                        break;
                    case 4:
                        cas_4();
                        break;
                    case 5:
                        cas_5();
                        break;
                }

                Globale._accueil.Invoke(new MethodInvoker(delegate { Globale._accueil.Enabled = true; }));
                Globale._actuelle.Invoke(new MethodInvoker(delegate { Globale._actuelle.Enabled = true; }));
            }
            catch
            {
                MessageBox.Show(new Form { TopMost = true }, "operation annulée");
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        private void cas_1()
        {
            ReadCsv.setLesEleves(Chemin.cheminListeEleve);
            Eleve.setLesClasses();
        }

        private void cas_2()
        {
            Edition.importEleves(Globale._cheminTexte);
            Globale._actuelle.Invoke(new MethodInvoker(delegate
            {
                foreach (Control controle in Globale._actuelle.Controls)
                    if (controle is Label && controle.Name == "lblDateListeEleve")
                        controle.Text = ReadCsv.getDateFile();
            }));
        }

        private void cas_3()
        {
            PdfGs.getImageFromPdf(Globale._cheminPdf, Globale._classe);
            PdfGs.renameEdt(Globale._cheminPdf);

            Globale._actuelle.Invoke(new MethodInvoker(delegate
            {
                foreach (Control controle in Globale._actuelle.Controls)
                    if (controle is Label && controle.Name == "lblEdtEleve")
                        controle.Text = PdfGs.getDateFile();
            }));
            PdfGs.valeurParDefault();
        }

        private void cas_4()
        {
            Edition.importPhoto(Globale._cheminPhoto);

            Globale._actuelle.Invoke(new MethodInvoker(delegate
            {
                foreach (Control controle in Globale._actuelle.Controls)
                    if (controle is Label && controle.Name == "lblPhotoEleve")
                        controle.Text = Photo.getDatePhotos();
            }));
        }

        private void cas_5()
        {
            try
            {
                if (Globale._pbPhoto.Image == null)
                {
                    MessageBox.Show("Veuillez ajouter une photo");
                }
                else
                {
                    FichierWord.sauvegardeCarteProvisoireWord(Globale._listeSauvegardeProvisoire.Item1,
                        Globale._listeSauvegardeProvisoire.Item2,
                        Globale._listeSauvegardeProvisoire.Item3, Globale._listeSauvegardeProvisoire.Item4,
                        Globale._listeSauvegardeProvisoire.Item5);

                    var macAddress = "";

                    foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
                        if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                             nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                            && nic.OperationalStatus == OperationalStatus.Up)
                        {
                            macAddress += nic.GetPhysicalAddress().ToString();
                            break;
                        }

                    var log = new LogActions();
                    log.DateAction = DateTime.Now;
                    log.NomUtilisateur = Globale._nomUtilisateur;
                    log.Action = "à fait une carte provisoire";
                    log.AdMac = macAddress;
                    ClassSql.db.Insert(log);
                }
            }
            catch
            {
            }
        }
    }
}