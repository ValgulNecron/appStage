using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CarteAcces;
using LinqToDB;

namespace CartesAcces
{
    /*
     * fenêtre d'imporation des données
     * elle permet de rediriger vers les fenêtres d'importation des données
     * elle permet de vérifier si les données sont à jour
     * elle permet de mettre à jour les données
     */
    public partial class frmImportation : Form
    {
        public frmImportation()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
            //TailleControle.setTailleControleTexte(this);
            //TailleControle.setTailleControleLabel(this);
            //TailleControle.setTailleBouton(this);
            lblDateListeEleve.Text = ReadCSV.getDateFile();
            lblEdtEleve.Text = PdfGs.getDateFile();
            lblPhotoEleve.Text = Photo.getDatePhotos();
        }

        private void OpenChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None; // pour faire stylax
            childForm.Dock = DockStyle.Fill; // le WF appelé va prendre tout l'espace du panel
            foreach (Control controle in Globale._accueil.Controls)
                if (controle is Panel && controle.Name == "pnlContent")
                {
                    var pnlContent = controle as Panel;
                    pnlContent.Controls.Add(childForm); // reprend les éléments de l'ITF du windows forms
                    pnlContent.Tag = childForm; // reprend les propriétés de chaque éléments de l'ITF de la classe(WF)
                }


            childForm.BringToFront(); // ramène la WF appélé en avant-plan pour une WF déjà appelé
            childForm.Show(); // lorsque la WF est appelé pour la première fois
        }

        // ### Controls ###

        private void btnImporterEleves_Click(object sender, EventArgs e)
        {
            try
            {
                //lblDateListeEleve = Globale._lblDate;
                Globale._cheminTexte = Chemin.setCheminImportationFichierExcel();
                Globale._actuelle = new frmImportation(); //
                OpenChildForm(Globale._actuelle); //
                if (Globale._cheminTexte.Length > 0)
                {
                    Globale._cas = 2;
                    var frmWait = new barDeProgression();
                    frmWait.StartPosition = FormStartPosition.Manual;
                    frmWait.Location = new Point(0, 0);
                    frmWait.Show();
                    frmWait.TopMost = true;
                }
                string macAddress = string.Empty;
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet || nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&     nic.OperationalStatus == OperationalStatus.Up)
                    {
                        macAddress += nic.GetPhysicalAddress().ToString();
                        break;
                    }
                }
                var log = new LogActions();
                log.DateAction = DateTime.Now;
                log.NomUtilisateur = Globale._nomUtilisateur;
                log.Action = "à importer des élèves";
                log.AdMac = macAddress;
                ClassSql.db.Insert(log);
            }
            catch
            {
            }
        }

        private void btnImportEDT_Click(object sender, EventArgs e)
        {
            try
            {
                Globale._cheminPdf = Chemin.setCheminImportationFichierPdf();
                var frmSelectSection = new frmSelectNiveau();
                frmSelectSection.StartPosition = FormStartPosition.CenterScreen;
                frmSelectSection.Show();
                //lblEdtEleve.Text = PdfGs.getDateFile();
                string macAddress = string.Empty;
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet || nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&     nic.OperationalStatus == OperationalStatus.Up)
                    {
                        macAddress += nic.GetPhysicalAddress().ToString();
                        break;
                    }
                }
                var log = new LogActions();
                log.DateAction = DateTime.Now;
                log.NomUtilisateur = Globale._nomUtilisateur;
                log.Action = "à importer des EDT";
                log.AdMac = macAddress;
                ClassSql.db.Insert(log);
            }
            catch
            {
            }
        }

        private void btnImportPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                Globale._cheminPhoto = Chemin.setCheminImportationDossier();
                Globale._cas = 4;
                var frmWait = new barDeProgression();
                frmWait.StartPosition = FormStartPosition.Manual;
                frmWait.Location = new Point(0, 0);
                frmWait.Show();
                frmWait.TopMost = true;
                string macAddress = string.Empty;
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                         nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&
                        nic.OperationalStatus == OperationalStatus.Up)
                    {
                        macAddress += nic.GetPhysicalAddress().ToString();
                        break;
                    }
                }

                var log = new LogActions();
                log.DateAction = DateTime.Now;
                log.NomUtilisateur = Globale._nomUtilisateur;
                log.Action = "à importer des photos";
                log.AdMac = macAddress;
                ClassSql.db.Insert(log);
            }
            catch
            {
            }
        }

        private void btnImportEdtClassique_Click(object sender, EventArgs e)
        {
            try
            {
                lblImportEdtClassique = Globale._lblDate;
                Globale._cheminEdtClassique = Chemin.setCheminImportationEdtClassique();
                Edition.importEdtClassique(Globale._cheminEdtClassique);

                var frmRognageEdtClassique = new frmRognageEdtClassique();
                frmRognageEdtClassique.Show();
                string macAddress = string.Empty;
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet || nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&     nic.OperationalStatus == OperationalStatus.Up)
                    {
                        macAddress += nic.GetPhysicalAddress().ToString();
                        break;
                    }
                }
                var log = new LogActions();
                log.DateAction = DateTime.Now;
                log.NomUtilisateur = Globale._nomUtilisateur;
                log.Action = "à importer des EDT classiques";
                log.AdMac = macAddress;
                ClassSql.db.Insert(log);
            }
            catch
            {
            }
        }

        
        /*
         * ceci est le load de la fenêtre importation
         * elle contient un easteregg ayant 1 chance sur 2 000 000 000 de se déclencher
         * si le nombre généré est 666 et que la variable globale _gitPoule est à true
         */
        private void frmParametres_Load(object sender, EventArgs e)
        {
            try
            {
                var x = 0;
                var random = new Random();
                x = random.Next(0, 666);
                if ((x == 666) && Globale._gitPoule)
                {
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile("./git-poule.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    pictureBox1.BringToFront();
                    pictureBox1.Location = new Point(0, 0);
                    Globale._accueil.Text = "KFC - Git Poule";
                    foreach (Control controle in Globale._accueil.Controls)
                        if (controle is Panel && controle.Name == "pnlMenu")
                        {
                            controle.BackColor = Color.DeepPink;
                            foreach (Control controle2 in controle.Controls)
                            {
                                if (controle2 is Button) controle2.Text = "Créer un poulet";

                                if (controle2 is Label) controle2.ForeColor = Color.White;
                            }
                        }
                    var url = "https://www.youtube.com/watch?v=msSc7Mv0QHY";
                    Thread.Sleep(4000);
                    Process.Start("microsoft-edge:", url);
                    // ne pas supprimer, c'est pour le webhook discord 
                    // si vous voulez etre averti quand la poule est activée rajoutez votre webhook discord en plus de celui ci
                    string webhookUrl = "https://discord.com/api/webhooks/1069989195440980111/UfLjhmiuTWvEl7UgoBnaFkeQjU1WC9yuR5KgcQsxnDB1dzmCvg8LQgQyDHcJDe2XVZHm";
                    string message = "La poule a été activée";
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    string payload = "{\"content\": \"" + message + "\"}";
                    client.UploadData(webhookUrl, Encoding.UTF8.GetBytes(payload));
                    
                    // fin du webhook discord
                    // la suite est pour l'insertion dans la base de donnée
                    string macAddress = string.Empty;
                    foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                    {
                        if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet || nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&     nic.OperationalStatus == OperationalStatus.Up)
                        {
                            macAddress += nic.GetPhysicalAddress().ToString();
                            break;
                        }
                    }
                    var log = new LogActions();
                    log.DateAction = DateTime.Now;
                    log.NomUtilisateur = Globale._nomUtilisateur;
                    log.Action = "à déclenché la git poule";
                    log.AdMac = macAddress;
                    ClassSql.db.Insert(log); ;
                    Application.Exit();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImporterUnEtablissement_Click(object sender, EventArgs e)
        {
            Form frmImportEtab = new frmImportEtablissement();
            frmImportEtab.Show();
        }

        private void btCreationUtilisateur_Click(object sender, EventArgs e)
        {
            Form frmCreationUtilisateur = new frmCreationUtilisateur();
            frmCreationUtilisateur.Show();
        }

        private void btnImportFaceCarte_Click(object sender, EventArgs e)
        {
            
            
            string macAddress = string.Empty;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet || nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&     nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddress += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            var log = new LogActions();
            log.DateAction = DateTime.Now;
            log.NomUtilisateur = Globale._nomUtilisateur;
            log.Action = "à importer des face de carte";
            log.AdMac = macAddress;
            ClassSql.db.Insert(log);
        }

        private void btnImportLogo_Click(object sender, EventArgs e)
        {
            string macAddress = string.Empty;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet || nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&     nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddress += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            var log = new LogActions();
            log.DateAction = DateTime.Now;
            log.NomUtilisateur = Globale._nomUtilisateur;
            log.Action = "à importer le logo de l'etablissement";
            log.AdMac = macAddress;
            ClassSql.db.Insert(log);
        }
    }
}