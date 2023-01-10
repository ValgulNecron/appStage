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
        private int dureeMinute = 15;

        public Timer(Form form)
        {
            start = DateTime.Now;
            timer = new System.Timers.Timer(dureeMinute / 60 / 1000);
            timer.Elapsed += OnTimeEvent;
            timer.Enabled = true;
            form.MouseMove += Form_MouseMove;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            start = DateTime.Now;
        }

        private void OnTimeEvent(object source, ElapsedEventArgs e)
        {
            
        }
    }
}