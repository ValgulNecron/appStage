using System;
using System.Drawing;
using System.Windows.Forms;


namespace CartesAcces
{
    public static class Couleur
    {
        public static void setCouleurFenetre(Form fenetre)
        {
            if (Globale.EstEnModeSombre)
            {
                fenetre.BackColor = Color.FromArgb(255, Globale.CouleurDeFondSombre[0],
                    Globale.CouleurDeFondSombre[1], Globale.CouleurDeFondSombre[2]);
                foreach (Control controle in fenetre.Controls)
                {
                    if (!(controle is Label || controle is GroupBox || controle is RadioButton ||
                          controle is CheckBox || controle is TrackBar))
                        controle.BackColor = Color.FromArgb(255, Globale.CouleurTextBoxSombre[0],
                            Globale.CouleurTextBoxSombre[1], Globale.CouleurTextBoxSombre[2]);
                    controle.ForeColor = Color.FromArgb(255, Globale.CouleurDuTexteSombre[0],
                        Globale.CouleurDuTexteSombre[1], Globale.CouleurDuTexteSombre[2]);
                    if (controle is Button)
                    {
                        var controle2 = controle as Button;
                        controle2.FlatStyle = FlatStyle.Flat;
                        if (controle2.Enabled)
                            controle.BackColor = Color.FromArgb(255, Globale.CouleurBoutonsSombre[0],
                                Globale.CouleurBoutonsSombre[1], Globale.CouleurBoutonsSombre[2]);
                        else
                            controle.BackColor = Color.FromArgb(255, Globale.CouleurBoutonOffSombre[0],
                                Globale.CouleurBoutonOffSombre[1], Globale.CouleurBoutonOffSombre[2]);
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
                fenetre.BackColor = Color.FromArgb(255, Globale.CouleurDeFondClaire[0],
                    Globale.CouleurDeFondClaire[1], Globale.CouleurDeFondClaire[2]);
                foreach (Control controle in fenetre.Controls)
                {
                    if (!(controle is Label || controle is GroupBox || controle is RadioButton ||
                          controle is CheckBox || controle is TrackBar))
                        controle.BackColor = Color.FromArgb(255, Globale.CouleurTextBoxClaire[0],
                            Globale.CouleurTextBoxClaire[1], Globale.CouleurTextBoxClaire[2]);
                    controle.ForeColor = Color.FromArgb(255, Globale.CouleurDuTexteclaire[0],
                        Globale.CouleurDuTexteclaire[1], Globale.CouleurDuTexteclaire[2]);
                    if (controle is Button)
                    {
                        var controle2 = controle as Button;
                        controle2.FlatStyle = FlatStyle.Flat;
                        if (controle2.Enabled)
                            controle.BackColor = Color.FromArgb(255, Globale.CouleurBoutonsClaire[0],
                                Globale.CouleurBoutonsClaire[1], Globale.CouleurBoutonsClaire[2]);
                        else
                            controle.BackColor = Color.FromArgb(255, Globale.CouleurBoutonOffClaire[0],
                                Globale.CouleurBoutonOffClaire[1], Globale.CouleurBoutonOffClaire[2]);
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
            if (Globale.EstEnModeSombre)
                foreach (Control controle in panel.Controls)
                {
                    if (!(controle is Label || controle is GroupBox || controle is RadioButton ||
                          controle is CheckBox || controle is TrackBar))
                        controle.BackColor = Color.FromArgb(255, Globale.CouleurTextBoxSombre[0],
                            Globale.CouleurTextBoxSombre[1], Globale.CouleurTextBoxSombre[2]);
                    controle.ForeColor = Color.FromArgb(255, Globale.CouleurDuTexteSombre[0],
                        Globale.CouleurDuTexteSombre[1], Globale.CouleurDuTexteSombre[2]);
                    if (controle is Button)
                    {
                        var controle2 = controle as Button;
                        controle2.FlatStyle = FlatStyle.Flat;
                        if (controle2.Enabled)
                            controle.BackColor = Color.FromArgb(255, Globale.CouleurBoutonsSombre[0],
                                Globale.CouleurBoutonsSombre[1], Globale.CouleurBoutonsSombre[2]);
                        else
                            controle.BackColor = Color.FromArgb(255, Globale.CouleurBoutonOffSombre[0],
                                Globale.CouleurBoutonOffSombre[1], Globale.CouleurBoutonOffSombre[2]);
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
                        controle.BackColor = Color.FromArgb(255, Globale.CouleurTextBoxClaire[0],
                            Globale.CouleurTextBoxClaire[1], Globale.CouleurTextBoxClaire[2]);
                    controle.ForeColor = Color.FromArgb(255, Globale.CouleurDuTexteclaire[0],
                        Globale.CouleurDuTexteclaire[1], Globale.CouleurDuTexteclaire[2]);
                    if (controle is Button)
                    {
                        var controle2 = controle as Button;
                        controle2.FlatStyle = FlatStyle.Flat;
                        if (controle2.Enabled)
                            controle.BackColor = Color.FromArgb(255, Globale.CouleurBoutonsClaire[0],
                                Globale.CouleurBoutonsClaire[1], Globale.CouleurBoutonsClaire[2]);
                        else
                            controle.BackColor = Color.FromArgb(255, Globale.CouleurBoutonOffClaire[0],
                                Globale.CouleurBoutonOffClaire[1], Globale.CouleurBoutonOffClaire[2]);
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
            if (Globale.EstEnModeSombre)
                foreach (Control controle in groupeBox.Controls)
                {
                    if (!(controle is Label || controle is GroupBox || controle is RadioButton ||
                          controle is CheckBox || controle is TrackBar))
                        controle.BackColor = Color.FromArgb(255, Globale.CouleurTextBoxSombre[0],
                            Globale.CouleurTextBoxSombre[1], Globale.CouleurTextBoxSombre[2]);
                    controle.ForeColor = Color.FromArgb(255, Globale.CouleurDuTexteSombre[0],
                        Globale.CouleurDuTexteSombre[1], Globale.CouleurDuTexteSombre[2]);
                    if (controle is Button)
                    {
                        var controle2 = controle as Button;
                        controle2.FlatStyle = FlatStyle.Flat;
                        if (controle2.Enabled)
                            controle.BackColor = Color.FromArgb(255, Globale.CouleurBoutonsSombre[0],
                                Globale.CouleurBoutonsSombre[1], Globale.CouleurBoutonsSombre[2]);
                        else
                            controle.BackColor = Color.FromArgb(255, Globale.CouleurBoutonOffSombre[0],
                                Globale.CouleurBoutonOffSombre[1], Globale.CouleurBoutonOffSombre[2]);
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
                        controle.BackColor = Color.FromArgb(255, Globale.CouleurTextBoxClaire[0],
                            Globale.CouleurTextBoxClaire[1], Globale.CouleurTextBoxClaire[2]);
                    controle.ForeColor = Color.FromArgb(255, Globale.CouleurDuTexteclaire[0],
                        Globale.CouleurDuTexteclaire[1], Globale.CouleurDuTexteclaire[2]);
                    if (controle is Button)
                    {
                        var controle2 = controle as Button;
                        controle2.FlatStyle = FlatStyle.Flat;
                        if (controle2.Enabled)
                            controle.BackColor = Color.FromArgb(255, Globale.CouleurBoutonsClaire[0],
                                Globale.CouleurBoutonsClaire[1], Globale.CouleurBoutonsClaire[2]);
                        else
                            controle.BackColor = Color.FromArgb(255, Globale.CouleurBoutonOffClaire[0],
                                Globale.CouleurBoutonOffClaire[1], Globale.CouleurBoutonOffClaire[2]);
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
                if (Globale.EstEnModeSombre)
                    btn.BackColor = Color.FromArgb(255, Globale.CouleurBoutonsSombre[0],
                        Globale.CouleurBoutonsSombre[1], Globale.CouleurBoutonsSombre[2]);
                else
                    btn.BackColor = Color.FromArgb(255, Globale.CouleurBoutonsClaire[0],
                        Globale.CouleurBoutonsClaire[1], Globale.CouleurBoutonsClaire[2]);
            }
            else if (btn != null)
            {
                if (Globale.EstEnModeSombre)
                    btn.BackColor = Color.FromArgb(255, Globale.CouleurBoutonOffSombre[0],
                        Globale.CouleurBoutonOffSombre[1], Globale.CouleurBoutonOffSombre[2]);
                else
                    btn.BackColor = Color.FromArgb(255, Globale.CouleurBoutonOffClaire[0],
                        Globale.CouleurBoutonOffClaire[1], Globale.CouleurBoutonOffClaire[2]);
            }
        }
    }
}