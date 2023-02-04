namespace Voxed.WebApp.Helpers
{
    public class DatabaseHelpers
    {
        //public static string GetRDSConnectionString(Microsoft.Extensions.Configuration.IConfiguration config)
        //{
        //    string dbname = config["RDS_DB_NAME"];

        //    if (string.IsNullOrEmpty(dbname)) return null;

        //    string username = config["RDS_USERNAME"];
        //    string password = config["RDS_PASSWORD"];
        //    string hostname = config["RDS_HOSTNAME"];
        //    string port = config["RDS_PORT"];

        //    return "Data Source=" + hostname + "Port=" + port + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
        //}

        public static string GetRDSConnectionString(Microsoft.Extensions.Configuration.IConfiguration config)
        {
            string dbname = config["RDS_DB_NAME"];

            if (string.IsNullOrEmpty(dbname)) return null;

            string username = config["RDS_USERNAME"];
            string password = config["RDS_PASSWORD"];
            string hostname = config["RDS_HOSTNAME"];
            string port = config["RDS_PORT"];

            return "Host=" + hostname + "Port=" + port + ";Database=" + dbname + ";Username=" + username + ";Password=" + password + ";";
        }
    }
}
