using System.Drawing;
using System.Windows.Forms;

namespace CartesAcces
{
    public class TailleCotrole
    {
        public static void setTailleControleTexte(Form form)
        {
            var policeParDefault = new Font("Microsoft Sans Serif", 10);
            foreach (Control controle in form.Controls)
                if (controle is TextBox)
                {
                    var controle2 = controle as TextBox;
                    controle2.MinimumSize = new Size(150, 20);
                    controle2.Font = policeParDefault;
                }
        }
    }
}