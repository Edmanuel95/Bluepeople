using api.grupokmm.flujos.Entities;
using api.grupokmm.flujos.Helpers.Data.Models;
using api.grupokmm.flujos.Helpers.Emun;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;

namespace api.grupokmm.flujos.Helpers.Data
{
    public class ProyeccionDataHelper
    {
        public string message { get; set; }
        public bool status { get; set; }

        private string _flujos = string.Empty;

        private readonly IConfiguration _configuration;

        public SistemaFlujosContext _DbContext;

        public ProyeccionDataHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _flujos = configuration.GetConnectionString("flujos");

        }
        public ProyeccionDataHelper(SistemaFlujosContext dbContext)
        {
            _DbContext = dbContext;
        }
        public ProyeccionDataHelper()
        {
            _DbContext = new SistemaFlujosContext();
        }

        public Response UpdatePayments()
        {
            Response oResponse = new Response();
            BillsDataHelper billsData = new BillsDataHelper(_configuration);
            try
            {
                List<payment> payments = getPayments();
                List<invoiceProjection> invoices = getInvoicesProjection();

                foreach (invoiceProjection invoice in invoices)
                {
                    IEnumerable<payment> payment = payments.Where(i => i.invoice == invoice.idInvoice && i.installation == invoice.installation);

                    if (payment.Count() > 0)
                    {
                        string []sDate = payment.First().date.ToString().Split("/");
                        requestNew oRequest = new requestNew()
                        {
                            amount = payment.First().amountMn,
                            idClient = invoice.idClient ,
                            idProjection = invoice.idDetailProjection ,
                            idUser = invoice.idUser ,
                            collectionDate = sDate[2]+"-"+ sDate[1] + "-"+ sDate[0]
                        };

                        updCollectionAmount(oRequest);
                    }

                }

               


                oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = "Ok";
                
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }

            return oResponse;
        }

        public Response Dashboard(int Id)
        {
            Response oResponse = new Response();
            BillsDataHelper billsData = new BillsDataHelper(_configuration);
            try
            {
                DataTable tb = getDashboard(Id.ToString());
                List<Clients> clients = billsData.getClients();
                string json = string.Empty;
                if (tb != null)
                {

                    foreach (DataRow row in tb.Rows)
                    {
                        json += row[0].ToString();
                    }

                    Dashboard[] dashboards = System.Text.Json.JsonSerializer.Deserialize<Dashboard[]>(json);

                    foreach (Dashboard dashboard in dashboards)
                    {
                        foreach (Clients client in clients)
                        {
                            if (dashboard.idclient== client.idClient)
                            {
                                dashboard.client = client.client;
                            }
                        }
                    }

                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = JsonConvert.SerializeObject( dashboards);
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
        public Response Add(Projection oProyeccion)
        {
            Response oResponse = new Response();
            try
            {
                DataTable tb = add(oProyeccion);

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

        public Response Delete(int id)
        {
            Response oResponse = new Response();
            try
            {
                Proyeccion resultDelete = _DbContext.Proyeccions.FirstOrDefault(x => x.IdProyeccion == id);
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
                    oResponse.result = "No se elimino el Proyeccion";
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
                Proyeccion resultGet = _DbContext.Proyeccions.FirstOrDefault(x => x.IdProyeccion == id); ;

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
                    oResponse.result = "No existe el Proyeccion";
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
                List<Proyeccion> resultGet = _DbContext.Proyeccions.ToList();

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

        public Response Update(Proyeccion oProyeccion)
        {
            Response oResponse = new Response();
            try
            {
                var resultUpdate = _DbContext.Proyeccions.Update(oProyeccion);
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

        private DataTable add(Projection oProjection  )
        {
            DataAccess db = new DataAccess();
            DataTable result = new DataTable();

            try
            {
                string[] strParms = new string[] { oProjection.idWeek, oProjection.idUser };
                DataSet ds = db.ExecuteSP("setProjection", strParms, _flujos);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    status = false;
                    message = string.Format("Error al crear e usuario {0}", oProjection.idUser);
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

        private DataTable getDashboard(string Id)
        {
            DataAccess db = new DataAccess();
            DataTable result = new DataTable();

            try
            {
                string[] strParms = new string[] { Id };
                DataSet ds = db.ExecuteSP("getDashborad", strParms, _flujos);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    status = false;
                    message = string.Format("Error obtener el {0}", "Dashboard");
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


        private bool updCollectionAmount(requestNew oRequest)
        {
            DataAccess db = new DataAccess();
            bool result = false;

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
                    result = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        private List<invoiceProjection> getInvoicesProjection()
        {
            DataAccess db = new DataAccess();
            DataTable result = new DataTable();
            List<invoiceProjection> InvoicesList = new List<invoiceProjection>();

            try
            {
                string[] strParms = null;
                DataSet ds = db.ExecuteSP("getInvoicesProjection", strParms, _flujos);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    status = false;
                    message = string.Format("Error obtener el {0}", "Dashboard");
                }
                else
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        invoiceProjection invoice = new invoiceProjection();
                        invoice.idInvoice = item["idInvoice"].ToString();
                        invoice.installation = item["installation"].ToString();
                        invoice.idClient = item["idClient"].ToString();
                        invoice.idDetailProjection = item["idDetailProjection"].ToString();
                        invoice.idUser = item["idUser"].ToString();
                    
                        InvoicesList.Add(invoice);

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

            return InvoicesList;
        }


        List<payment> getPayments()
        {
            OracleConnection conn = Utils.DBUtils.GetDBConnection();
            List<payment> PaymentsList = new List<payment>();
            try
            {


                string select = string.Format("{0} as client,{1} as invoice,{2} as digital,{3} as installation,{4} as amount,{5} as amountMn,{6} as export,{7} as paymentDate ", "CLIENTE", "FACTURA", "DIGITAL", "INSTALACION", "MONTO", "MONTO_MN", "MONEDA", "FECHA");



                OracleCommand cmd = new OracleCommand();


                cmd.CommandText = string.Format("select {0} FROM pagos_facturas_2022 ", select);
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

                        PaymentsList.Add(oPaymentClient);
                    }
                }

            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
            conn.Close();
            return PaymentsList;
        }

    }
}
