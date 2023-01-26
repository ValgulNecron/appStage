using System.Data;
using System.Data.Entity;
using System.Xml;
using MySql.Data.MySqlClient;

namespace CartesAcces
{
    public static class ClassSql
    {
        public static MySqlConnection connexionBdd;

        public static void init()
        {
            var configFile = "./config.xml";
            var doc = new XmlDocument();
            doc.Load(configFile);
            var nodeIp = doc.SelectSingleNode("/configuration/appSettings/add[@key='IP']");
            var ip = nodeIp.Attributes["value"].Value;
            var nodeBd = doc.SelectSingleNode("/configuration/appSettings/add[@key='BD']");
            var bd = nodeBd.Attributes["value"].Value;
            var nodeUtilisateur = doc.SelectSingleNode("/configuration/appSettings/add[@key='UTILISATEUR']");
            var utilisateur = nodeUtilisateur.Attributes["value"].Value;
            var nodeMotDePasse = doc.SelectSingleNode("/configuration/appSettings/add[@key='MOTDEPASSE']");
            var motDePasse = nodeMotDePasse.Attributes["value"].Value;
            var sqlCreateur = new MySqlConnectionStringBuilder();
            sqlCreateur.Server = ip;
            sqlCreateur.Port = 3306;
            sqlCreateur.Database = bd;
            sqlCreateur.UserID = utilisateur;
            sqlCreateur.Password = motDePasse;
            var texteConnexion = sqlCreateur.ConnectionString;
            connexionBdd = new MySqlConnection(texteConnexion);
        }
    }
}