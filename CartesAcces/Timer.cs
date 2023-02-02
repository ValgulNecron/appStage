using System;
using System.Timers;
using System.Windows.Forms;

namespace CartesAcces
{
    /*
     * cette classe permet de vérifier si l'utilisateur est inactif depuis un certain temps
         * si c'est le cas, elle retourne sur la page de connexion
         * les valeur de dureeMinute et frequenceDesVerifEnMinute sont en minutes et peuvent être modifiées
         * la fréquence de vérification est de 1 minute par défaut elle indique que la vérification se fera toutes les minutes
         * la durée est de 15 minutes par défaut elle indique que si l'utilisateur est inactif depuis 15 minutes, il sera déconnecté
         * il suffit de creer un objet de cette classe dans la page qui doit être surveillée et de l'initialiser avec l'objet de la fenêtre
         */
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
            form.MouseMove += Form_MouseMove;
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
                    Globale._accueil.Invoke(
                        new MethodInvoker(delegate { frmAccueil.OpenChildForm(Globale._actuelle); }));
                }
        }
    }
}