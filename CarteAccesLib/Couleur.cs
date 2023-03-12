using System;
using System.Drawing;
using System.Windows.Forms;
using CartesAcces;

namespace CarteAccesLib
{
    /// <summary>
    /// 
    /// </summary>
    public static class Couleur
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fenetre"></param>
        public static void SetCouleurFenetre(Form fenetre)
        {
            if (Globale.EstEnModeSombre)
                fenetre.BackColor = Color.FromArgb(255, Globale.CouleurDeFondSombre[0],
                    Globale.CouleurDeFondSombre[1], Globale.CouleurDeFondSombre[2]);
            else
                fenetre.BackColor = Color.FromArgb(255, Globale.CouleurDeFondClaire[0],
                    Globale.CouleurDeFondClaire[1], Globale.CouleurDeFondClaire[2]);

            foreach (Control controle in fenetre.Controls)
            {
                var panel = controle as Panel;
                var groupBox = controle as GroupBox;
                var button = controle as Button;
                var textBox = controle as TextBox;
                var listBox = controle as ListBox;
                if (panel != null)
                    SetCouleurPanel((Panel) controle);
                else if (groupBox != null)
                    SetCouleurGroupeBox((GroupBox) controle);

                else if (button != null)
                    SetCouleurBouton((Button) controle);
                else if (textBox != null)
                    SetCouleurTextBox((TextBox) controle);
                else if (listBox != null)
                    SetCouleurListBox((ListBox) controle);
                else
                    SetCouleurAutre(controle);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        public static void SetCouleurPanel(Panel panel)
        {
            foreach (Control controle in panel.Controls)
            {
                var panel2 = controle as Panel;
                var groupBox = controle as GroupBox;
                var button = controle as Button;
                var textBox = controle as TextBox;
                var listBox = controle as ListBox;
                if (panel2 != null)
                    SetCouleurPanel((Panel) controle);
                else if (groupBox != null)
                    SetCouleurGroupeBox((GroupBox) controle);

                else if (button != null)
                    SetCouleurBouton((Button) controle);
                else if (textBox != null)
                    SetCouleurTextBox((TextBox) controle);
                else if (listBox != null)
                    SetCouleurListBox((ListBox) controle);
                else
                    SetCouleurAutre(controle);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupeBox"></param>
        public static void SetCouleurGroupeBox(GroupBox groupeBox)
        {
            foreach (Control controle in groupeBox.Controls)
            {
                var panel = controle as Panel;
                var groupBox = controle as GroupBox;
                var button = controle as Button;
                var textBox = controle as TextBox;
                var listBox = controle as ListBox;
                if (panel != null)
                    SetCouleurPanel((Panel) controle);
                else if (groupBox != null)
                    SetCouleurGroupeBox((GroupBox) controle);

                else if (button != null)
                    SetCouleurBouton((Button) controle);
                else if (textBox != null)
                    SetCouleurTextBox((TextBox) controle);
                else if (listBox != null)
                    SetCouleurListBox((ListBox) controle);
                else
                    SetCouleurAutre(controle);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="btn"></param>
        public static void SetCouleurBouton(Button btn)
        {
            if (Globale.EstEnModeSombre)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.ForeColor = Color.FromArgb(255, Globale.CouleurDuTexteSombre[0],
                    Globale.CouleurDuTexteSombre[1], Globale.CouleurDuTexteSombre[2]);
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
                btn.ForeColor = Color.FromArgb(255, Globale.CouleurDuTexteclaire[0],
                    Globale.CouleurDuTexteclaire[1], Globale.CouleurDuTexteclaire[2]);
                if (btn.Enabled)
                    btn.BackColor = Color.FromArgb(255, Globale.CouleurBoutonsClaire[0],
                        Globale.CouleurBoutonsClaire[1], Globale.CouleurBoutonsClaire[2]);
                else
                    btn.BackColor = Color.FromArgb(255, Globale.CouleurBoutonOffClaire[0],
                        Globale.CouleurBoutonOffClaire[1], Globale.CouleurBoutonOffClaire[2]);
                btn.EnabledChanged += changement_state_btn;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controle"></param>
        public static void SetCouleurAutre(Control controle)
        {
            if (Globale.EstEnModeSombre)
                controle.ForeColor = Color.FromArgb(255, Globale.CouleurDuTexteSombre[0],
                    Globale.CouleurDuTexteSombre[1], Globale.CouleurDuTexteSombre[2]);
            else
                controle.ForeColor = Color.FromArgb(255, Globale.CouleurDuTexteclaire[0],
                    Globale.CouleurDuTexteclaire[1], Globale.CouleurDuTexteclaire[2]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="txt"></param>
        public static void SetCouleurTextBox(TextBox txt)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lst"></param>
        public static void SetCouleurListBox(ListBox lst)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            SetCouleurBouton(btn);
        }
    }
}