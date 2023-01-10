using System;
using System.Threading;
using System.Windows.Forms;

namespace CartesAcces
{
    public class Timer
    {
        private DateTime start;
        private Timer timer;
        private int dureeMinute = 15;

        public Timer(Form form)
        {
            start = DateTime.Now;
            timer = new Timer();
            timer.Interval = dureeMinute / 60 / 1000; // la duree en minute mit en ms pour l'interval
            timer.Tick = +OnTimerTick;

            form.MouseMove += Form_MouseMove;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            start = DateTime.Now;
        }
    }
}