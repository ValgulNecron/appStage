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
        // valeur en minute de la durée d'inactivité avant déconnexion
        public static int DureeMinute { get; set; } = 15;
        public Form Form1 { get; set; }
        // valeur en minute de la fréquence de vérification
        public int FrequenceDesVerifEnMinute { get; set;} = 1;
        public System.Timers.Timer Timer1 { get; set; }
        private DateTime start;

        /*
         * constructeur de la classe
         * @param form : l'objet de la fenêtre à surveiller
         * il faut initialiser la classe avec l'objet de la fenêtre à surveiller
         */
        public Timer(Form form)
        {
            this.Form1 = form;
            start = DateTime.Now;
            Timer1 = new System.Timers.Timer();
            Timer1.Interval = FrequenceDesVerifEnMinute * 60 * 1000;
            Timer1.Elapsed += OnTimeEvent;
            Timer1.Enabled = true;
            Timer1.AutoReset = true;
            Timer1.Start();
            this.Form1.MouseMove += Form_MouseMove;
            Globale.Accueil.MouseMove += Form_MouseMove;
        }

        /*
         * cette fonction permet d'ajouter un événement à la fenêtre à surveiller
         */
        public void ajoutEvenement()
        {
            Form1.MouseMove += Form_MouseMove;
            Globale.Accueil.MouseMove += Form_MouseMove;
            Globale.Actuelle.MouseMove += Form_MouseMove;
        }
        
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            start = DateTime.Now;
        }

        private void OnTimeEvent(object source, ElapsedEventArgs e)
        {
            if (start.Add(TimeSpan.FromMinutes(DureeMinute)) <= DateTime.Now)
                if (Globale.EstConnecter)
                {
                    Globale.EstConnecter = false;
                    Globale.Actuelle = new frmConnexion();
                    Globale.Accueil.Invoke(
                        new MethodInvoker(delegate { frmAccueil.OpenChildForm(Globale.Actuelle); }));
                }
        }
    }
}