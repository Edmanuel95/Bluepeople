using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System;

namespace api.grupokmm.flujos.Helpers.Utils
{
    public class DBOracleUtils : DbContext
    {
        public static OracleConnection
        GetDBConnection(string host, int port, String sid, String user, String password)
        {
            // 'Connection string' to connect directly to Oracle.
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;


            OracleConnection conn = new OracleConnection();

            conn.ConnectionString = connString;

            return conn;
        }
    }
}
