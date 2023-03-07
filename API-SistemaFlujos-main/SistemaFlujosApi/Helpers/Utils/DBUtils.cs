using Oracle.ManagedDataAccess.Client;

namespace api.grupokmm.flujos.Helpers.Utils
{
    public class DBUtils
    {
        public static OracleConnection GetDBConnection()
        {
            string host = "192.168.2.39";
            int port = 1521;
            string sid = "VIBA";
            string user = "viba_prd";
            string password = "viba_prd";
            //Listo, perdon, faltó puerto. Listo 
            return DBOracleUtils.GetDBConnection(host, port, sid, user, password);
        }
    }
}
