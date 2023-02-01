using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;
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
            string mariaDb = "";
            var node = doc.SelectSingleNode("/configuration/appSettings/add[@key='IP']");
            if (node.Attributes != null) mariaDb += "Server=" + node.Attributes["value"].Value + ";";
            mariaDb += "Port=3306;";
            node = doc.SelectSingleNode("/configuration/appSettings/add[@key='BD']");
            if (node.Attributes != null) mariaDb += "Database=" + node.Attributes["value"].Value + ";";
            node = doc.SelectSingleNode("/configuration/appSettings/add[@key='UTILISATEUR']");
            if (node.Attributes != null) mariaDb += "Uid=" + node.Attributes["value"].Value + ";";
            node = doc.SelectSingleNode("/configuration/appSettings/add[@key='MOTDEPASSE']");
            if (node.Attributes != null) mariaDb += "Pwd=" + node.Attributes["value"].Value + ";";
            db = new LinqToDB.Data.DataConnection(
                LinqToDB.ProviderName.MySql,
                mariaDb);
        }
    }

    [LinqToDB.Mapping.Table(Name = "utilisateur")]
    public class Utilisateurs
    {
        [PrimaryKey, LinqToDB.Mapping.Column(Name = "nomUtilisateur")]
        public string NomUtilisateur { get; set; }

        [LinqToDB.Mapping.Column(Name = "hash")]
        public string Hash { get; set; }
        
        [LinqToDB.Mapping.Column(Name = "typeUtilisateur")]
        public string TypeUtilisateur { get; set; }

        [LinqToDB.Mapping.Column(Name = "themeBool")]
        public bool ThemeBool { get; set; }
    }
    
    
    [LinqToDB.Mapping.Table(Name = "logAction")]
    public class LogActions
    {
        [LinqToDB.Mapping.Column(Name = "dateAction"), PrimaryKey]
        public DateTime DateAction { get; set; }

        [LinqToDB.Mapping.Column(Name = "nomUtilisateur"), PrimaryKey]
        public string NomUtilisateur { get; set; }

        [LinqToDB.Mapping.Column(Name = "action")]
        public string Action { get; set; }

        [LinqToDB.Mapping.Column(Name = "adMac")]
        public string AdMac { get; set; }
        
        [LinqToDB.Mapping.Association(ThisKey = nameof(NomUtilisateur), OtherKey = nameof(Utilisateurs.NomUtilisateur))]
        public Utilisateurs Utilisateur { get; set; }
    }

    [LinqToDB.Mapping.Table(Name = "etablissement")]
    public class Etablissement
    {
        [PrimaryKey, LinqToDB.Mapping.Column(Name = "nomEtablissement")]
        public string NomEtablissement { get; set; }

        [LinqToDB.Mapping.Column(Name = "nomRueEtablissement")]
        public string NomRueEtablissement { get; set; }

        [LinqToDB.Mapping.Column(Name = "numeroRueEtablissement")]
        public int NumeroRueEtablissement { get; set; }

        [LinqToDB.Mapping.Column(Name = "codePostaleEtablissement")]
        public string CodePostaleEtablissement { get; set; }

        [LinqToDB.Mapping.Column(Name = "villeEtablissement")]
        public string VilleEtablissement { get; set; }

        [LinqToDB.Mapping.Column(Name = "numeroTelephoneEtablissement")]
        public string NumeroTelephoneEtablissement { get; set; }

        [LinqToDB.Mapping.Column(Name = "emailEtablissement")]
        public string EmailEtablissement { get; set; }
    }
}