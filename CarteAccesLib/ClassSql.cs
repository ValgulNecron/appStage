using System;
using System.Xml;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;


namespace CartesAcces
{
    /*
     * Cette classe permet de se connecter à la base de données
     * Elle contient une variable statique qui permet de se connecter à la base de données
     * Elle contient une fonction statique qui permet d'initialiser la variable statique
     */
    public static class ClassSql
    {
        public static DataConnection Db { get; set; }

        /*
         * Cette fonction permet d'initialiser la variable statique
         * Elle lit le fichier de configuration et initialise la variable statique
         */
        public static void init()
        {
            var doc = new XmlDocument();
            doc.Load("./data/config.xml");
            var mariaDb = "";
            var node = doc.SelectSingleNode("/configuration/appSettings/add[@key='IP']");
            if (node.Attributes != null) mariaDb += "Server=" + node.Attributes["value"].Value + ";";
            node = doc.SelectSingleNode("/configuration/appSettings/add[@key='PORT']");
            if (node.Attributes != null) mariaDb += "Port=" + node.Attributes["value"].Value + ";";
            node = doc.SelectSingleNode("/configuration/appSettings/add[@key='BD']");
            if (node.Attributes != null) mariaDb += "Database=" + node.Attributes["value"].Value + ";";
            node = doc.SelectSingleNode("/configuration/appSettings/add[@key='UTILISATEUR']");
            if (node.Attributes != null) mariaDb += "Uid=" + node.Attributes["value"].Value + ";";
            node = doc.SelectSingleNode("/configuration/appSettings/add[@key='MOTDEPASSE']");
            if (node.Attributes != null) mariaDb += "Pwd=" + node.Attributes["value"].Value + ";";
            Db = new DataConnection(
                ProviderName.MySql,
                mariaDb);
        }
    }

    /*
     * Cette classe permet de gérer les utilisateurs
     */
    [Table(Name = "utilisateur")]
    public class Utilisateurs
    {
        [PrimaryKey]
        [Column(Name = "nomUtilisateur")]
        public string NomUtilisateur { get; set; }

        [Column(Name = "hash")] public string Hash { get; set; }

        [Column(Name = "typeUtilisateur")] public string TypeUtilisateur { get; set; }

        [Column(Name = "themeBool")] public bool ThemeBool { get; set; }
        
        [Column(Name = "active")] public bool Active { get; set; }
    }

    /*
     * Cette classe permet de gérer les logActions
     */
    [Table(Name = "logAction")]
    public class LogActions
    {
        [Column(Name = "dateAction")]
        [PrimaryKey]
        public DateTime DateAction { get; set; }

        [Column(Name = "nomUtilisateur")]
        [PrimaryKey]
        public string NomUtilisateur { get; set; }

        [Column(Name = "action")] public string Action { get; set; }

        [Column(Name = "adMac")] public string AdMac { get; set; }

        [Association(ThisKey = nameof(NomUtilisateur), OtherKey = nameof(Utilisateurs.NomUtilisateur))]
        public Utilisateurs Utilisateur { get; set; }
    }

    /*
     * Cette classe permet de gérer les etablissements
     */
    [Table(Name = "etablissement")]
    public class Etablissement
    {
        [PrimaryKey]
        [Column(Name = "nomEtablissement")]
        public string NomEtablissement { get; set; }

        [Column(Name = "nomRueEtablissement")] public string NomRueEtablissement { get; set; }

        [Column(Name = "numeroRueEtablissement")]
        public int NumeroRueEtablissement { get; set; }

        [Column(Name = "codePostaleEtablissement")]
        public string CodePostaleEtablissement { get; set; }

        [Column(Name = "villeEtablissement")] public string VilleEtablissement { get; set; }

        [Column(Name = "numeroTelephoneEtablissement")]
        public string NumeroTelephoneEtablissement { get; set; }

        [Column(Name = "emailEtablissement")] public string EmailEtablissement { get; set; }

        [Column(Name = "urlEtablissement")] public string UrlEtablissement { get; set; }
        
        [Column(Name = "codeHexa6eme")] public string CodeHexa6eme { get; set; }
        
        [Column(Name = "codeHexa5eme")] public string CodeHexa5eme { get; set; }
        
        [Column(Name = "codeHexa4eme")] public string CodeHexa4eme { get; set; }
        
        [Column(Name = "codeHexa3eme")] public string CodeHexa3eme { get; set; }
        
        [Column(Name = "bordure")] public bool Bordure { get; set; }
    }
}