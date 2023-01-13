using System.Data;
using System.Security.Policy;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Xml;

namespace CartesAcces
{
    public static class ClassSql
    {
        public static MySqlConnection  connexionBdd;

        public static void init()
        {
            string configFile = "./config.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(configFile);
            XmlNode nodeIp = doc.SelectSingleNode("/configuration/appSettings/add[@key='IP']");
            string ip = nodeIp.Attributes["value"].Value;
            XmlNode nodeBd = doc.SelectSingleNode("/configuration/appSettings/add[@key='BD']");
            string bd = nodeBd.Attributes["value"].Value;
            XmlNode nodeUser = doc.SelectSingleNode("/configuration/appSettings/add[@key='USER']");
            string user = nodeUser.Attributes["value"].Value;
            XmlNode nodePass = doc.SelectSingleNode("/configuration/appSettings/add[@key='PASS']");
            string pass = nodePass.Attributes["value"].Value;
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = ip;
            builder.Port = 3306;
            builder.Database = bd;
            builder.UserID = user;
            builder.Password = pass;
            string connectionString = builder.ConnectionString;
            connexionBdd = new MySqlConnection(connectionString);
        }

        public static string getUser(string user)
        {
            string password = "";
            connexionBdd.Open();
            MySqlCommand command = new MySqlCommand("getUser", connexionBdd);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@user", user);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                password = reader["hash"].ToString();
            }
            connexionBdd.Close();
            Globale._nomUtilisateur = user;
            return password;
        }

        public static void setUser(string user, string hash)
        {
            connexionBdd.Open();
            MySqlCommand command = new MySqlCommand("setUser", connexionBdd);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@targetUser", user);
            command.Parameters.AddWithValue("@setHash", hash);
            command.Parameters.AddWithValue("@setThemeBool", Globale._estEnModeSombre);
            command.ExecuteNonQuery();
            connexionBdd.Close();
        }
    }
}