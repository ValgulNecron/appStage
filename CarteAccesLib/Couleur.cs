using System;
using System.Drawing;
using System.Windows.Forms;

//using Org.BouncyCastle.Asn1.Crmf;

namespace CartesAcces
{
    public class Couleur
    {
        public static void setCouleurFenetre(Form fenetre)
        {
            if (Globale._estEnModeSombre)
            {
                fenetre.BackColor = Color.FromArgb(255, Globale._couleurDeFondSombre[0],
                    Globale._couleurDeFondSombre[1], Globale._couleurDeFondSombre[2]);
                foreach (Control controle in fenetre.Controls)
                {
                    if (!(controle is Label || controle is GroupBox || controle is RadioButton ||
                          controle is CheckBox || controle is TrackBar))
                        controle.BackColor = Color.FromArgb(255, Globale._couleurTextBoxSombre[0],
                            Globale._couleurTextBoxSombre[1], Globale._couleurTextBoxSombre[2]);
                    controle.ForeColor = Color.FromArgb(255, Globale._couleurDuTexteSombre[0],
                        Globale._couleurDuTexteSombre[1], Globale._couleurDuTexteSombre[2]);
                    if (controle is Button)
                    {
                        var controle2 = controle as Button;
                        controle2.FlatStyle = FlatStyle.Flat;
                        if (controle2.Enabled)
                            controle.BackColor = Color.FromArgb(255, Globale._couleurBoutonsSombre[0],
                                Globale._couleurBoutonsSombre[1], Globale._couleurBoutonsSombre[2]);
                        else
                            controle.BackColor = Color.FromArgb(255, Globale._couleurBoutonOffSombre[0],
                                Globale._couleurBoutonOffSombre[1], Globale._couleurBoutonOffSombre[2]);
                        controle2.EnabledChanged += changement_state_btn;
                    }

                    if (controle is TextBox)
                    {
                        var controle2 = controle as TextBox;
                        controle2.BorderStyle = BorderStyle.None;
                    }

                    if (controle is Panel) setCouleurPanel(controle as Panel);

                    if (controle is GroupBox) setCouleurGroupeBox(controle as GroupBox);

                    if (controle is ListBox)
                    {
                        var controle2 = controle as ListBox;
                        controle2.BorderStyle = BorderStyle.None;
                    }
                }
            }
            else
            {
                fenetre.BackColor = Color.FromArgb(255, Globale._couleurDeFondClaire[0],
                    Globale._couleurDeFondClaire[1], Globale._couleurDeFondClaire[2]);
                foreach (Control controle in fenetre.Controls)
                {
                    if (!(controle is Label || controle is GroupBox || controle is RadioButton ||
                          controle is CheckBox || controle is TrackBar))
                        controle.BackColor = Color.FromArgb(255, Globale._couleurTextBoxClaire[0],
                            Globale._couleurTextBoxClaire[1], Globale._couleurTextBoxClaire[2]);
                    controle.ForeColor = Color.FromArgb(255, Globale._couleurDuTexteclaire[0],
                        Globale._couleurDuTexteclaire[1], Globale._couleurDuTexteclaire[2]);
                    if (controle is Button)
                    {
                        var controle2 = controle as Button;
                        controle2.FlatStyle = FlatStyle.Flat;
                        if (controle2.Enabled)
                            controle.BackColor = Color.FromArgb(255, Globale._couleurBoutonsClaire[0],
                                Globale._couleurBoutonsClaire[1], Globale._couleurBoutonsClaire[2]);
                        else
                            controle.BackColor = Color.FromArgb(255, Globale._couleurBoutonOffClaire[0],
                                Globale._couleurBoutonOffClaire[1], Globale._couleurBoutonOffClaire[2]);
                        controle2.EnabledChanged += changement_state_btn;
                    }

                    if (controle is TextBox)
                    {
                        var controle2 = controle as TextBox;
                        controle2.BorderStyle = BorderStyle.None;
                    }

                    if (controle is Panel) setCouleurPanel(controle as Panel);

                    if (controle is GroupBox) setCouleurGroupeBox(controle as GroupBox);

                    if (controle is ListBox)
                    {
                        var controle2 = controle as ListBox;
                        controle2.BorderStyle = BorderStyle.None;
                    }
                }
            }
        }

        public static void setCouleurPanel(Panel panel)
        {
            if (Globale._estEnModeSombre)
                foreach (Control controle in panel.Controls)
                {
                    if (!(controle is Label || controle is GroupBox || controle is RadioButton ||
                          controle is CheckBox || controle is TrackBar))
                        controle.BackColor = Color.FromArgb(255, Globale._couleurTextBoxSombre[0],
                            Globale._couleurTextBoxSombre[1], Globale._couleurTextBoxSombre[2]);
                    controle.ForeColor = Color.FromArgb(255, Globale._couleurDuTexteSombre[0],
                        Globale._couleurDuTexteSombre[1], Globale._couleurDuTexteSombre[2]);
                    if (controle is Button)
                    {
                        var controle2 = controle as Button;
                        controle2.FlatStyle = FlatStyle.Flat;
                        if (controle2.Enabled)
                            controle.BackColor = Color.FromArgb(255, Globale._couleurBoutonsSombre[0],
                                Globale._couleurBoutonsSombre[1], Globale._couleurBoutonsSombre[2]);
                        else
                            controle.BackColor = Color.FromArgb(255, Globale._couleurBoutonOffSombre[0],
                                Globale._couleurBoutonOffSombre[1], Globale._couleurBoutonOffSombre[2]);
                        controle2.EnabledChanged += changement_state_btn;
                    }

                    if (controle is TextBox)
                    {
                        var controle2 = controle as TextBox;
                        controle2.BorderStyle = BorderStyle.None;
                    }

                    if (controle is Panel) setCouleurPanel(controle as Panel);

                    if (controle is GroupBox) setCouleurGroupeBox(controle as GroupBox);

                    if (controle is ListBox)
                    {
                        var controle2 = controle as ListBox;
                        controle2.BorderStyle = BorderStyle.None;
                    }
                }
            else
                foreach (Control controle in panel.Controls)
                {
                    if (!(controle is Label || controle is GroupBox || controle is RadioButton ||
                          controle is CheckBox || controle is TrackBar))
                        controle.BackColor = Color.FromArgb(255, Globale._couleurTextBoxClaire[0],
                            Globale._couleurTextBoxClaire[1], Globale._couleurTextBoxClaire[2]);
                    controle.ForeColor = Color.FromArgb(255, Globale._couleurDuTexteclaire[0],
                        Globale._couleurDuTexteclaire[1], Globale._couleurDuTexteclaire[2]);
                    if (controle is Button)
                    {
                        var controle2 = controle as Button;
                        controle2.FlatStyle = FlatStyle.Flat;
                        if (controle2.Enabled)
                            controle.BackColor = Color.FromArgb(255, Globale._couleurBoutonsClaire[0],
                                Globale._couleurBoutonsClaire[1], Globale._couleurBoutonsClaire[2]);
                        else
                            controle.BackColor = Color.FromArgb(255, Globale._couleurBoutonOffClaire[0],
                                Globale._couleurBoutonOffClaire[1], Globale._couleurBoutonOffClaire[2]);
                        controle2.EnabledChanged += changement_state_btn;
                    }

                    if (controle is TextBox)
                    {
                        var controle2 = controle as TextBox;
                        controle2.BorderStyle = BorderStyle.None;
                    }

                    if (controle is Panel) setCouleurPanel(controle as Panel);

                    if (controle is GroupBox) setCouleurGroupeBox(controle as GroupBox);

                    if (controle is ListBox)
                    {
                        var controle2 = controle as ListBox;
                        controle2.BorderStyle = BorderStyle.None;
                    }
                }
        }

        public static void setCouleurGroupeBox(GroupBox groupeBox)
        {
            if (Globale._estEnModeSombre)
                foreach (Control controle in groupeBox.Controls)
                {
                    if (!(controle is Label || controle is GroupBox || controle is RadioButton ||
                          controle is CheckBox || controle is TrackBar))
                        controle.BackColor = Color.FromArgb(255, Globale._couleurTextBoxSombre[0],
                            Globale._couleurTextBoxSombre[1], Globale._couleurTextBoxSombre[2]);
                    controle.ForeColor = Color.FromArgb(255, Globale._couleurDuTexteSombre[0],
                        Globale._couleurDuTexteSombre[1], Globale._couleurDuTexteSombre[2]);
                    if (controle is Button)
                    {
                        var controle2 = controle as Button;
                        controle2.FlatStyle = FlatStyle.Flat;
                        if (controle2.Enabled)
                            controle.BackColor = Color.FromArgb(255, Globale._couleurBoutonsSombre[0],
                                Globale._couleurBoutonsSombre[1], Globale._couleurBoutonsSombre[2]);
                        else
                            controle.BackColor = Color.FromArgb(255, Globale._couleurBoutonOffSombre[0],
                                Globale._couleurBoutonOffSombre[1], Globale._couleurBoutonOffSombre[2]);
                        controle2.EnabledChanged += changement_state_btn;
                    }

                    if (controle is TextBox)
                    {
                        var controle2 = controle as TextBox;
                        controle2.BorderStyle = BorderStyle.None;
                    }

                    if (controle is Panel) setCouleurPanel(controle as Panel);

                    if (controle is GroupBox) setCouleurGroupeBox(controle as GroupBox);

                    if (controle is ListBox)
                    {
                        var controle2 = controle as ListBox;
                        controle2.BorderStyle = BorderStyle.None;
                    }
                }
            else
                foreach (Control controle in groupeBox.Controls)
                {
                    if (!(controle is Label || controle is GroupBox || controle is RadioButton ||
                          controle is CheckBox || controle is TrackBar))
                        controle.BackColor = Color.FromArgb(255, Globale._couleurTextBoxClaire[0],
                            Globale._couleurTextBoxClaire[1], Globale._couleurTextBoxClaire[2]);
                    controle.ForeColor = Color.FromArgb(255, Globale._couleurDuTexteclaire[0],
                        Globale._couleurDuTexteclaire[1], Globale._couleurDuTexteclaire[2]);
                    if (controle is Button)
                    {
                        var controle2 = controle as Button;
                        controle2.FlatStyle = FlatStyle.Flat;
                        if (controle2.Enabled)
                            controle.BackColor = Color.FromArgb(255, Globale._couleurBoutonsClaire[0],
                                Globale._couleurBoutonsClaire[1], Globale._couleurBoutonsClaire[2]);
                        else
                            controle.BackColor = Color.FromArgb(255, Globale._couleurBoutonOffClaire[0],
                                Globale._couleurBoutonOffClaire[1], Globale._couleurBoutonOffClaire[2]);
                        controle2.EnabledChanged += changement_state_btn;
                    }

                    if (controle is TextBox)
                    {
                        var controle2 = controle as TextBox;
                        controle2.BorderStyle = BorderStyle.None;
                    }

                    if (controle is Panel) setCouleurPanel(controle as Panel);

                    if (controle is GroupBox) setCouleurGroupeBox(controle as GroupBox);

                    if (controle is ListBox)
                    {
                        var controle2 = controle as ListBox;
                        controle2.BorderStyle = BorderStyle.None;
                    }
                }
        }

        public static void changement_state_btn(object sender, EventArgs e)
        {
            Button btn;
            try
            {
                btn = sender as Button;
            }
            catch
            {
                return;
            }

            if (btn != null && btn.Enabled)
            {
                if (Globale._estEnModeSombre)
                    btn.BackColor = Color.FromArgb(255, Globale._couleurBoutonsSombre[0],
                        Globale._couleurBoutonsSombre[1], Globale._couleurBoutonsSombre[2]);
                else
                    btn.BackColor = Color.FromArgb(255, Globale._couleurBoutonsClaire[0],
                        Globale._couleurBoutonsClaire[1], Globale._couleurBoutonsClaire[2]);
            }
            else if (btn != null)
            {
                if (Globale._estEnModeSombre)
                    btn.BackColor = Color.FromArgb(255, Globale._couleurBoutonOffSombre[0],
                        Globale._couleurBoutonOffSombre[1], Globale._couleurBoutonOffSombre[2]);
                else
                    btn.BackColor = Color.FromArgb(255, Globale._couleurBoutonOffClaire[0],
                        Globale._couleurBoutonOffClaire[1], Globale._couleurBoutonOffClaire[2]);
            }
        }
    }
}