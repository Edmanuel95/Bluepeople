using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace api.grupokmm.flujos.Helpers
{
    public class DataAccess
    {
        /// <summary>
        /// DataAccess
        /// </summary>
        public DataAccess()
        {
        }

        /// <summary>
        /// Execute store procedure
        /// </summary>
        /// <param name="strStoredP"></param>
        /// <param name="strParms"></param>
        /// <param name="conexion"></param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteSP(string strStoredP, string[] strParms, string conexion)
        {
            DataSet ds_result = new DataSet();
            try
            {
                using (SqlConnection Connection = new SqlConnection())
                {
                    Connection.ConnectionString = conexion;

                    int index = 0;
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = Connection;
                    sqlcmd.CommandText = strStoredP;
                    sqlcmd.CommandType = CommandType.StoredProcedure;

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Connection;
                    cmd.CommandText = strStoredP;
                    cmd.CommandType = CommandType.StoredProcedure;

                    Connection.Open();
                    SqlCommandBuilder.DeriveParameters(sqlcmd);
                    Connection.Close();

                    foreach (SqlParameter param in sqlcmd.Parameters)
                    {
                        if (param.Direction == ParameterDirection.Input || param.Direction == ParameterDirection.InputOutput)
                        {
                            cmd.Parameters.Add(new SqlParameter(param.ParameterName, param.DbType));
                            cmd.Parameters[index].Value = strParms[index];
                            index = index + 1;
                        }
                    }
                    SqlDataAdapter sqlDataDapter = new SqlDataAdapter(cmd);
                    sqlDataDapter.Fill(ds_result);
                }
                return ds_result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Execute store procedure
        /// </summary>
        /// <param name="cadenaConexion"></param>
        /// <param name="nombreSP"></param>
        /// <param name="listaParametros"></param>
        /// <returns></returns>
        public DataSet ExecuteSP(string cadenaConexion, string nombreSP, Hashtable listaParametros)
        {

            //Obtengo la estructura básica del comando
            SqlCommand objCommand = GetCommand(cadenaConexion, nombreSP);

            try
            {
                asociarValorAParametros(objCommand, listaParametros);
                return Execute(objCommand, listaParametros);
            }
            catch
            {

                try
                {
                    //Si falla volvemos a coger los parametros de la BD y repetimos la operacion
                    CacheParametrosSqlServer.delSqlParametersSP(cadenaConexion, nombreSP);

                    objCommand = GetCommand(cadenaConexion, nombreSP);

                    asociarValorAParametros(objCommand, listaParametros);
                    return Execute(objCommand, listaParametros);
                }
                catch (Exception e1)
                {
                    string msgError = "Error al ejecutar el procedimiento almacenado '{0}' con los parametros siguientes: {1}.";
                    throw new Exception(string.Format(msgError, nombreSP, getInfoCadenaParametros(listaParametros)), e1);
                }
            }
        }


        public void ExecuteNonQuerySP(string strStoredP, string[] strParms, string conexion)
        {
            DataSet ds_result = new DataSet();
            try
            {
                using (SqlConnection Connection = new SqlConnection())
                {
                    Connection.ConnectionString = conexion;

                    int index = 0;
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = Connection;
                    sqlcmd.CommandText = strStoredP;
                    sqlcmd.CommandType = CommandType.StoredProcedure;

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Connection;
                    cmd.CommandText = strStoredP;
                    cmd.CommandType = CommandType.StoredProcedure;

                    Connection.Open();
                    SqlCommandBuilder.DeriveParameters(sqlcmd);

                    foreach (SqlParameter param in sqlcmd.Parameters)
                    {
                        if (param.Direction == ParameterDirection.Input || param.Direction == ParameterDirection.InputOutput)
                        {
                            cmd.Parameters.Add(new SqlParameter(param.ParameterName, param.DbType));
                            cmd.Parameters[index].Value = strParms[index];
                            index = index + 1;
                        }
                    }


                    cmd.ExecuteNonQuery();

                    Connection.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private SqlCommand GetCommand(string stringConnection, string nombreProcedimientoAlmacenado)
        {
            nombreProcedimientoAlmacenado = nombreProcedimientoAlmacenado.ToUpper();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandText = nombreProcedimientoAlmacenado;
            objCommand.CommandType = CommandType.StoredProcedure;

            SqlConnection objConn = new SqlConnection(stringConnection);
            objCommand.Connection = objConn;

            //Poner traza de recuperando elemento de la cache
            SqlParameter[] lstParams = CacheParametrosSqlServer.getSqlParametersSP(stringConnection, nombreProcedimientoAlmacenado);

            foreach (SqlParameter param in lstParams)
            {
                objCommand.Parameters.Add(
                    new SqlParameter(
                    param.ParameterName,
                    param.SqlDbType,
                    param.Size,
                    param.Direction,
                    param.IsNullable,
                    param.Precision,
                    param.Scale,
                    param.SourceColumn,
                    param.SourceVersion,
                    DBNull.Value));
            }

            return objCommand;
        }

        /// <summary>
		/// 
		/// </summary>
		/// <param name="objCommand"></param>
		/// <param name="listaParametrosLlamada"></param>
		private void asociarValorAParametros(SqlCommand objCommand, Hashtable listaParametrosLlamada)
        {
            // Inserto los valores de los parametros en los parametros
            // del procedimiento almacenado
            if (listaParametrosLlamada != null)
            {
                IDictionaryEnumerator enumerator = listaParametrosLlamada.GetEnumerator();
                object oParameter;
                object oParameterValue;
                SqlParameter sqlParameter;
                while (enumerator.MoveNext())
                {
                    oParameter = objCommand.Parameters[enumerator.Key.ToString()];
                    if (oParameter != null)
                    {
                        sqlParameter = (SqlParameter)oParameter;
                        if (sqlParameter.Direction == ParameterDirection.Input ||
                            sqlParameter.Direction == ParameterDirection.InputOutput)
                        {
                            oParameterValue = listaParametrosLlamada[sqlParameter.ParameterName];
                            if (oParameterValue == null)
                            {
                                sqlParameter.Value = DBNull.Value;
                            }
                            else
                            {
                                if (oParameterValue is String || oParameterValue is string)
                                {
                                    if (sqlParameter.ParameterName.Contains("TOKEN_TARJETA"))
                                        sqlParameter.Value = ((String)oParameterValue);
                                    else
                                        sqlParameter.Value = ((String)oParameterValue).ToUpper();
                                }
                                else
                                {
                                    sqlParameter.Value = listaParametrosLlamada[sqlParameter.ParameterName];
                                }
                            }
                        }
                        else
                        {
                            throw new Exception(string.Format("El parametro '{0}' del procedimiento almacenado '{1}' no es de entrada, y sin embargo se ha pasado como parametro de entrada.", enumerator.Key.ToString(), objCommand.CommandText));
                        }
                    }
                    else
                    {
                        throw new Exception(string.Format("No se ha encontrado el parametro '{0}' en el procedimiento almacenado '{1}'.", enumerator.Key.ToString(), objCommand.CommandText));

                    }
                }
            }
        }

        /// <summary>
        /// Execute command sql
        /// </summary>
        /// <param name="objCommand"></param>
        /// <param name="outputParams"></param>
        /// <returns></returns>
        private DataSet Execute(SqlCommand objCommand, Hashtable outputParams)
        {
            try
            {
                DataSet objDataSet = new DataSet();
                SqlDataAdapter objAdapter = GetAdapter(objCommand);
                objAdapter.Fill(objDataSet);

                //Los parametros de salida del procedimiento almacenado los insertamos la hash de salida
                foreach (SqlParameter param in objCommand.Parameters)
                {
                    if (((param.Direction == ParameterDirection.InputOutput) || (param.Direction == ParameterDirection.Output)))
                    {
                        //Si no lo han metido como parametro de salida
                        if (!outputParams.ContainsKey(param.ParameterName))
                        {
                            outputParams.Add(param.ParameterName, null);
                        }

                        //Si el parametro que retorna el SP es un DBNull lo asignamos a la Hash como null
                        if (param.Value is System.DBNull)
                        {
                            outputParams[param.ParameterName] = null;
                        }
                        else
                        {
                            outputParams[param.ParameterName] = param.Value;
                        }
                    }
                }

                return objDataSet;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                objCommand.Connection.Close();
            }
        }

        private void ExecuteNonQuery(SqlCommand objCommand, Hashtable outputParams)
        {
            try
            {
                //DataSet objDataSet = new DataSet();
                //SqlDataAdapter objAdapter = GetAdapter(objCommand);
                //objAdapter.Fill(objDataSet);

                //Los parametros de salida del procedimiento almacenado los insertamos la hash de salida
                foreach (SqlParameter param in objCommand.Parameters)
                {
                    if (((param.Direction == ParameterDirection.InputOutput) || (param.Direction == ParameterDirection.Output)))
                    {
                        //Si no lo han metido como parametro de salida
                        if (!outputParams.ContainsKey(param.ParameterName))
                        {
                            outputParams.Add(param.ParameterName, null);
                        }

                        //Si el parametro que retorna el SP es un DBNull lo asignamos a la Hash como null
                        if (param.Value is System.DBNull)
                        {
                            outputParams[param.ParameterName] = null;
                        }
                        else
                        {
                            outputParams[param.ParameterName] = param.Value;
                        }
                    }
                }

                objCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                objCommand.Connection.Close();
            }
        }

        private SqlDataAdapter GetAdapter(SqlCommand objCommand)
        {
            SqlDataAdapter objAdapter;

            objAdapter = new SqlDataAdapter();
            objAdapter.SelectCommand = objCommand;

            return objAdapter;
        }

        /// <summary>
		/// 
		/// </summary>
		/// <param name="htParams"></param>
		/// <returns></returns>
		private string getInfoCadenaParametros(Hashtable htParams)
        {
            string strParametros = string.Empty;
            if (htParams == null)
            {
                strParametros = "Lista de parametros nula.";
            }
            else
            {
                if (htParams.Count == 0)
                {
                    strParametros = "Lista de parametros vacia.";
                }
                else
                {
                    strParametros += "[";
                    IEnumerator listaClaves = htParams.Keys.GetEnumerator();
                    listaClaves.MoveNext();
                    object claveAux = listaClaves.Current;
                    object valueAux = null;
                    strParametros += claveAux.ToString() + "=" + htParams[claveAux];
                    while (listaClaves.MoveNext())
                    {
                        claveAux = listaClaves.Current;
                        valueAux = htParams[claveAux];
                        if (valueAux == null)
                        {
                            strParametros += ", " + claveAux.ToString() + "=null";
                        }
                        else
                        {
                            strParametros += ", " + claveAux.ToString() + "=" + valueAux.ToString();
                        }
                    }
                    strParametros += "]";
                }
            }

            return strParametros;
        }
    }
}
