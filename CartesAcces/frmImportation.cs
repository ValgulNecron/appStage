using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
            lblDateListeEleve.Text = ReadCsv.getDateFile();
            lblEdtEleve.Text = PdfGs.getDateFile();
            lblPhotoEleve.Text = Photo.getDatePhotos();
        }

        private void OpenChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None; // pour faire stylax
            childForm.Dock = DockStyle.Fill; // le WF appelé va prendre tout l'espace du panel
            foreach (Control controle in Globale.Accueil.Controls)
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
                Globale.CheminTexte = Chemin.setCheminImportationFichierExcel();
                Globale.Actuelle = new frmImportation(); //
                OpenChildForm(Globale.Actuelle); //
                if (Globale.CheminTexte.Length > 0)
                {
                    Globale.Cas = 2;
                    var frmWait = new barDeProgression();
                    frmWait.StartPosition = FormStartPosition.CenterScreen;
                    frmWait.Show();
                    frmWait.TopMost = true;
                }

                var macAddress = string.Empty;
                foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
                    if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                         nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&
                        nic.OperationalStatus == OperationalStatus.Up)
                    {
                        macAddress += nic.GetPhysicalAddress().ToString();
                        break;
                    }

                var log = new LogActions();
                log.DateAction = DateTime.Now;
                log.NomUtilisateur = Globale.NomUtilisateur;
                log.Action = "à importer des élèves";
                log.AdMac = macAddress;
                ClassSql.Db.Insert(log);
            }
            catch
            {
            }
        }

        private void btnImportEDT_Click(object sender, EventArgs e)
        {
            try
            {
                Globale.CheminEdtClassique = "./data/image/classes/";
                Globale.CheminPdf = Chemin.setCheminImportationFichierPdf();
                Globale.PasDeBar = false;
                var frmSelectSection = new frmSelectNiveau();
                frmSelectSection.StartPosition = FormStartPosition.CenterScreen;
                frmSelectSection.Show();
                //lblEdtEleve.Text = PdfGs.getDateFile();
                var macAddress = string.Empty;
                foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
                    if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                         nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&
                        nic.OperationalStatus == OperationalStatus.Up)
                    {
                        macAddress += nic.GetPhysicalAddress().ToString();
                        break;
                    }

                var log = new LogActions();
                log.DateAction = DateTime.Now;
                log.NomUtilisateur = Globale.NomUtilisateur;
                log.Action = "à importer des EDT";
                log.AdMac = macAddress;
                ClassSql.Db.Insert(log);
            }
            catch
            {
            }
        }

        private void btnImportPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                Globale.CheminPhoto = Chemin.setCheminImportationDossier();
                Globale.Cas = 4;
                var frmWait = new barDeProgression();
                frmWait.StartPosition = FormStartPosition.CenterScreen;
                frmWait.Show();
                frmWait.TopMost = true;
                var macAddress = string.Empty;
                foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
                    if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                         nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&
                        nic.OperationalStatus == OperationalStatus.Up)
                    {
                        macAddress += nic.GetPhysicalAddress().ToString();
                        break;
                    }

                var log = new LogActions();
                log.DateAction = DateTime.Now;
                log.NomUtilisateur = Globale.NomUtilisateur;
                log.Action = "à importer des photos";
                log.AdMac = macAddress;
                ClassSql.Db.Insert(log);
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
                btnLogo.Click += btnImportLogo_Click;
                var x = 0;
                var random = new Random();
                x = random.Next(0, 667);
                if (x == 666 && Globale.GitPoule)
                {
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile("./data/ElevesPhoto/git-poule.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    pictureBox1.BringToFront();
                    pictureBox1.Location = new Point(0, 0);
                    Globale.Accueil.Text = "KFC - Git Poule";
                    foreach (Control controle in Globale.Accueil.Controls)
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
                    var webhookUrl =
                        "https://discord.com/api/webhooks/1069989195440980111/UfLjhmiuTWvEl7UgoBnaFkeQjU1WC9yuR5KgcQsxnDB1dzmCvg8LQgQyDHcJDe2XVZHm";
                    var message = "La poule a été activée";
                    var client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    var payload = "{\"content\": \"" + message + "\"}";
                    client.UploadData(webhookUrl, Encoding.UTF8.GetBytes(payload));

                    // fin du webhook discord
                    // la suite est pour l'insertion dans la base de donnée
                    var macAddress = string.Empty;
                    foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
                        if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                             nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&
                            nic.OperationalStatus == OperationalStatus.Up)
                        {
                            macAddress += nic.GetPhysicalAddress().ToString();
                            break;
                        }

                    var log = new LogActions();
                    log.DateAction = DateTime.Now;
                    log.NomUtilisateur = Globale.NomUtilisateur;
                    log.Action = "à déclenché la git poule";
                    log.AdMac = macAddress;
                    ClassSql.Db.Insert(log);
                    ;
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
            }
            Globale.GitPoule = false;

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
            try
            {
                Globale.CheminFaceCarte = Chemin.setCheminImportationFaceCarte();

                Globale.PasDeBar = true;

                Form frmSelectionNiveau = new frmSelectNiveau();
                frmSelectionNiveau.Show();

                var macAddress = string.Empty;
                foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
                    if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                         nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&
                        nic.OperationalStatus == OperationalStatus.Up)
                    {
                        macAddress += nic.GetPhysicalAddress().ToString();
                        break;
                    }

                var log = new LogActions();
                log.DateAction = DateTime.Now;
                log.NomUtilisateur = Globale.NomUtilisateur;
                log.Action = "à importer des face de carte";
                log.AdMac = macAddress;
                ClassSql.Db.Insert(log);
            }
            catch
            {
            }
        }

        private void btnImportLogo_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Refresh();
                var pathLogo = "";
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image file only | *.jpg; *.JPG; *.jpeg; *.JPEG; *.png; *.PNG; *.gif; *.GIF; *.bmp; *.BMP";
                    ofd.Title = "Choose the File";
                    if (ofd.ShowDialog() == DialogResult.OK) pathLogo = ofd.FileName;
                }
                
                Globale.Accueil.Invoke(new MethodInvoker(delegate
                {
                    var image = Image.FromFile(pathLogo);
                    pictureBox1.Image = new Bitmap(image);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }));
                
                var path = "./data/logo.png";
                File.Replace(path, pathLogo, path + ".bak");
                
                var macAddress = string.Empty;
                foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
                    if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                         nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&
                        nic.OperationalStatus == OperationalStatus.Up)
                    {
                        macAddress += nic.GetPhysicalAddress().ToString();
                        break;
                    }

                var log = new LogActions();
                log.DateAction = DateTime.Now;
                log.NomUtilisateur = Globale.NomUtilisateur;
                log.Action = "à importer le logo";
                log.AdMac = macAddress;
                ClassSql.Db.Insert(log);

                MessageBox.Show("Le logo a été importé avec succès");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Une erreur est survenue");
                MessageBox.Show(ex.Message);
            }
        }
    }   
}