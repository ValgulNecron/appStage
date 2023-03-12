using System.Collections.Generic;
using System.IO;
using System.Linq;
using CartesAcces;

namespace CarteAccesLib
{
    /// <summary>
    /// 
    /// </summary>
    public class Eleve
    {
        /// <summary>
        /// 
        /// </summary>
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
            SansEdt = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<string> ListeCleeEleve { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int NumEleve { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NomEleve { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PrenomEleve { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ClasseEleve { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RegimeEleve { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OptionUnEleve { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OptionDeuxEleve { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OptionTroisEleve { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OptionQuatreEleve { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MefEleve { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool SansEdt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static void SetLesClasses()
        {
            foreach (var eleve in Globale.ListeEleve.Select(x => x.ClasseEleve))
            {
                var numClasse = eleve.Substring(0, 1);

                if (numClasse == "6" && !Globale.Classes6Eme.Contains(eleve))
                    Globale.Classes6Eme.Add(eleve);
                else if (numClasse == "5" && !Globale.Classes5Eme.Contains(eleve))
                    Globale.Classes5Eme.Add(eleve);
                else if (numClasse == "4" && !Globale.Classes4Eme.Contains(eleve))
                    Globale.Classes4Eme.Add(eleve);
                else if (numClasse == "3" && !Globale.Classes3Eme.Contains(eleve))
                    Globale.Classes3Eme.Add(eleve);
                else
                    Globale.ClassesInconnue.Add(eleve);
            }

            Globale.Classes3Eme.Sort();
            Globale.Classes4Eme.Sort();
            Globale.Classes5Eme.Sort();
            Globale.Classes6Eme.Sort();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eleve"></param>
        /// <returns></returns>
        public static string CreeCleEleve(Eleve eleve)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listeEleve"></param>
        public static void PossedeEdt(List<Eleve> listeEleve)
        {
            foreach (var eleve in listeEleve)
                if (!File.Exists("./data/image/" + eleve.ClasseEleve.Substring(0, 1) + "eme/" + CreeCleEleve(eleve) +
                                 ".jpg"))
                    eleve.SansEdt = true;
        }
    }
}