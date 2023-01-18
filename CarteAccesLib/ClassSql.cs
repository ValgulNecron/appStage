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
            var nodeUser = doc.SelectSingleNode("/configuration/appSettings/add[@key='USER']");
            var user = nodeUser.Attributes["value"].Value;
            var nodePass = doc.SelectSingleNode("/configuration/appSettings/add[@key='PASS']");
            var pass = nodePass.Attributes["value"].Value;
            var builder = new MySqlConnectionStringBuilder();
            builder.Server = ip;
            builder.Port = 3306;
            builder.Database = bd;
            builder.UserID = user;
            builder.Password = pass;
            var connectionString = builder.ConnectionString;
            connexionBdd = new MySqlConnection(connectionString);
        }

        public static string getUser(string user)
        {
            var password = "";
            connexionBdd.Open();
            var command = new MySqlCommand("getUser", connexionBdd);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@user", user);
            var reader = command.ExecuteReader();
            while (reader.Read()) password = reader["hash"].ToString();
            connexionBdd.Close();
            Globale._nomUtilisateur = user;
            return password;
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