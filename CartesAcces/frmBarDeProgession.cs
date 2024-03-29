﻿using System;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using CarteAccesLib;
using LinqToDB;

namespace CartesAcces
{
    /// <summary>
    ///    fenetre de progression
    /// </summary>
    public partial class BarDeProgression : Form
    {
        /// <summary>
        ///    Constructeur de la classe
        /// </summary>
        public BarDeProgression()
        {
            InitializeComponent();
            TailleControle.SetTailleControleTexte(this);
            Couleur.setCouleurFenetre(this);
            Application.EnableVisualStyles();
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
                Globale.Accueil.Invoke(new MethodInvoker(delegate { Globale.Accueil.Enabled = false; }));
                Globale.Actuelle.Invoke(new MethodInvoker(delegate { Globale.Actuelle.Enabled = false; }));
                switch (Globale.Cas)
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

                Globale.Accueil.Invoke(new MethodInvoker(delegate { Globale.Accueil.Enabled = true; }));
                Globale.Actuelle.Invoke(new MethodInvoker(delegate { Globale.Actuelle.Enabled = true; }));
            }
            catch
            {
                MessageBox.Show(new Form {TopMost = true}, "operation annulée");
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        private void cas_1()
        {
            Securite.DechiffrerDossier();
            ReadCsv.SetLesEleves(Chemin.CheminListeEleve);
            Eleve.SetLesClasses();
        }

        private void cas_2()
        {
            Edition.importEleves(Globale.CheminTexte);
            Globale.Actuelle.Invoke(new MethodInvoker(delegate
            {
                foreach (Control controle in Globale.Actuelle.Controls)
                    if (controle is Label && controle.Name == "lblDateListeEleve")
                        controle.Text = ReadCsv.GetDateFile();
            }));
        }

        private void cas_3()
        {
            PdfGs.GetImageFromPdf(Globale.CheminPdf, Globale.Classe);
            PdfGs.RenameEdt(Globale.CheminPdf);

            Globale.Actuelle.Invoke(new MethodInvoker(delegate
            {
                foreach (Control controle in Globale.Actuelle.Controls)
                    if (controle is Label && controle.Name == "lblEdtEleve")
                        controle.Text = PdfGs.getDateFile();
            }));

            Globale.Actuelle.Invoke(new MethodInvoker(delegate
            {
                if (Globale.Classe == 7)
                {
                    Edition.importEdtClassique(Globale.CheminEdtClassique);

                    var frmRognageEdtClassique = new FrmRognageEdtClassique();
                    frmRognageEdtClassique.Show();
                }
            }));

            PdfGs.valeurParDefault();
        }

        private void cas_4()
        {
            Edition.importPhoto(Globale.CheminPhoto);

            Globale.Actuelle.Invoke(new MethodInvoker(delegate
            {
                foreach (Control controle in Globale.Actuelle.Controls)
                    if (controle is Label && controle.Name == "lblPhotoEleve")
                        controle.Text = Photo.GetDatePhotos();
            }));
        }

        private void cas_5()
        {
            try
            {
                if (Globale.PbPhoto.Image == null)
                {
                    MessageBox.Show(new Form {TopMost = true}, "Veuillez ajouter une photo");
                }
                else
                {
                    FichierWord.SauvegardeCarteProvisoireWord(Globale.ListeSauvegardeProvisoire.Item1,
                        Globale.ListeSauvegardeProvisoire.Item2,
                        Globale.ListeSauvegardeProvisoire.Item3, Globale.ListeSauvegardeProvisoire.Item4,
                        Globale.ListeSauvegardeProvisoire.Item5);

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
                    log.NomUtilisateur = Globale.NomUtilisateur;
                    log.Action = "à fait une carte provisoire";
                    log.AdMac = macAddress;
                    ClassSql.Db.Insert(log);
                }
            }
            catch
            {
            }
        }
    }
}