using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Google.Protobuf.Reflection;

namespace CartesAcces
{
    public static class TailleControle
    {
        public static void setTailleControleTexte(Form form)
        {
            var policeParDefault = new Font("Microsoft Sans Serif", 10);

            var controlsList = new List<Control>();
            foreach (Control controle in form.Controls) controlsList.Add(controle);
            foreach (var controle in controlsList.Where(x => x is TextBox))
            {
                var controle2 = controle as TextBox; // indique que ce contrôle est de type
                controle2.MinimumSize = new Size(150, 20); // application des modification sur le type choisi
                controle2.Font = policeParDefault;
            }
        }

        public static void setTailleControleLabel(Form form)
        {
            var policeParDefault = new Font("Microsoft Sans Serif", 10);

            var controlsList = new List<Control>();
            foreach (Control controle in form.Controls) controlsList.Add(controle);
            foreach (var controle in controlsList.Where(x => x is FieldDescriptorProto.Types.Label))
            {
                var controle2 = controle as Label;
                controle2.Font = policeParDefault;
            }
        }

        public static void setTailleBouton(Form form)
        {
            var policeParDefault = new Font("Microsoft Sans Serif", 10);


            var controlsList = new List<Control>();
            foreach (Control controle in form.Controls) controlsList.Add(controle);
            foreach (var controle in controlsList.Where(x => x is Button))
            {
                var controle2 = controle as Button; // indique que ce contrôle est de type
                controle2.Font = policeParDefault; // application des modification sur le type choisi
                controle2.Size = new Size(330, 29);
                controle2.AutoSize = false;
            }
        }
    }
}