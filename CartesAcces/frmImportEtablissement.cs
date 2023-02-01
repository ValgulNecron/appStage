using System;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using LinqToDB;

namespace CartesAcces
{
    public partial class frmImportEtablissement : Form
    {
        public frmImportEtablissement()
        {
            InitializeComponent();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            Etablissement etablissement = new Etablissement();
            etablissement.NomEtablissement = txtNomEtablissement.Text;
            etablissement.NomRueEtablissement = txtRueEtablissement.Text;
            etablissement.EmailEtablissement = txtMailEtablissement.Text;
            etablissement.VilleEtablissement = txtVilleEtablissement.Text;
            etablissement.CodePostaleEtablissement = txtCodePostalEtablissement.Text;
            etablissement.NumeroTelephoneEtablissement = txtTelEtablissement.Text;
            etablissement.NumeroRueEtablissement = Convert.ToInt32(txtNumRueEtablissement.Text);
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
            log.Action = "à modifier les informations de établissement";
            log.AdMac = macAddress;
            ClassSql.db.Insert(log);
        }
    }
}