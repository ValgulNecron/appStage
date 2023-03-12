using System;
using System.Timers;
using System.Windows.Forms;

namespace CartesAcces
{
    /// <summary>
    ///     Cette classe permet de vérifier si l'utilisateur est inactif depuis un certain temps
    ///     si c'est le cas, elle retourne sur la page de connexion
    ///     les valeur de dureeMinute et frequenceDesVerifEnMinute sont en minutes et peuvent être modifiées
    ///     la fréquence de vérification est de 1 minute par défaut elle indique que la vérification se fera toutes les minutes
    ///     la durée est de 15 minutes par défaut elle indique que si l'utilisateur est inactif depuis 15 minutes, il sera
    ///     déconnecté
    ///     il suffit de creer un objet de cette classe dans la page qui doit être surveillée et de l'initialiser avec l'objet
    ///     de la fenêtre
    /// </summary>
    public class Timer
    {
        private DateTime start;


        /// <summary>
        ///     constructeur de la classe
        ///     il faut initialiser la classe avec l'objet de la fenêtre à surveiller
        /// </summary>
        /// <param name="form"></param>
        public Timer(Form form)
        {
            Form1 = form;
            start = DateTime.Now;
            Timer1 = new System.Timers.Timer();
            Timer1.Interval = FrequenceDesVerifEnMinute * 60 * 1000;
            Timer1.Elapsed += OnTimeEvent;
            Timer1.Enabled = true;
            Timer1.AutoReset = true;
            Timer1.Start();
            Form1.MouseMove += Form_MouseMove;
            Globale.Accueil.MouseMove += Form_MouseMove;
        }

        /// <summary>
        ///     valeur en minute de la durée d'inactivité avant déconnexion
        /// </summary>
        public static int DureeMinute { get; set; } = 15;

        /// <summary>
        ///     l'objet de la fenêtre à surveiller
        /// </summary>
        public Form Form1 { get; set; }

        /// <summary>
        ///     valeur en minute de la fréquence de vérification
        /// </summary>
        public int FrequenceDesVerifEnMinute { get; set; } = 1;

        /// <summary>
        ///     l'objet de la classe System.Timers.Timer
        /// </summary>
        public System.Timers.Timer Timer1 { get; set; }

        /// <summary>
        ///     cette fonction permet d'ajouter un événement à la fenêtre à surveiller
        /// </summary>
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
                    Globale.Actuelle = new FrmConnexion();
                    Globale.Accueil.Invoke(
                        new MethodInvoker(delegate { FrmAccueil.OpenChildForm(Globale.Actuelle); }));
                }
        }
    }
}