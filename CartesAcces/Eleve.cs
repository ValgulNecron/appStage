using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartesAcces
{
    public class Eleve
    {
        private string nomEleve;
        private string prenomEleve;
        private string classeEleve;
        private string regimeEleve;
        private string optionUnEleve;
        private string optionDeuxEleve;
        private string optionTroisEleve;
        private string optionQuatreEleve;
        private string mefEleve;
        private bool sansEDT;

        public Eleve()
        {
            this.NomEleve = "null";
            this.PrenomEleve = "null";
            this.ClasseEleve = "null";
            this.RegimeEleve = "null";
            this.OptionUnEleve = "null";
            this.OptionDeuxEleve = "null";
            this.OptionTroisEleve = "null";
            this.OptionQuatreEleve = "null";
            this.mefEleve = "null";
            this.sansEDT = false;
        }

        public string NomEleve { get => nomEleve; set => nomEleve = value; }
        public string PrenomEleve { get => prenomEleve; set => prenomEleve = value; }
        public string ClasseEleve { get => classeEleve; set => classeEleve = value; }
        public string RegimeEleve { get => regimeEleve; set => regimeEleve = value; }
        public string OptionUnEleve { get => optionUnEleve; set => optionUnEleve = value; }
        public string OptionDeuxEleve { get => optionDeuxEleve; set => optionDeuxEleve = value; }
        public string OptionTroisEleve { get => optionTroisEleve; set => optionTroisEleve = value; }
        public string OptionQuatreEleve { get => optionQuatreEleve; set => optionQuatreEleve = value; }
        public string MefEleve { get => mefEleve; set => mefEleve = value; }
        public bool SansEDT { get => sansEDT; set => sansEDT = value; }
    }
}
