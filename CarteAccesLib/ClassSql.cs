using System;
using System.Xml;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace CarteAccesLib
{
    /*
     * Cette classe permet de se connecter à la base de données
     * Elle contient une variable statique qui permet de se connecter à la base de données
     * Elle contient une fonction statique qui permet d'initialiser la variable statique
     */
    /// <summary>
    /// 
    /// </summary>
    public static class ClassSql
    {
        /// <summary>
        /// 
        /// </summary>
        public static DataConnection Db { get; set; }

        /*
         * Cette fonction permet d'initialiser la variable statique
         * Elle lit le fichier de configuration et initialise la variable statique
         */
        /// <summary>
        /// 
        /// </summary>
        public static void Init()
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
    /// <summary>
    /// 
    /// </summary>
    [Table(Name = "utilisateur")]
    public class Utilisateurs
    {
        /// <summary>
        /// 
        /// </summary>
        [PrimaryKey]
        [Column(Name = "nomUtilisateur")]
        public string NomUtilisateur { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "hash")] public string Hash { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "typeUtilisateur")] public string TypeUtilisateur { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "themeBool")] public bool ThemeBool { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "active")] public bool Active { get; set; }
    }

    /*
     * Cette classe permet de gérer les logActions
     */
    /// <summary>
    /// 
    /// </summary>
    [Table(Name = "logAction")]
    public class LogActions
    {
        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "dateAction")]
        [PrimaryKey]
        public DateTime DateAction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "nomUtilisateur")]
        [PrimaryKey]
        public string NomUtilisateur { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "action")] public string Action { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "adMac")] public string AdMac { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Association(ThisKey = nameof(NomUtilisateur), OtherKey = nameof(Utilisateurs.NomUtilisateur))]
        public Utilisateurs Utilisateur { get; set; }
    }

    /*
     * Cette classe permet de gérer les etablissements
     */
    /// <summary>
    /// 
    /// </summary>
    [Table(Name = "etablissement")]
    public class Etablissement
    {
        /// <summary>
        /// 
        /// </summary>
        [PrimaryKey]
        [Column(Name = "nomEtablissement")]
        public string NomEtablissement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "nomRueEtablissement")] public string NomRueEtablissement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "numeroRueEtablissement")]
        public int NumeroRueEtablissement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "codePostaleEtablissement")]
        public string CodePostaleEtablissement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "villeEtablissement")] public string VilleEtablissement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "numeroTelephoneEtablissement")]
        public string NumeroTelephoneEtablissement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "emailEtablissement")] public string EmailEtablissement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "urlEtablissement")] public string UrlEtablissement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "codeHexa6eme")] public string CodeHexa6Eme { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "codeHexa5eme")] public string CodeHexa5Eme { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "codeHexa4eme")] public string CodeHexa4Eme { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "codeHexa3eme")] public string CodeHexa3Eme { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Name = "bordure")] public bool Bordure { get; set; }
    }
}