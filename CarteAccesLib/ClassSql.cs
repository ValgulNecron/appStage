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
            var node = doc.SelectSingleNode("/appSettings/add[@key='IP']");
            if (node.Attributes != null) mariaDb += "Server" + node.Attributes["value"].Value + ";";
            node = doc.SelectSingleNode("/appSettings/add[@key='DB']");
            mariaDb += "Port=3306;";
            if (node.Attributes != null) mariaDb += "Database" + node.Attributes["value"].Value + ";";
            node = doc.SelectSingleNode("/appSettings/add[@key='UTILISATEUR']");
            if (node.Attributes != null) mariaDb += "Uid" + node.Attributes["value"].Value + ";";
            node = doc.SelectSingleNode("/appSettings/add[@key='MOTDEPASSE']");
            if (node.Attributes != null) mariaDb += "Pwd" + node.Attributes["value"].Value + ";";
            mariaDb += "Trusted_Connection=True;";
            db = new LinqToDB.Data.DataConnection(
                LinqToDB.ProviderName.MySql,
                mariaDb);
        }
    }

    [LinqToDB.Mapping.Table(Name = "utilisateur")]
    public class Utilisateur
    {
        [PrimaryKey, LinqToDB.Mapping.Column(Name = "nomUtilisateur")]
        public string NomUtilisateur { get; set; }

        [LinqToDB.Mapping.Column(Name = "hash")]
        public string Hash { get; set; }

        [LinqToDB.Mapping.Column(Name = "themeBool")]
        public bool ThemeBool { get; set; }
    }
    
    
    [LinqToDB.Mapping.Table(Name = "logAction")]
    public class LogAction
    {
        [LinqToDB.Mapping.Column(Name = "dateAction"), PrimaryKey]
        public DateTime DateAction { get; set; }

        [LinqToDB.Mapping.Column(Name = "nomUtilisateur"), PrimaryKey]
        public string NomUtilisateur { get; set; }

        [LinqToDB.Mapping.Column(Name = "action")]
        public string Action { get; set; }

        [LinqToDB.Mapping.Column(Name = "adMac")]
        public string AdMac { get; set; }

        [LinqToDB.Mapping.Association(ThisKey = "NomUtilisateur", OtherKey = "NomUtilisateur")]
        public Utilisateur Utilisateur { get; set; }
    }

    [LinqToDB.Mapping.Table("logMotDePasse")]
    public class LogMotDePasse
    {
        [LinqToDB.Mapping.Column("dateLogMotDePasse"), PrimaryKey]
        public DateTime Date { get; set; }

        [LinqToDB.Mapping.Column("hash")]
        public string Hash { get; set; }

        [LinqToDB.Mapping.Column("nomUtilisateur")]
        public string NomUtilisateur { get; set; }

        [LinqToDB.Mapping.Association(ThisKey = "Hash", OtherKey = "Hash", CanBeNull = false)]
        public Utilisateur Utilisateur { get; set; }
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