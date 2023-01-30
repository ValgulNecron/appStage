using System;
using System.Timers;
using System.Windows.Forms;

namespace CartesAcces
{
    public class Timer
    {
        private readonly int dureeMinute = 15;
        private readonly Form form;
        private readonly int frequenceDesVerifEnMinute = 1;
        private readonly System.Timers.Timer timer;
        private DateTime start;

        public Timer(Form form)
        {
            this.form = form;
            start = DateTime.Now;
            timer = new System.Timers.Timer();
            timer.Interval = frequenceDesVerifEnMinute * 60 * 1000;
            timer.Elapsed += OnTimeEvent;
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();
            this.form.MouseMove += Form_MouseMove;
            Globale._accueil.MouseMove += Form_MouseMove;
        }
        
        public void ajoutEvenement()
        {
            this.form.MouseMove += Form_MouseMove;
            Globale._accueil.MouseMove += Form_MouseMove;
            Globale._actuelle.MouseMove += Form_MouseMove;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            start = DateTime.Now;
        }

        private void OnTimeEvent(object source, ElapsedEventArgs e)
        {
            if (start.Add(TimeSpan.FromMinutes(dureeMinute)) <= DateTime.Now)
                if (Globale._estConnecter)
                {
                    Globale._estConnecter = false;
                    Globale._actuelle = new frmConnexion();
                    Globale._accueil.Invoke(new MethodInvoker(delegate { frmAccueil.OpenChildForm(Globale._actuelle); }));
                }
        }
    }
} 