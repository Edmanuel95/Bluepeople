using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace api.grupokmm.flujos.Helpers
{
    public class CacheParametrosSqlServer
    {
        static private Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        #region "Miembros Privados"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cadenaConexion"></param>
        /// <param name="nombrePA"></param>
        /// <returns></returns>
        private static SqlParameter[] discoverSpParameterSet(String cadenaConexion, String nombrePA)
        {
            SqlConnection sqlCon = new SqlConnection(cadenaConexion);
            SqlCommand sqlComando = new SqlCommand(nombrePA, sqlCon);

            try
            {
                sqlCon.Open();
                sqlComando.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(sqlComando);

                SqlParameter[] sqlParam = new SqlParameter[sqlComando.Parameters.Count];
                sqlComando.Parameters.CopyTo(sqlParam, 0);
                return sqlParam;
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Excepcion SQL en discoverParameter", sqlex);
            }
            finally
            {
                sqlCon.Dispose();
                sqlComando.Dispose();
            }
        }

        ///<summary>
        ///Realiza una copia profunda (clonación) del array de paramétros que se le pasa por paramétro.
        ///</summary> ///<author>Juan de Ituarte</author> ///<company>SLB</company>
        /// <author>Juan de Ituarte</author>
        /// <company>SLB</company>
        /// <param name="origen">Array de paramétros a copira</param>
        ///<returns>SqlParameter[] Array de paramétros</returns>
        private static SqlParameter[] cloneParameters(SqlParameter[] origen)
        {
            int i;
            int j = origen.Length;
            SqlParameter[] destino = new SqlParameter[origen.Length];

            for (i = 0; i < j; i++)
            {
                destino[i] = (SqlParameter)((ICloneable)origen[i]).Clone();
            }
            return destino;
        }

        /// <summary>
        /// 
        /// </summary>
        private const string _SEPARATOR = ":";
        private static string getHashKey(string cadenaConexion, string nombrePA)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(cadenaConexion);
            sb.Append(_SEPARATOR).Append(nombrePA);

            return sb.ToString();
        }

        #endregion

        #region "Miembros Públicos"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cadenaConexion"></param>
        /// <param name="nombrePA"></param>
        /// <returns></returns>
        public static SqlParameter[] getSqlParametersSP(String cadenaConexion, String nombrePA)
        {
            SqlParameter[] sqlParam;
            String hashKey = getHashKey(cadenaConexion, nombrePA);

            sqlParam = (SqlParameter[])paramCache[hashKey];

            if (sqlParam == null)
            {
                sqlParam = discoverSpParameterSet(cadenaConexion, nombrePA);

                paramCache[hashKey] = sqlParam;
            }

            return cloneParameters(sqlParam);
        }

        /// <summary>
        /// Borra una entrada de la cache
        /// </summary>
        /// <param name="cadenaConexion"></param>
        /// <param name="nombrePA"></param>
        public static void delSqlParametersSP(String cadenaConexion, String nombrePA)
        {
            paramCache[getHashKey(cadenaConexion, nombrePA)] = null;
        }

        #endregion
    }
}
