using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

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

        public static List<string> getEleveNiveau(string niveau)
        {
            // l'idée est de récupérer le premier caractère d'une propriété de l'objet, ici on veut le premier caractère de la classe de l'élève, on choisit
            //niveau "3ème" par exemple, on veut prendre que le caractère "3" puis on le compare au premier caractère de la classe de chaque élève de la liste
            //si "3" est le premier caractère alors cette élève est ajouté à la liste des élèves à imprimer
            var LesEleves = new List<string>();

            niveau = niveau.Substring(0, 1);
            foreach (var eleve in Globale._listeEleve)
                if (eleve.ClasseEleve.Substring(0, 1) == niveau)
                    LesEleves.Add(eleve.NomEleve);

            return LesEleves;
        }

        public static void setLesClasses(ComboBox cbbImprClasse)
        {
            var listeClassesAll = new List<string>();

            //Pour cacher la valeur par défaut, aussi car la valeur par défaut sans cela prend le premier index qui est 3GALILEE par exemple
            //cependant dans ce cas là, la liste n'est pas récupérée par défaut même si le premier objet est sélectionné par défaut
            listeClassesAll.Add("");

            foreach (var classe in Globale._classes3eme) listeClassesAll.Add(classe);
            foreach (var classe in Globale._classes4eme) listeClassesAll.Add(classe);
            foreach (var classe in Globale._classes5eme) listeClassesAll.Add(classe);
            foreach (var classe in Globale._classes6eme) listeClassesAll.Add(classe);

            cbbImprClasse.DataSource = listeClassesAll;
        }

        public static List<string> getEleveClasse(string classe)
        {
            var LesEleves = new List<string>();

            foreach (var eleve in Globale._listeEleve)
                if (eleve.ClasseEleve == classe)
                    LesEleves.Add(eleve.NomEleve);

            return LesEleves;
        }

        // -- Pour l'impression par classe, les élève de la liste initiale dont la classe
        // correspond à la selection seront collectés --
        public static void affecterElevesClasses(string uneClasse)
        {
            foreach (var eleve in Globale._listeEleve)
                if (eleve.ClasseEleve == uneClasse)
                    Globale._listeEleveImpr.Add(eleve);
        }

        // -- Idem pour la niveau -- 
        public static void affecterElevesNiveaux(string unNiveau)
        {
            foreach (var eleve in Globale._listeEleve)
            {
                var numSection = eleve.ClasseEleve.Substring(0, 1); //solution?
                if (numSection == unNiveau.Substring(0, 1)) Globale._listeEleveImpr.Add(eleve);
            }
        }

        public static void setLesClasses()
        {
            foreach (var eleve in Globale._listeEleve)
            {
                var numClasse = eleve.ClasseEleve.Substring(0, 1);

                if (numClasse == "6" && !Globale._classes6eme.Contains(eleve.ClasseEleve))
                    Globale._classes6eme.Add(eleve.ClasseEleve);
                else if (numClasse == "5" && !Globale._classes5eme.Contains(eleve.ClasseEleve))
                    Globale._classes5eme.Add(eleve.ClasseEleve);
                else if (numClasse == "4" && !Globale._classes4eme.Contains(eleve.ClasseEleve))
                    Globale._classes4eme.Add(eleve.ClasseEleve);
                else if (numClasse == "3" && !Globale._classes3eme.Contains(eleve.ClasseEleve))
                    Globale._classes3eme.Add(eleve.ClasseEleve);
                else
                    Globale._classesInconnue.Add(eleve.ClasseEleve);
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