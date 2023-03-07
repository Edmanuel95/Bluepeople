using api.grupokmm.flujos.Entities;
using api.grupokmm.flujos.Helpers.Data.Models;
using api.grupokmm.flujos.Helpers.Emun;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using api.grupokmm.flujos.Helpers.Utils;

namespace api.grupokmm.flujos.Helpers.Data
{
    public class CobradoRealDataHelper
    {
        public SistemaFlujosContext _DbContext;
        public string message { get; set; }
        public bool status { get; set; }

        private string _flujos = string.Empty;
        private readonly IConfiguration _configuration;

        public CobradoRealDataHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _flujos = configuration.GetConnectionString("flujos");

        }
        public CobradoRealDataHelper(SistemaFlujosContext dbContext)
        {
            _DbContext = dbContext;
        }
        public CobradoRealDataHelper()
        {
            _DbContext = new SistemaFlujosContext();
        }
        public Response Add(requestNew  oCobradoReal)
        {
            Response oResponse = new Response();
            try
            {
                DataTable tb = add(oCobradoReal);

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
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }

            return oResponse;
        }

        public Response GetSearch(requestCobradoReal oCobradoReal)
        {
            Response oResponse = new Response();
            BillsDataHelper billsData = new BillsDataHelper(_configuration);
            try
            {
                DataTable tb = getSearch(oCobradoReal);
                List<Clients> clients = billsData.getClients();
                string json = string.Empty;
                if (tb != null && tb.Rows.Count>0)
                {

                    foreach (DataRow row in tb.Rows) {
                        json += row[0].ToString();
                    }

                    
                    ProjectionVsReal[] projectionVsReals = System.Text.Json.JsonSerializer.Deserialize<ProjectionVsReal[]>(json);

                    foreach (ProjectionVsReal projectionVsReal in projectionVsReals)
                    {
                        foreach (Clients client in clients)
                        {
                            if (projectionVsReal.idClient.ToString() == client.idClient)
                            {
                                projectionVsReal.client = client.client;
                            }
                        }
                    }
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = JsonConvert.SerializeObject(projectionVsReals); 
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

        public Response Delete(int id)
        {
            Response oResponse = new Response();
            try
            {
                var cobradoReal = _DbContext.CobradoReals.FirstOrDefault(x => x.IdCobradoReal == id);
                if (cobradoReal != null)
                {
                    _DbContext.Remove(cobradoReal);
                    _DbContext.SaveChanges();

                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = _DbContext.SaveChanges();
                }
                else
                {
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "No se elimino el cobradoReal";
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
                CobradoReal cobradoReal = _DbContext.CobradoReals.FirstOrDefault(x => x.IdCobradoReal  == id); ;

                if (cobradoReal != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = cobradoReal;
                }
                else
                {
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "No existe el cobradoReal";
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
                List<CobradoReal> cobradoReals = _DbContext.CobradoReals.ToList();

                if (cobradoReals != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = cobradoReals;
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

        public Response Get(requestCobradoReal oCobradoReal)
        {
            Response oResponse = new Response();
            BillsDataHelper billsData = new BillsDataHelper(_configuration);
            try
            {
                string amount = "0.0";
                string date = "";
                DataTable tb = getInvoices(oCobradoReal);
                foreach (DataRow row in tb.Rows)
                {
                    List<payment> oPayments = getPayments(row["installation"].ToString(), row["invoice"].ToString());

                    foreach (payment item in oPayments)
                    {

                        string[] auxDate = item.date.Split("/");
                        date = auxDate[2] + "-" + auxDate[1] + "-" + auxDate[0];
                        amount = item.amountMn;

                        requestNew request = new requestNew();
                        request.idClient = row["idClient"].ToString();
                        request.idProjection = row["idProjection"].ToString();
                        request.idUser = row["idUser"].ToString();
                        request.amount = amount;
                        request.collectionDate = date;

                        updCollectionAmount(request);
                    }
                }



                  tb = get(oCobradoReal);
                List<Clients> clients = billsData.getClients();

                string json = string.Empty;
                if (tb != null)
                {
                    foreach (DataRow row in tb.Rows)
                    {
                        json += row[0].ToString();
                    }

                    CollectionReal[] collectionReals = System.Text.Json.JsonSerializer.Deserialize<CollectionReal[]>(json);

                    foreach (CollectionReal collectionReal in collectionReals)
                    {
                        foreach (Clients client in clients)
                        {
                            if (collectionReal.idClient.ToString() == client.idClient)
                            {
                                collectionReal.client = client.client;
                            }
                        }
                    }

                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = JsonConvert.SerializeObject(collectionReals);
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

        public Response Update(CobradoReal oCobradoReal)
        {
            Response oResponse = new Response();
            try
            {
                var resultUpdate = _DbContext.CobradoReals.Update(oCobradoReal);
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

        private DataTable get(requestCobradoReal oRequest)
        {
            DataAccess db = new DataAccess();
            DataTable result = new DataTable();

            try
            {
                string[] strParms = new string[] { oRequest.week.ToString(), oRequest.idClient.ToString() };
                DataSet ds = db.ExecuteSP("getActualAccumulated", strParms, _flujos);

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


        private DataTable getInvoices(requestCobradoReal oRequest)
        {
            DataAccess db = new DataAccess();
            DataTable result = new DataTable();

            try
            {
                string[] strParms = new string[] { oRequest.week.ToString(), oRequest.idClient.ToString() };
                DataSet ds = db.ExecuteSP("getSearchProjectionInvoice", strParms, _flujos);

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

        private DataTable add(requestNew oRequest)
        {
            DataAccess db = new DataAccess();
            DataTable result = new DataTable();

            try
            {
                string[] strParms = new string[] { oRequest.idUser ,oRequest.idClient, oRequest.idProjection, oRequest.collectionDate, oRequest.amount };
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

        private DataTable getSearch(requestCobradoReal oRequest)
        {
            DataAccess db = new DataAccess();
            DataTable result = new DataTable();

            try
            {
                string[] strParms = new string[] { oRequest.week.ToString(),  oRequest.idClient.ToString() };
                DataSet ds = db.ExecuteSP("getSearchProjection", strParms, _flujos);

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

        List<payment> getPayments(string idInvoice, string installation)
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            List<payment> InvoicesList = new List<payment>();
            try
            {


                string select = string.Format("{0} as client,{1} as invoice,{2} as digital,{3} as installation,{4} as amount,{5} as amountMn,{6} as export,{7} as paymentDate ", "CLIENTE", "FACTURA", "DIGITAL", "INSTALACION", "MONTO", "MONTO_MN", "MONEDA", "FECHA");
                string where = string.Format("factura={0} AND instalacion={1}", idInvoice, installation);


                OracleCommand cmd = new OracleCommand();


                cmd.CommandText = string.Format("select {0} FROM pagos_facturas_2022 WHERE {1}  ", select, where);
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

        private DataTable updCollectionAmount(requestNew oRequest)
        {
            DataAccess db = new DataAccess();
            DataTable result = new DataTable();

            try
            {
                string[] strParms = new string[] { oRequest.idUser, oRequest.idClient, oRequest.idProjection, oRequest.collectionDate, oRequest.amount };
                DataSet ds = db.ExecuteSP("updCollectionAmount", strParms, _flujos);

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