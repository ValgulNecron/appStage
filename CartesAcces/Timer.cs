using System;
using System.Threading;
using System.Windows.Forms;
using System.Timers;

namespace CartesAcces
{
    public class Timer
    {
        private DateTime start;
        private System.Timers.Timer timer;
        private int dureeMinute = 1;
        private Form form;

        public Timer(Form form)
        {
            this.form = form;
            start = DateTime.Now;
            timer = new System.Timers.Timer();
            timer.Interval = dureeMinute * 60 * 1000;
            timer.Elapsed += OnTimeEvent;
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();  
            form.MouseMove += Form_MouseMove;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            start = DateTime.Now;
        }

        private void OnTimeEvent(object source, ElapsedEventArgs e)
        {
            if (start.Add(TimeSpan.FromMinutes(15)) <= DateTime.Now)
            {
                MessageBox.Show("sa fait 1min");
                Globale._estConnecter = false;
                Globale._connexion.Invoke((MethodInvoker) delegate { Globale._connexion.Show();
                    MessageBox.Show(("la normalement tu a la co"));
                });
                form.Invoke((MethodInvoker) delegate { form.Close();
                    MessageBox.Show("et la je te ferme l'ancien truc");
                });
            }
            else
            {
                MessageBox.Show("y a eu un mouvement");
            }
        }
    }
}