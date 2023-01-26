using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Xml;
using Microsoft.EntityFrameworkCore;

namespace CartesAcces
{
    public class ClassSql : DbContext
    {
        public System.Data.Entity.DbSet<Utilisateur> Utilisateurs { get; set; }
        public System.Data.Entity.DbSet<LogAction> LogActions { get; set; }
        public System.Data.Entity.DbSet<LogMotDePasse> LogMotDePasses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var doc = new XmlDocument();
            doc.Load("./config.xml");
            string mariaDb = "";
            var node = doc.SelectSingleNode("/appSettings/add[@key='IP']");
            if (node.Attributes != null) mariaDb += "Server" + node.Attributes["value"].Value + ";";
            node = doc.SelectSingleNode("/appSettings/add[@key='DB']");
            if (node.Attributes != null) mariaDb += "Database" + node.Attributes["value"].Value + ";";
            node = doc.SelectSingleNode("/appSettings/add[@key='UTILISATEUR']");
            if (node.Attributes != null) mariaDb += "Uid" + node.Attributes["value"].Value + ";";
            node = doc.SelectSingleNode("/appSettings/add[@key='MOTDEPASSE']");
            if (node.Attributes != null) mariaDb += "Pwd" + node.Attributes["value"].Value + ";";
            optionsBuilder.UseMySql(mariaDb);
        }
    }
    
    public class Utilisateur
    {
        [Key]
        public string NomUtilisateur { get; set; }
        public string Hash { get; set; }
        public bool ThemeBool { get; set; }
    }
    
    public class LogAction
    {
        [Key]
        [Column(Order = 0)]
        public DateTime DateAction { get; set; }

        [Key]
        [Column(Order = 1)]
        public string NomUtilisateur { get; set; }
        public string Action { get; set; }
        public string AdMac { get; set; }

        [ForeignKey("NomUtilisateur")]
        public Utilisateur Utilisateur { get; set; }
    }
    
    public class LogMotDePasse
    {
        [Key]
        [Column(Order = 0)]
        public DateTime DateLogMotDePasse { get; set; }
        [Key]
        [Column(Order = 1)]
        public string NomUtilisateur { get; set; }
        public string Hash { get; set; }

        [ForeignKey("Hash")]
        public Utilisateur Utilisateur { get; set; }
    }
    
    
}