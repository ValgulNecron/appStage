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
            etablissement.CodeHexa6eme = GetCodeHexa6Eme();
            etablissement.CodeHexa5eme = GetCodeHexa5Eme();
            etablissement.CodeHexa4eme = GetCodeHexa4Eme();
            etablissement.CodeHexa3eme = GetCodeHexa3Eme();
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
                var codeHexa6Eme = etaDebut.CodeHexa6eme;
                var codeHexa5Eme = etaDebut.CodeHexa5eme;
                var codeHexa4Eme = etaDebut.CodeHexa4eme;
                var codeHexa3Eme = etaDebut.CodeHexa3eme;
                foreach (var variable in gb6eme.Controls)
                    if (variable is RadioButton)
                    {
                        var rd = variable as RadioButton;
                        if (rd != null)
                        {
                            if (rd.Text == "Rouge" && codeHexa6Eme == "#FF0000")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Vert" && codeHexa6Eme == "#90EE90")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Bleu" && codeHexa6Eme == "#ADD8E6")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Jaune" && codeHexa6Eme == "#FFFF00")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Custom")
                            {
                                rd.Checked = true;
                                txtCustom6.Visible = true;
                                txtCustom6.Text = codeHexa6Eme;
                            }
                        }
                    }

                foreach (var variable in gb5eme.Controls)
                    if (variable is RadioButton)
                    {
                        var rd = variable as RadioButton;
                        if (rd != null)
                        {
                            if (rd.Text == "Rouge" && codeHexa5Eme == "#FF0000")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Vert" && codeHexa5Eme == "#90EE90")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Bleu" && codeHexa5Eme == "#ADD8E6")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Jaune" && codeHexa5Eme == "#FFFF00")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Custom")
                            {
                                rd.Checked = true;
                                txtCustom5.Visible = true;
                                txtCustom5.Text = codeHexa5Eme;
                            }
                        }
                    }

                foreach (var variable in gb4eme.Controls)
                {
                    var rd = variable as RadioButton;
                    if (rd != null)
                    {
                        if (rd.Text == "Rouge" && codeHexa4Eme == "#FF0000")
                        {
                            rd.Checked = true;
                        }
                        else if (rd.Text == "Vert" && codeHexa4Eme == "#90EE90")
                        {
                            rd.Checked = true;
                        }
                        else if (rd.Text == "Bleu" && codeHexa4Eme == "#ADD8E6")
                        {
                            rd.Checked = true;
                        }
                        else if (rd.Text == "Jaune" && codeHexa4Eme == "#FFFF00")
                        {
                            rd.Checked = true;
                        }
                        else if (rd.Text == "Custom")
                        {
                            rd.Checked = true;
                            txtCustom4.Visible = true;
                            txtCustom4.Text = codeHexa4Eme;
                        }
                    }
                }

                foreach (var variable in gb3eme.Controls)
                    if (variable is RadioButton)
                    {
                        var rd = variable as RadioButton;
                        if (rd != null)
                        {
                            if (rd.Text == "Rouge" && codeHexa3Eme == "#FF0000")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Vert" && codeHexa3Eme == "#90EE90")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Bleu" && codeHexa3Eme == "#ADD8E6")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Jaune" && codeHexa3Eme == "#FFFF00")
                            {
                                rd.Checked = true;
                            }
                            else if (rd.Text == "Custom")
                            {
                                rd.Checked = true;
                                txtCustom3.Visible = true;
                                txtCustom3.Text = codeHexa3Eme;
                            }
                        }
                    }

                textBox1.Text = etaDebut.UrlEtablissement;
            }
            catch
            {
            }
        }

        private string GetCodeHexa6Eme()
        {
            var codeHexa6Eme = "";
            foreach (var variable in gb6eme.Controls)
                if (variable is RadioButton)
                {
                    var rd = variable as RadioButton;
                    if (rd.Checked)
                    {
                        var temp = rd.Text;
                        switch (temp)
                        {
                            case "Rouge":
                                codeHexa6Eme = "#FF0000";
                                break;
                            case "Vert":
                                codeHexa6Eme = "#90EE90";
                                break;
                            case "Bleu":
                                codeHexa6Eme = "#ADD8E6";
                                break;
                            case "Jaune":
                                codeHexa6Eme = "#FFFF00";
                                break;
                            case "Custom":
                                codeHexa6Eme = txtCustom6.Text;
                                break;
                        }
                    }
                }

            return codeHexa6Eme;
        }

        private string GetCodeHexa5Eme()
        {
            var codeHexa5Eme = "";
            foreach (var variable in gb5eme.Controls)
                if (variable is RadioButton)
                {
                    var rd = variable as RadioButton;
                    if (rd.Checked)
                    {
                        var temp = rd.Text;
                        switch (temp)
                        {
                            case "Rouge":
                                codeHexa5Eme = "#FF0000";
                                break;
                            case "Vert":
                                codeHexa5Eme = "#90EE90";
                                break;
                            case "Bleu":
                                codeHexa5Eme = "#ADD8E6";
                                break;
                            case "Jaune":
                                codeHexa5Eme = "#FFFF00";
                                break;
                            case "Custom":
                                codeHexa5Eme = txtCustom5.Text;
                                break;
                        }
                    }
                }

            return codeHexa5Eme;
        }

        private string GetCodeHexa4Eme()
        {
            var codeHexa4Eme = "";
            foreach (var variable in gb4eme.Controls)
                if (variable is RadioButton)
                {
                    var rd = variable as RadioButton;
                    if (rd.Checked)
                    {
                        var temp = rd.Text;
                        switch (temp)
                        {
                            case "Rouge":
                                codeHexa4Eme = "#FF0000";
                                break;
                            case "Vert":
                                codeHexa4Eme = "#90EE90";
                                break;
                            case "Bleu":
                                codeHexa4Eme = "#ADD8E6";
                                break;
                            case "Jaune":
                                codeHexa4Eme = "#FFFF00";
                                break;
                            case "Custom":
                                codeHexa4Eme = txtCustom4.Text;
                                break;
                        }
                    }
                }

            return codeHexa4Eme;
        }

        private string GetCodeHexa3Eme()
        {
            var codeHexa3Eme = "";
            foreach (var variable in gb3eme.Controls)
                if (variable is RadioButton)
                {
                    var rd = variable as RadioButton;
                    if (rd.Checked)
                    {
                        var temp = rd.Text;
                        switch (temp)
                        {
                            case "Rouge":
                                codeHexa3Eme = "#FF0000";
                                break;
                            case "Vert":
                                codeHexa3Eme = "#90EE90";
                                break;
                            case "Bleu":
                                codeHexa3Eme = "#ADD8E6";
                                break;
                            case "Jaune":
                                codeHexa3Eme = "#FFFF00";
                                break;
                            case "Custom":
                                codeHexa3Eme = txtCustom3.Text;
                                break;
                        }
                    }
                }

            return codeHexa3Eme;
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

        private void cbBordure_CheckedChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}