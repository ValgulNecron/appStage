using System;
using System.Timers;
using System.Windows.Forms;

namespace CartesAcces
{
    public class Timer
    {
        private readonly int dureeMinute = 1;
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
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            start = DateTime.Now;
        }

        private void OnTimeEvent(object source, ElapsedEventArgs e)
        {
            if (Globale._accueil == null)
                Application.Exit();
            if (start.Add(TimeSpan.FromMinutes(dureeMinute)) <= DateTime.Now)
                if (Globale._estConnecter)
                {
                    Globale._estConnecter = false;
                    Globale._actuelle = new frmImportation();
                    frmAccueil.OpenChildForm(Globale._actuelle);
                }
        }
    }
} 