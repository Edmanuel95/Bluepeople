using api.grupokmm.flujos.Entities;
using api.grupokmm.flujos.Helpers.Data.Models;
using api.grupokmm.flujos.Helpers.Emun;
using api.grupokmm.flujos.Helpers.Utils;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace api.grupokmm.flujos.Helpers.Data
{
    public class DetalleProyeccionDataHelper
    {
        public SistemaFlujosContext _DbContext;

        public string message { get; set; }
        public bool status { get; set; }

        private string _flujos = string.Empty;

        private readonly IConfiguration _configuration;
        public DetalleProyeccionDataHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _flujos = configuration.GetConnectionString("flujos");

        }

        public DetalleProyeccionDataHelper(SistemaFlujosContext dbContext)
        {
            _DbContext = dbContext;
        }
        public DetalleProyeccionDataHelper()
        {
            _DbContext = new SistemaFlujosContext();
        }
        public Response Add(Details[] oDetalleProyeccion)
        {
            Response oResponse = new Response();
            try
            {
                foreach (Details item in oDetalleProyeccion)
                {

                    DataTable tb = add(item);

                    if (tb != null)
                    {
                        oResponse.code = (int)StatusResponse.OK;
                        oResponse.message = StatusResponse.OK.ToString();
                        oResponse.result = tb.Rows[0][0].ToString();
                    }
                    else
                    {
                        oResponse.code = (int)StatusResponse.Warning;
                        oResponse.message = StatusResponse.Warning.ToString();
                        oResponse.result = "No existen protecciones";
                    }
                }
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }

            return oResponse;
        }

        public Response Delete(int id)
        {
            Response oResponse = new Response();
            try
            {
                DetalleProyeccion resultDelete = _DbContext.DetalleProyeccions.FirstOrDefault(x => x.IdDetalleProyeccion == id);
                if (resultDelete != null)
                {
                    _DbContext.Remove(resultDelete);
                    _DbContext.SaveChanges();

                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = _DbContext.SaveChanges();
                }
                else
                {
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "No se elimino el DetalleProyeccion";
                }
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Get(int id)
        {

            Response oResponse = new Response();
            try
            {
                DetalleProyeccion resultGet = _DbContext.DetalleProyeccions.FirstOrDefault(x => x.IdDetalleProyeccion == id); ;

                if (resultGet != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = resultGet;
                }
                else
                {
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "No existe el DetalleProyeccion";
                }
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Get()
        {
            Response oResponse = new Response();
            try
            {
                List<DetalleProyeccion> resultGet = _DbContext.DetalleProyeccions.ToList();

                if (resultGet != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = resultGet;
                }
                else
                {
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "No existen protecciones";
                }
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }

            return oResponse;
        }

        public Response Update(DetalleProyeccion oDetalleProyeccion)
        {
            Response oResponse = new Response();
            try
            {
                var resultUpdate = _DbContext.DetalleProyeccions.Update(oDetalleProyeccion);
                if (resultUpdate != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = _DbContext.SaveChanges();
                }
                else
                {
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "Update no realizado";
                }
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        private DataTable add(Details oDetails)
        {
            DataAccess db = new DataAccess();
            DataTable result = new DataTable();

            try
            {
                string amount = "0.0";
                string date = "";
                List<payment> oPayments = getPayments(oDetails.idInvoice, oDetails.installation);



                foreach (payment item in oPayments)
                {

                    string[] auxDate  = item.date.Split("/");
                    date = auxDate[2] +"-"+ auxDate[1] +"-" +auxDate[0];
                    amount = item.amountMn;
                }

                string[] strParms = new string[] { oDetails.idUser, oDetails.amount, oDetails.idProjection, oDetails.idDay, oDetails.idClient, oDetails.idInvoice, oDetails.paymentDate, oDetails.type, oDetails.idDigital , oDetails.installation,amount};
                DataSet ds = db.ExecuteSP("setDetailsProjection", strParms, _flujos);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    status = false;
                    message = string.Format("Error al crear e usuario {0}", oDetails.idUser);
                }
                else
                {
                    if (amount != "0.0" && date != "")
                    {
                        requestNew request = new requestNew();
                        request.idClient = oDetails.idClient;
                        request.idProjection = ds.Tables[0].Rows[0]["DetalleProyeccion"].ToString();
                        request.idUser = oDetails.idUser;
                        request.amount = amount;
                        request.collectionDate = date;

                        setCollectionAmount(request);
                    }

                    status = true;
                    message = "Ok";
                    result = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

     
        List<payment> getPayments(string idInvoice,string installation)
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            List<payment> InvoicesList = new List<payment>();
            try
            {                  
                 

                string select = string.Format("{0} as client,{1} as invoice,{2} as digital,{3} as installation,{4} as amount,{5} as amountMn,{6} as export,{7} as paymentDate ", "CLIENTE", "FACTURA", "DIGITAL", "INSTALACION", "MONTO", "MONTO_MN", "MONEDA", "FECHA");
                string where =  string.Format("factura={0} AND instalacion={1}", idInvoice, installation);
               
                
                OracleCommand cmd = new OracleCommand();


                cmd.CommandText = string.Format("select {0} FROM pagos_facturas_2022 WHERE {1}  ", select, where );
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();
                OracleDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        payment oPaymentClient = new payment();
                        oPaymentClient.idclient = dr["client"].ToString();
                        oPaymentClient.invoice = dr["invoice"].ToString();
                        oPaymentClient.digital = dr["digital"].ToString();
                        oPaymentClient.installation = dr["installation"].ToString();
                        oPaymentClient.amount = dr["amount"].ToString();
                        oPaymentClient.amountMn = dr["amountMn"].ToString();
                        oPaymentClient.money = dr["export"].ToString();
                        oPaymentClient.date = dr["paymentDate"].ToString().Replace("/00", "/20").Substring(0, 10);

                        InvoicesList.Add(oPaymentClient);
                    }
                }

            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
            conn.Close();
            return InvoicesList;
        }

        private DataTable setCollectionAmount(requestNew oRequest)
        {
            DataAccess db = new DataAccess();
            DataTable result = new DataTable();

            try
            {
                string[] strParms = new string[] { oRequest.idUser, oRequest.idClient, oRequest.idProjection, oRequest.collectionDate, oRequest.amount };
                DataSet ds = db.ExecuteSP("setCollectionAmount", strParms, _flujos);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    status = false;
                    message = string.Format("Error al crear e usuario {0}", oRequest.idClient);
                }
                else
                {
                    status = true;
                    message = "Ok";
                    result = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }
    }
}
