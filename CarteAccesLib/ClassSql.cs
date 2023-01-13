using System.Data;
using System.Security.Policy;
using MySql.Data.MySqlClient;

namespace CartesAcces
{
    public static class ClassSql
    {
        public static MySqlConnection  connexionBdd;

        public static void init()
        {
            string ip = Configuration.getValue("IP");
            string bdd = Configuration.getValue("BD");
            string user = Configuration.getValue("USER");
            string pass = Configuration.getValue("PASS");
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = ip;
            builder.Port = 3306;
            builder.Database = bdd;
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