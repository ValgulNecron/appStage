using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using LinqToDB;

namespace CartesAcces
{
    /*
     * permet de créer l'etablissement dans la base de données
     * si l'etablissement existe déjà, il est modifié
     * si l'etablissement n'existe pas, il est créé
     */
    public partial class frmImportEtablissement : Form
    {
        public frmImportEtablissement()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            var etablissement = new Etablissement();
            etablissement.NomEtablissement = txtNomEtablissement.Text;
            etablissement.NomRueEtablissement = txtRueEtablissement.Text;
            etablissement.EmailEtablissement = txtMailEtablissement.Text;
            etablissement.VilleEtablissement = txtVilleEtablissement.Text;
            etablissement.CodePostaleEtablissement = txtCodePostalEtablissement.Text;
            etablissement.NumeroTelephoneEtablissement = txtTelEtablissement.Text;
            etablissement.NumeroRueEtablissement = Convert.ToInt32(txtNumRueEtablissement.Text);
            etablissement.UrlEtablissement = textBox1.Text;
            etablissement.CodeHexa6eme = getCodeHexa6eme();
            etablissement.CodeHexa5eme = getCodeHexa5eme();
            etablissement.CodeHexa4eme = getCodeHexa4eme();
            etablissement.CodeHexa3eme = getCodeHexa3eme();
            ClassSql.db.InsertOrReplace(etablissement);
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
            log.NomUtilisateur = Globale._nomUtilisateur;
            log.Action = "à modifier les informations de établissement";
            log.AdMac = macAddress;
            ClassSql.db.Insert(log);
            MessageBox.Show("Les informations de l'établissement ont été modifiées");
            Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void frmImportEtablissement_Load(object sender, EventArgs e)
        {
            try
            {
                var eta = ClassSql.db.GetTable<Etablissement>().FirstOrDefault();
                txtNomEtablissement.Text = eta.NomEtablissement;
                txtMailEtablissement.Text = eta.EmailEtablissement;
                txtRueEtablissement.Text = eta.NomRueEtablissement;
                txtTelEtablissement.Text = eta.NumeroTelephoneEtablissement;
                txtVilleEtablissement.Text = eta.VilleEtablissement;
                txtCodePostalEtablissement.Text = eta.CodePostaleEtablissement;
                txtNumRueEtablissement.Text = eta.NumeroRueEtablissement.ToString();
                var codeHexa6eme = eta.CodeHexa6eme;
                var codeHexa5eme = eta.CodeHexa5eme;
                var codeHexa4eme = eta.CodeHexa4eme;
                var codeHexa3eme = eta.CodeHexa3eme;
                textBox1.Text = eta.UrlEtablissement;
                txtNumRueEtablissement.KeyPress += keyPress;
            }
            catch
            {
            }
        }
        
          private string getCodeHexa6eme()
        {
            string codeHexa6eme = "";
            foreach (var VARIABLE in gb6eme.Controls)
            {
                if (VARIABLE is RadioButton)
                {
                    RadioButton rd = VARIABLE as RadioButton;
                    if (rd.Checked)
                    {
                        string temp = rd.Text;
                        switch (temp)
                        {
                            case "Rouge":
                                codeHexa6eme = "#FF0000";
                                break;
                            case "Vert":
                                codeHexa6eme = "#00FF00";
                                break;
                            case "Bleu":
                                codeHexa6eme = "#0000FF";
                                break;
                            case "Jaune":
                                codeHexa6eme = "#FFFF00";
                                break;
                            case "Custom":
                                codeHexa6eme = txtCustom6.Text;
                                break;
                        }
                    }
                }
            }
            return codeHexa6eme;
        }
        
        private string getCodeHexa5eme()
        {
            string codeHexa5eme = "";
            foreach (var VARIABLE in gb5eme.Controls)
            {
                if (VARIABLE is RadioButton)
                {
                    RadioButton rd = VARIABLE as RadioButton;
                    if (rd.Checked)
                    {
                        string temp = rd.Text;
                        switch (temp)
                        {
                            case "Rouge":
                                codeHexa5eme = "#FF0000";
                                break;
                            case "Vert":
                                codeHexa5eme = "#00FF00";
                                break;
                            case "Bleu":
                                codeHexa5eme = "#0000FF";
                                break;
                            case "Jaune":
                                codeHexa5eme = "#FFFF00";
                                break;
                            case "Custom":
                                codeHexa5eme = txtCustom5.Text;
                                break;
                        }
                    }
                }
            }
            return codeHexa5eme;
        }
        
        private string getCodeHexa4eme()
        {
            string codeHexa4eme = "";
            foreach (var VARIABLE in gb4eme.Controls)
            {
                if (VARIABLE is RadioButton)
                {
                    RadioButton rd = VARIABLE as RadioButton;
                    if (rd.Checked)
                    {
                        string temp = rd.Text;
                        switch (temp)
                        {
                            case "Rouge":
                                codeHexa4eme = "#FF0000";
                                break;
                            case "Vert":
                                codeHexa4eme = "#00FF00";
                                break;
                            case "Bleu":
                                codeHexa4eme = "#0000FF";
                                break;
                            case "Jaune":
                                codeHexa4eme = "#FFFF00";
                                break;
                            case "Custom":
                                codeHexa4eme = txtCustom4.Text;
                                break;
                        }
                    }
                }
            }
            return codeHexa4eme;
        }
        
        private string getCodeHexa3eme()
        {
            string codeHexa3eme = "";
            foreach (var VARIABLE in gb3eme.Controls)
            {
                if (VARIABLE is RadioButton)
                {
                    RadioButton rd = VARIABLE as RadioButton;
                    if (rd.Checked)
                    {
                        string temp = rd.Text;
                        switch (temp)
                        {
                            case "Rouge":
                                codeHexa3eme = "#FF0000";
                                break;
                            case "Vert":
                                codeHexa3eme = "#00FF00";
                                break;
                            case "Bleu":
                                codeHexa3eme = "#0000FF";
                                break;
                            case "Jaune":
                                codeHexa3eme = "#FFFF00";
                                break;
                            case "Custom":
                                codeHexa3eme = txtCustom3.Text;
                                break;
                        }
                    }
                }
            }
            return codeHexa3eme;
        }
        
        private void keyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}