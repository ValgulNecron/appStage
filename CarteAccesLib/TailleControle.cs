using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Google.Protobuf.Reflection;

namespace CarteAccesLib
{
    /// <summary>
    /// Classe permettant de définir la taille des contrôles
    /// </summary>
    public static class TailleControle
    {
        /// <summary>
        /// Cette fonction permet de définir la taille des contrôles de type TextBox
        /// </summary>
        /// <param name="form"></param>
        public static void SetTailleControleTexte(Form form)
        {
            var policeParDefault = new Font("Microsoft Sans Serif", 10);

            var controlsList = new List<Control>();
            foreach (Control controle in form.Controls) controlsList.Add(controle);
            foreach (var controle in controlsList.Where(x => x is TextBox))
            {
                var controle2 = controle as TextBox; // indique que ce contrôle est de type
                if (controle2 != null)
                {
                    controle2.MinimumSize = new Size(150, 20); // application des modification sur le type choisi
                    controle2.Font = policeParDefault;
                }
            }
        }

        /// <summary>
        /// Cette fonction permet de définir la taille des contrôles de type Label
        /// </summary>
        /// <param name="form"></param>
        public static void SetTailleControleLabel(Form form)
        {
            var policeParDefault = new Font("Microsoft Sans Serif", 10);

            var controlsList = new List<Control>();
            foreach (Control controle in form.Controls) controlsList.Add(controle);
            foreach (var controle in controlsList.Where(x => x is FieldDescriptorProto.Types.Label))
            {
                var controle2 = controle as Label;
                if (controle2 != null) controle2.Font = policeParDefault;
            }
        }

        /// <summary>
        /// Cette fonction permet de définir la taille des contrôles de type Button
        /// </summary>
        /// <param name="form"></param>
        public static void SetTailleBouton(Form form)
        {
            var policeParDefault = new Font("Microsoft Sans Serif", 10);


            var controlsList = new List<Control>();
            foreach (Control controle in form.Controls) controlsList.Add(controle);
            foreach (var controle in controlsList.Where(x => x is Button))
            {
                var controle2 = controle as Button; // indique que ce contrôle est de type
                if (controle2 != null)
                {
                    controle2.Font = policeParDefault; // application des modification sur le type choisi
                    controle2.Size = new Size(330, 29);
                    controle2.AutoSize = false;
                }
            }
        }
    }
}