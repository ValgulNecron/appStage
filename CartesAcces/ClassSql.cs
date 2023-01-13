using System.Data.SqlClient;

namespace CartesAcces
{
    public static class ClassSql
    {
        public static SqlConnection connexionBdd;

        public static void init()
        {
            string ip = Configuration.getValue("IP");
            string bdd = Configuration.getValue("BD");
            string user = Configuration.getValue("USER");
            string pass = Configuration.getValue("PASS");
        }
    }
}