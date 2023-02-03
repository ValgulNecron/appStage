using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Linq;

namespace CartesAcces
{
    public class Eleve
    {
        public static List<string> listeCleeEleve = new List<string>();

        public Eleve()
        {
            NumEleve = 0;
            NomEleve = "null";
            PrenomEleve = "null";
            ClasseEleve = "null";
            RegimeEleve = "null";
            OptionUnEleve = "null";
            OptionDeuxEleve = "null";
            OptionTroisEleve = "null";
            OptionQuatreEleve = "null";
            MefEleve = "null";
            SansEDT = false;
        }

        public int NumEleve { get; set; }

        public string NomEleve { get; set; }

        public string PrenomEleve { get; set; }

        public string ClasseEleve { get; set; }

        public string RegimeEleve { get; set; }

        public string OptionUnEleve { get; set; }

        public string OptionDeuxEleve { get; set; }

        public string OptionTroisEleve { get; set; }

        public string OptionQuatreEleve { get; set; }

        public string MefEleve { get; set; }

        public bool SansEDT { get; set; }

        public static void setLesClasses()
        {
            foreach (var eleve in Globale._listeEleve.Select(x => x.ClasseEleve))
            {
                var numClasse = eleve.Substring(0, 1);

                if (numClasse == "6" && !Globale._classes6eme.Contains(eleve))
                    Globale._classes6eme.Add(eleve);
                else if (numClasse == "5" && !Globale._classes5eme.Contains(eleve))
                    Globale._classes5eme.Add(eleve);
                else if (numClasse == "4" && !Globale._classes4eme.Contains(eleve))
                    Globale._classes4eme.Add(eleve);
                else if (numClasse == "3" && !Globale._classes3eme.Contains(eleve))
                    Globale._classes3eme.Add(eleve);
                else
                    Globale._classesInconnue.Add(eleve);
            }

            Globale._classes3eme.Sort();
            Globale._classes4eme.Sort();
            Globale._classes5eme.Sort();
            Globale._classes6eme.Sort();

        }

        public static string creeCleEleve(Eleve eleve)
        {
            var cle = eleve.NomEleve + eleve.PrenomEleve + eleve.ClasseEleve;

            // Correction sur le regime
            if (eleve.RegimeEleve == "EXTERN")
                cle += "Externe";
            else if (eleve.RegimeEleve.Substring(0, 2) == "DP") cle += "12P";

            // Option 1
            cle += eleve.OptionUnEleve;

            // Option 2
            if (eleve.OptionDeuxEleve != "") cle += eleve.OptionDeuxEleve;

            // Option 3
            if (eleve.OptionTroisEleve != "") cle += eleve.OptionTroisEleve;

            // Option 4
            if (eleve.OptionQuatreEleve != "") cle += eleve.OptionQuatreEleve;

            return cle;
        }

        public static void possedeEdt(List<Eleve> listeEleve)
        {
            foreach (var eleve in listeEleve)
                if (!File.Exists("./data/image/" + eleve.ClasseEleve.Substring(0, 1) + "eme/" + creeCleEleve(eleve) +
                                 ".jpg"))
                    eleve.SansEDT = true;
        }
    }
}