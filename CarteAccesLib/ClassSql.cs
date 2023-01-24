using System.Data;
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

        public static string getUser(string user)
        {
            var motDePasse = "";
            connexionBdd.Open();
            var commande = new MySqlCommand("getUser", connexionBdd);
            commande.CommandType = CommandType.StoredProcedure;
            commande.Parameters.AddWithValue("@user", user);
            var lecteur = commande.ExecuteReader();
            while (lecteur.Read()) motDePasse = lecteur["hash"].ToString();
            connexionBdd.Close();
            Globale._nomUtilisateur = user;
            return motDePasse;
        }

        public static void setUser(string user, string hash)
        {
            connexionBdd.Open();
            var command = new MySqlCommand("setUser", connexionBdd);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@targetUser", user);
            command.Parameters.AddWithValue("@setHash", hash);
            command.Parameters.AddWithValue("@setThemeBool", Globale._estEnModeSombre);
            command.ExecuteNonQuery();
            connexionBdd.Close();
        }
    }
}