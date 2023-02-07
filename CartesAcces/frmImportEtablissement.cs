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
        private Etablissement etaDebut;

        public frmImportEtablissement()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            int result;
            if (!int.TryParse(txtNumRueEtablissement.Text, out result))
            {
                textBox1.Text = string.Empty;
                MessageBox.Show("Entrer un nume.");
            }
            if (etaDebut != null)
            {
                if (etaDebut.NomEtablissement != txtNomEtablissement.Text)
                {
                    ClassSql.Db.GetTable<Etablissement>().Where(x => x.NomEtablissement == etaDebut.NomEtablissement).Delete();
                    ClassSql.Db.GetTable<Etablissement>().Delete();
                }
            }
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
            etablissement.Bordure = cbBordure.Checked;
            ClassSql.Db.InsertOrReplace(etablissement);
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
            log.Action = "à modifier les informations de établissement";
            log.AdMac = macAddress;
            ClassSql.Db.Insert(log);
            MessageBox.Show(new Form { TopMost = true }, "Les informations de l'établissement ont été modifiées");
            Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void frmImportEtablissement_Load(object sender, EventArgs e)
        {
            try
            {
                etaDebut = ClassSql.Db.GetTable<Etablissement>().FirstOrDefault();
                txtNomEtablissement.Text = etaDebut.NomEtablissement;
                txtMailEtablissement.Text = etaDebut.EmailEtablissement;
                txtRueEtablissement.Text = etaDebut.NomRueEtablissement;
                txtTelEtablissement.Text = etaDebut.NumeroTelephoneEtablissement;
                txtVilleEtablissement.Text = etaDebut.VilleEtablissement;
                txtCodePostalEtablissement.Text = etaDebut.CodePostaleEtablissement;
                txtNumRueEtablissement.Text = etaDebut.NumeroRueEtablissement.ToString();
                textBox1.Text = etaDebut.UrlEtablissement;
                cbBordure.Checked = etaDebut.Bordure;
                var codeHexa6eme = etaDebut.CodeHexa6eme;
                var codeHexa5eme = etaDebut.CodeHexa5eme;
                var codeHexa4eme = etaDebut.CodeHexa4eme;
                var codeHexa3eme = etaDebut.CodeHexa3eme;
                foreach (var VARIABLE in gb6eme.Controls)
                    if (VARIABLE is RadioButton)
                    {
                        var rd = VARIABLE as RadioButton;
                        if (rd != null)
                        {
                            if (rd.Text == "Rouge" && codeHexa6eme == "#FF0000")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Vert" && codeHexa6eme == "#90EE90")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Bleu" && codeHexa6eme == "#ADD8E6")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Jaune" && codeHexa6eme == "#FFFF00")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Custom")
                            {
                                rd.Checked = true;
                                txtCustom6.Visible = true;
                                txtCustom6.Text = codeHexa6eme;
                            }
                        }
                    }

                foreach (var VARIABLE in gb5eme.Controls)
                    if (VARIABLE is RadioButton)
                    {
                        var rd = VARIABLE as RadioButton;
                        if (rd != null)
                        {
                            if (rd.Text == "Rouge" && codeHexa5eme == "#FF0000")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Vert" && codeHexa5eme == "#90EE90")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Bleu" && codeHexa5eme == "#ADD8E6")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Jaune" && codeHexa5eme == "#FFFF00")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Custom")
                            {
                                rd.Checked = true;
                                txtCustom5.Visible = true;
                                txtCustom5.Text = codeHexa5eme;
                            }
                        }
                    }

                foreach (var VARIABLE in gb4eme.Controls)
                {
                    var rd = VARIABLE as RadioButton;
                    if (rd != null)
                    {
                        if (rd.Text == "Rouge" && codeHexa4eme == "#FF0000")
                        {
                            rd.Checked = true;
                        }
                        else if (rd.Text == "Vert" && codeHexa4eme == "#90EE90")
                        {
                            rd.Checked = true;
                        }
                        else if (rd.Text == "Bleu" && codeHexa4eme == "#ADD8E6")
                        {
                            rd.Checked = true;
                        }
                        else if (rd.Text == "Jaune" && codeHexa4eme == "#FFFF00")
                        {
                            rd.Checked = true;
                        }
                        else if (rd.Text == "Custom")
                        {
                            rd.Checked = true;
                            txtCustom4.Visible = true;
                            txtCustom4.Text = codeHexa4eme;
                        }
                    }
                }

                foreach (var VARIABLE in gb3eme.Controls)
                    if (VARIABLE is RadioButton)
                    {
                        var rd = VARIABLE as RadioButton;
                        if (rd != null)
                        {
                            if (rd.Text == "Rouge" && codeHexa3eme == "#FF0000")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Vert" && codeHexa3eme == "#90EE90")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Bleu" && codeHexa3eme == "#ADD8E6")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Jaune" && codeHexa3eme == "#FFFF00")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Custom")
                            {
                                rd.Checked = true;
                                txtCustom3.Visible = true;
                                txtCustom3.Text = codeHexa3eme;
                            }
                        }
                    }

                textBox1.Text = etaDebut.UrlEtablissement;
            }
            catch
            {
            }
        }

        private string getCodeHexa6eme()
        {
            var codeHexa6eme = "";
            foreach (var VARIABLE in gb6eme.Controls)
                if (VARIABLE is RadioButton)
                {
                    var rd = VARIABLE as RadioButton;
                    if (rd.Checked)
                    {
                        var temp = rd.Text;
                        switch (temp)
                        {
                            case "Rouge":
                                codeHexa6eme = "#FF0000";
                                break;
                            case "Vert":
                                codeHexa6eme = "#90EE90";
                                break;
                            case "Bleu":
                                codeHexa6eme = "#ADD8E6";
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

            return codeHexa6eme;
        }

        private string getCodeHexa5eme()
        {
            var codeHexa5eme = "";
            foreach (var VARIABLE in gb5eme.Controls)
                if (VARIABLE is RadioButton)
                {
                    var rd = VARIABLE as RadioButton;
                    if (rd.Checked)
                    {
                        var temp = rd.Text;
                        switch (temp)
                        {
                            case "Rouge":
                                codeHexa5eme = "#FF0000";
                                break;
                            case "Vert":
                                codeHexa5eme = "#90EE90";
                                break;
                            case "Bleu":
                                codeHexa5eme = "#ADD8E6";
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

            return codeHexa5eme;
        }

        private string getCodeHexa4eme()
        {
            var codeHexa4eme = "";
            foreach (var VARIABLE in gb4eme.Controls)
                if (VARIABLE is RadioButton)
                {
                    var rd = VARIABLE as RadioButton;
                    if (rd.Checked)
                    {
                        var temp = rd.Text;
                        switch (temp)
                        {
                            case "Rouge":
                                codeHexa4eme = "#FF0000";
                                break;
                            case "Vert":
                                codeHexa4eme = "#90EE90";
                                break;
                            case "Bleu":
                                codeHexa4eme = "#ADD8E6";
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

            return codeHexa4eme;
        }

        private string getCodeHexa3eme()
        {
            var codeHexa3eme = "";
            foreach (var VARIABLE in gb3eme.Controls)
                if (VARIABLE is RadioButton)
                {
                    var rd = VARIABLE as RadioButton;
                    if (rd.Checked)
                    {
                        var temp = rd.Text;
                        switch (temp)
                        {
                            case "Rouge":
                                codeHexa3eme = "#FF0000";
                                break;
                            case "Vert":
                                codeHexa3eme = "#90EE90";
                                break;
                            case "Bleu":
                                codeHexa3eme = "#ADD8E6";
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

            return codeHexa3eme;
        }

        private void rdbCustom6_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCustom6.Checked) txtCustom6.Visible = true;
            else
                txtCustom6.Visible = false;
        }

        private void rdbCustom5_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCustom5.Checked) txtCustom5.Visible = true;
            else
                txtCustom5.Visible = false;
        }

        private void rdbCustom4_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCustom4.Checked) txtCustom4.Visible = true;
            else
                txtCustom4.Visible = false;
        }

        private void rdbCustom3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCustom3.Checked) txtCustom3.Visible = true;
            else
                txtCustom3.Visible = false;
        }
    }
}