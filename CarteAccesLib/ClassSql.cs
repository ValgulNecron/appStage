using System;
using System.Xml;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace CartesAcces
{
    public static class ClassSql
    {
        public static DataConnection db;

        public static void init()
        {
            var doc = new XmlDocument();
            doc.Load("./config.xml");
            var mariaDb = "";
            var node = doc.SelectSingleNode("/configuration/appSettings/add[@key='IP']");
            if (node.Attributes != null) mariaDb += "Server=" + node.Attributes["value"].Value + ";";
            mariaDb += "Port=3306;";
            node = doc.SelectSingleNode("/configuration/appSettings/add[@key='BD']");
            if (node.Attributes != null) mariaDb += "Database=" + node.Attributes["value"].Value + ";";
            node = doc.SelectSingleNode("/configuration/appSettings/add[@key='UTILISATEUR']");
            if (node.Attributes != null) mariaDb += "Uid=" + node.Attributes["value"].Value + ";";
            node = doc.SelectSingleNode("/configuration/appSettings/add[@key='MOTDEPASSE']");
            if (node.Attributes != null) mariaDb += "Pwd=" + node.Attributes["value"].Value + ";";
            db = new DataConnection(
                ProviderName.MySql,
                mariaDb);
        }
    }

    [Table(Name = "utilisateur")]
    public class Utilisateurs
    {
        [PrimaryKey]
        [Column(Name = "nomUtilisateur")]
        public string NomUtilisateur { get; set; }

        [Column(Name = "hash")] public string Hash { get; set; }

        [Column(Name = "typeUtilisateur")] public string TypeUtilisateur { get; set; }

        [Column(Name = "themeBool")] public bool ThemeBool { get; set; }
    }


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
    }
}