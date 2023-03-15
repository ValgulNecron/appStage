using System;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace CarteAccesLib
{
    public class MessagePersonnalisee : Form
    {
        public MessagePersonnalisee(string message, string hypertext, string url)
        {
            Text = "Message personnalisee";
            Size = new System.Drawing.Size(400, 200);
            StartPosition = FormStartPosition.CenterScreen; 
            TopMost = true;
            TopLevel = true;
            
            Label messageLibelle = new Label()
            {
                Text = message,
                Location = new System.Drawing.Point(20, 20),
                AutoSize = false
            };
            Controls.Add(messageLibelle);

            LinkLabel linkLibelle = new LinkLabel
            {
                Text = hypertext,
                Location = new System.Drawing.Point(20, 60),
                AutoSize = false
            };
            Controls.Add(linkLibelle);

            Button okBouton = new Button
            {
                Text = "OK",
                Location = new System.Drawing.Point(150, 100),
                AutoSize = true
            };
            okBouton.Click += (sender, e) => Close();
            Controls.Add(okBouton);
        }

        public static void Show(string message, string hypertext, string url)
        {
            using (MessagePersonnalisee messagePersonnalisee = new MessagePersonnalisee(message, hypertext, url))
            {
                messagePersonnalisee.ShowDialog();
            }
        }
    }
}