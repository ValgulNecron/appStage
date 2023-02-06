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
            }
            else
            {
                fenetre.BackColor = Color.FromArgb(255, Globale.CouleurDeFondClaire[0],
                    Globale.CouleurDeFondClaire[1], Globale.CouleurDeFondClaire[2]);
            }

            foreach (Control controle in fenetre.Controls)
            {
                var panel = controle as Panel;
                var groupBox = controle as GroupBox;
                var button = controle as Button;
                var textBox = controle as TextBox;
                var listBox = controle as ListBox;
                if (panel != null)
                {
                    setCouleurPanel((Panel) controle);
                }
                else if (groupBox != null)
                {
                    setCouleurGroupeBox((GroupBox) controle);
                }

                else if (button != null)
                {
                    setCouleurBouton((Button) controle);
                }
                else if (textBox != null)
                {
                    setCouleurTextBox((TextBox) controle);
                }
                else if (listBox != null)
                {
                    setCouleurListBox((ListBox) controle);
                }
                else
                {
                    setCouleurAutre(controle);
                }
            }
        }

        public static void setCouleurPanel(Panel panel)
        {
            foreach (Control controle in panel.Controls)
            {
                var panel2 = controle as Panel;
                var groupBox = controle as GroupBox;
                var button = controle as Button;
                var textBox = controle as TextBox;
                var listBox = controle as ListBox;
                if (panel2 != null)
                {
                    setCouleurPanel((Panel) controle);
                }
                else if (groupBox != null)
                {
                    setCouleurGroupeBox((GroupBox) controle);
                }

                else if (button != null)
                {
                    setCouleurBouton((Button) controle);
                }
                else if (textBox != null)
                {
                    setCouleurTextBox((TextBox) controle);
                }
                else if (listBox != null)
                {
                    setCouleurListBox((ListBox) controle);
                }
                else
                {
                    setCouleurAutre(controle);
                }
            }
        }

        public static void setCouleurGroupeBox(GroupBox groupeBox)
        {
            foreach (Control controle in groupeBox.Controls)
            {
                var panel = controle as Panel;
                var groupBox = controle as GroupBox;
                var button = controle as Button;
                var textBox = controle as TextBox;
                var listBox = controle as ListBox;
                if (panel != null)
                {
                    setCouleurPanel((Panel) controle);
                }
                else if (groupBox != null)
                {
                    setCouleurGroupeBox((GroupBox) controle);
                }

                else if (button != null)
                {
                    setCouleurBouton((Button) controle);
                }
                else if (textBox != null)
                {
                    setCouleurTextBox((TextBox) controle);
                }
                else if (listBox != null)
                {
                    setCouleurListBox((ListBox) controle);
                }
                else
                {
                    setCouleurAutre(controle);
                }
            }
        }

        public static void setCouleurBouton(Button btn)
        {
            if (Globale.EstEnModeSombre)
            {
                btn.FlatStyle = FlatStyle.Flat;
                if (btn.Enabled)
                    btn.BackColor = Color.FromArgb(255, Globale.CouleurBoutonsSombre[0],
                        Globale.CouleurBoutonsSombre[1], Globale.CouleurBoutonsSombre[2]);
                else
                    btn.BackColor = Color.FromArgb(255, Globale.CouleurBoutonOffSombre[0],
                        Globale.CouleurBoutonOffSombre[1], Globale.CouleurBoutonOffSombre[2]);
                btn.EnabledChanged += changement_state_btn;
            }
            else
            {
                btn.FlatStyle = FlatStyle.Flat;
                if (btn.Enabled)
                    btn.BackColor = Color.FromArgb(255, Globale.CouleurBoutonsClaire[0],
                        Globale.CouleurBoutonsClaire[1], Globale.CouleurBoutonsClaire[2]);
                else
                    btn.BackColor = Color.FromArgb(255, Globale.CouleurBoutonOffClaire[0],
                        Globale.CouleurBoutonOffClaire[1], Globale.CouleurBoutonOffClaire[2]);
                btn.EnabledChanged += changement_state_btn;
            }
        }

        public static void setCouleurAutre(Control controle)
        {
            if (Globale.EstEnModeSombre)
            {
                controle.ForeColor = Color.FromArgb(255, Globale.CouleurDuTexteSombre[0],
                    Globale.CouleurDuTexteSombre[1], Globale.CouleurDuTexteSombre[2]);
            }
            else
            {
                controle.ForeColor = Color.FromArgb(255, Globale.CouleurDuTexteclaire[0],
                    Globale.CouleurDuTexteclaire[1], Globale.CouleurDuTexteclaire[2]);
            }
        }

        public static void setCouleurTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.None;
            if (Globale.EstEnModeSombre)
            {
                txt.ForeColor = Color.FromArgb(255, Globale.CouleurDuTexteSombre[0],
                    Globale.CouleurDuTexteSombre[1], Globale.CouleurDuTexteSombre[2]);
                txt.BackColor = Color.FromArgb(255, Globale.CouleurBoutonsSombre[0],
                    Globale.CouleurBoutonsSombre[1], Globale.CouleurBoutonsSombre[2]);
            }
            else
            {
                txt.ForeColor = Color.FromArgb(255, Globale.CouleurDuTexteclaire[0],
                    Globale.CouleurDuTexteclaire[1], Globale.CouleurDuTexteclaire[2]);
                txt.BackColor = Color.FromArgb(255, Globale.CouleurBoutonsClaire[0],
                    Globale.CouleurBoutonsClaire[1], Globale.CouleurBoutonsClaire[2]);
            }
        }

        public static void setCouleurListBox(ListBox lst)
        {
            lst.BorderStyle = BorderStyle.None;
            if (Globale.EstEnModeSombre)
            {
                lst.ForeColor = Color.FromArgb(255, Globale.CouleurDuTexteSombre[0],
                    Globale.CouleurDuTexteSombre[1], Globale.CouleurDuTexteSombre[2]);
                lst.BackColor = Color.FromArgb(255, Globale.CouleurBoutonsSombre[0],
                    Globale.CouleurBoutonsSombre[1], Globale.CouleurBoutonsSombre[2]);
            }
            else
            {
                lst.ForeColor = Color.FromArgb(255, Globale.CouleurDuTexteclaire[0],
                    Globale.CouleurDuTexteclaire[1], Globale.CouleurDuTexteclaire[2]);
                lst.BackColor = Color.FromArgb(255, Globale.CouleurBoutonsClaire[0],
                    Globale.CouleurBoutonsClaire[1], Globale.CouleurBoutonsClaire[2]);
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
            
            setCouleurBouton(btn);
        }
    }
}