using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CartesAcces
{
    public class ControlSize
    {
        public static void SetSizeTextControl(Form form)
        {
            Font defaultFont = new Font("Microsoft Sans Serif", 10);
            foreach (Control controle in form.Controls)
            {
                if (controle is TextBox)
                {
                    TextBox controle2 = controle as TextBox;
                    controle2.MinimumSize = new Size(150,20);
                    controle2.Font = defaultFont;
                }
            }
        }
    }
}
