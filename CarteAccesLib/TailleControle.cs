using System.Drawing;
using System.Windows.Forms;

namespace CartesAcces
{
    public class TailleControle
    {
        public static void setTailleControleTexte(Form form)
        {
            var policeParDefault = new Font("Microsoft Sans Serif", 10);
            foreach (Control controle in form.Controls)
                if (controle is TextBox) // indique que je prend uniquement les boutons du type
                {
                    var controle2 = controle as TextBox; // indique que ce contrôle est de type
                    controle2.MinimumSize = new Size(150, 20); // application des modification sur le type choisi
                    controle2.Font = policeParDefault;
                }
        }

        public static void setTailleControleLabel(Form form)
        {
            var policeParDefault = new Font("Microsoft Sans Serif", 10);
            foreach (Control controle in form.Controls)
                if (controle is Label)
                {
                    var controle2 = controle as Label;
                    controle2.Font = policeParDefault;
                }
        }

        public static void setTailleBouton(Form form)
        {
            var policeParDefault = new Font("Microsoft Sans Serif", 10);
            foreach (Control controle in form.Controls)
                if (controle is Button) // indique que je prend uniquement les boutons du type
                {
                    var controle2 = controle as Button; // indique que ce contrôle est de type
                    controle2.Font = policeParDefault; // application des modification sur le type choisi
                    controle2.Size = new Size(330, 29);
                    controle2.AutoSize = false;

                }
        }


        }
}