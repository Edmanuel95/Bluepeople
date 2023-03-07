using api.grupokmm.flujos.Entities;
using api.grupokmm.flujos.Helpers.Emun;
using api.grupokmm.flujos.Helpers.Utils;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.grupokmm.flujos.Helpers.Data
{
    public class BillsDataHelper
    {
        public string message { get; set; }
        public bool status { get; set; }

        public DBOracleUtils _DbContext;

        private string _flujos = string.Empty;
        private readonly IConfiguration _configuration;

        public BillsDataHelper(IConfiguration configuration )
        {
            _configuration = configuration;
            _flujos = configuration.GetConnectionString("flujos");
           
        }

        public BillsDataHelper(IConfiguration configuration, DBOracleUtils dbContext)
        {
            _configuration = configuration;
            _flujos = configuration.GetConnectionString("flujos");
            _DbContext = dbContext;

        }

        public Response BillsByCliente(Bills oBills)
        {
            Response oResponse = new Response();
            try
            {
                List <InvoiceClient> tb = getBillsByClient(oBills);

                if (tb != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = JsonConvert.SerializeObject(tb);
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

        public Response Bills(Bills oBills)
        {
            Response oResponse = new Response();
            try
            {
                List<Invoice> tb = getBills(oBills);
                DataTable oInvoicesByProjection = InvoicesByProjection();

                foreach (Invoice item in tb)
                {
                    oBills.idClient = item.idClient;

                   List<InvoiceClient> oInvoiceClients = getBillsByClient(oBills);
                    item.invoices = new List<InvoiceClient>();
                    bool flag = true;

                    foreach (InvoiceClient invoice in oInvoiceClients)
                    {
                        foreach (DataRow row in oInvoicesByProjection.Rows)
                        {
                            if (invoice.idBill == row["invoice"].ToString())
                            {
                                flag = false;
                            }
                        }
                        if (flag)
                        {
                            item.invoices.Add(invoice);
                        }
                    }
                }

                if (tb != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = JsonConvert.SerializeObject(tb);
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

        private DataTable InvoicesByProjection( )
        {
            DataAccess db = new DataAccess();
            DataTable result = new DataTable();

            try
            {
                string[] strParms = null;
                DataSet ds = db.ExecuteSP("getBillsByProjection", strParms, _flujos);

                 
                    result = ds.Tables[0];
             
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }


        public Response Clients( )
        {
            Response oResponse = new Response();
            try
            {
                List<Clients> tb = getClients();

                if (tb != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = JsonConvert.SerializeObject(tb);
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

        public Response Channels()
        {
            Response oResponse = new Response();
            try
            {
                List<Channels> tb = getChannels();

                if (tb != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = JsonConvert.SerializeObject(tb);
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

        public Response Sorters()
        {
            Response oResponse = new Response();
            try
            {
                List<Sorters> tb = getSorter();

                if (tb != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = JsonConvert.SerializeObject(tb);
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


        public List<Channels> getChannels()
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            List<Channels> ChannelsList = new List<Channels>();
            try
            {
                string date = DateTime.Now.ToShortDateString();

                string select = string.Format("{0} as idChannel,{1} as Channel", "CANAL", "DESCR_CANAL");
                string groupby = string.Format("GROUP BY {0},{1}", "CANAL", "DESCR_CANAL");
                OracleCommand cmd = new OracleCommand();

                cmd.CommandText = string.Format("select {0} FROM FACTURAS_CON_SALDO  {1} ", select, groupby);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();
                OracleDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    Channels oChannels = new Channels();
                    oChannels.idChannel = "0";
                    oChannels.channel ="TODOS";

                    ChannelsList.Add(oChannels);
                    while (dr.Read())
                    {
                        oChannels = new Channels();
                        oChannels.idChannel = dr["idChannel"].ToString();
                        oChannels.channel = dr["Channel"].ToString();

                        ChannelsList.Add(oChannels);
                    }
                }

            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
            conn.Close();
            return ChannelsList;
        }

        public List<Sorters> getSorter()
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            List<Sorters> SortersList = new List<Sorters>();
            try
            {
                string date = DateTime.Now.ToShortDateString();
                //CLASIFICADOR_FACTURA AS isSorter, DESCR_CLASIF AS sorter

                string select = string.Format("{0} as idSorter,{1} as sorter", "CLASIFICADOR_FACTURA", "DESCR_CLASIF");
                string groupby = string.Format("GROUP BY {0},{1}", "CLASIFICADOR_FACTURA", "DESCR_CLASIF");
                OracleCommand cmd = new OracleCommand();

                cmd.CommandText = string.Format("select {0} FROM FACTURAS_CON_SALDO  {1} ", select, groupby);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();
                OracleDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    Sorters oSorters = new Sorters();
                    oSorters.idSorter  = "0";
                    oSorters.sorter = "TODOS";

                    SortersList.Add(oSorters);
                    while (dr.Read())
                    {
                        oSorters = new Sorters();
                        oSorters.idSorter = dr["idSorter"].ToString();
                        oSorters.sorter = dr["sorter"].ToString();

                        SortersList.Add(oSorters);
                    }
                }

            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
            conn.Close();
            return SortersList;
        }

        public  List<Clients> getClients()
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            List<Clients> ClientsList = new List<Clients>();
            try
            {
                string date = DateTime.Now.ToShortDateString();

                string select = string.Format("{0} as idClient,{1} as client", "CLIENTE", "NOMBRECLIENTE");
                string groupby = string.Format("GROUP BY {0},{1}", "CLIENTE", "NOMBRECLIENTE");
                OracleCommand cmd = new OracleCommand();

                cmd.CommandText = string.Format("select {0} FROM FACTURAS_CON_SALDO  {1} ", select,  groupby);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();
                OracleDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    Clients oClients = new Clients();
                    oClients.idClient ="0";
                    oClients.client = "TODOS"; ;

                    ClientsList.Add(oClients);

                    while (dr.Read())
                    {
                        oClients = new Clients();
                        oClients.idClient = dr["idClient"].ToString();
                        oClients.client = dr["client"].ToString();

                        ClientsList.Add(oClients);
                    }
                }

            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
            conn.Close();
            return ClientsList;
        }





        List<Invoice> getBills(Bills oBills)
        {
            
            OracleConnection conn = DBUtils.GetDBConnection();
            List<Invoice> InvoicesList = new List<Invoice>();
            try
            {
                oBills.startPayDate=oBills.startPayDate.Replace("NaN", "").Replace("/", "").Replace(" ", "");
                oBills.endPayDate=oBills.endPayDate.Replace("NaN", "").Replace("/", "").Replace(" ", "");

                string date = DateTime.Now.ToShortDateString();

                string select = string.Format("{0} as idClient,{1} as client,Count({2}) as bill,SUM({3}) as balance,SUM({4}) as amount,SUM({4}) as balance_min,{5} as channel", "CLIENTE", "NOMBRECLIENTE", "DIGITAL", "SALDO", "SALDO_MN", "DESCR_CANAL");
                string whereClient = oBills.idClient == "0" ? "" :string.Format(" AND CLIENTE={0}", oBills.idClient);
                string whereChannel = oBills.idChannel == "0" ? "" : string.Format(" AND CANAL={0}", oBills.idChannel);
                string whereSorter = oBills.idSorter == "0" ? "" : string.Format(" AND CLASIFICADOR_FACTURA={0}", oBills.idSorter);
                string whereDate =  string.Format("FECHA_FACTURA BETWEEN TO_DATE('{0}','dd/mm/yyyy')  AND TO_DATE('{1}','dd/mm/yyyy')", oBills.startDate, oBills.endDate );
                string wherePayDate = string.IsNullOrEmpty(oBills.startPayDate)? "AND FECHA_PROGRAMADA_PAGO = FECHA_PROGRAMADA_PAGO" : string.Format(" AND FECHA_PROGRAMADA_PAGO BETWEEN TO_DATE('{0}','dd/mm/yyyy')  AND TO_DATE('{1}','dd/mm/yyyy')", oBills.startPayDate , oBills.endPayDate);
                string whereIdCollection = oBills.iduser  == "0" ? "" : string.Format(" AND ID_COBRADOR={0}", oBills.iduser);

                string groupby = string.Format("GROUP  BY {0},{1},{2}", "NOMBRECLIENTE", "DESCR_CANAL", "CLIENTE");    
                OracleCommand cmd = new OracleCommand();
                

                cmd.CommandText =string.Format( "select {0} FROM FACTURAS_CON_SALDO WHERE {1} {2} {3} {4} {5} {6} {7}", select, whereDate, whereClient, whereChannel, whereSorter , wherePayDate, whereIdCollection, groupby);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();
                OracleDataReader dr = cmd.ExecuteReader();
               

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Invoice oInvoice = new Invoice();
                        oInvoice.idClient = dr["idClient"].ToString();
                        oInvoice.client = dr["client"].ToString();
                        oInvoice.bill = dr["bill"].ToString();
                        oInvoice.balance = dr["balance"].ToString();
                        oInvoice.amount = dr["amount"].ToString();
                        oInvoice.balance_min = dr["balance_min"].ToString();
                        oInvoice.channel = dr["channel"].ToString();
                        InvoicesList.Add(oInvoice);
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

        List<InvoiceClient> getBillsByClient(Bills oBills) {
            OracleConnection conn = DBUtils.GetDBConnection();
            List<InvoiceClient> InvoicesList = new List<InvoiceClient>();
            try
            {
                oBills.startPayDate = oBills.startPayDate.Replace("NaN", "").Replace("/", "").Replace(" ", "");
                oBills.endPayDate = oBills.endPayDate.Replace("NaN", "").Replace("/", "").Replace(" ", "");

                string date = DateTime.Now.ToShortDateString();

                string select = string.Format("{0} as idBill,{1} as idClient,{2} as client, {3} as balanceMn,TO_DATE({4},'dd/mm/yyyy') as expiration, TO_DATE({5},'dd/mm/yyyy') as payment,{6} as balance, {7} as type, TO_CHAR( {5} , 'D') as day, {8} as invoice,{9} as installation", "DIGITAL", "CLIENTE", "NOMBRECLIENTE", "SALDO_MN", "FECHA_VENCIMIENTO_REAL", "fecha_programada_pago","SALDO","TIPO_CAMBIO", "factura", "instalacion");
                string whereClient = oBills.idClient == "0" ? "" : string.Format(" AND CLIENTE={0}", oBills.idClient);
                string whereChannel = oBills.idChannel == "0" ? "" : string.Format(" AND CANAL={0}", oBills.idChannel);
                string whereSorter = oBills.idSorter == "0" ? "" : string.Format(" AND CLASIFICADOR_FACTURA={0}", oBills.idSorter);
                string whereDate = string.Format("FECHA_FACTURA BETWEEN TO_DATE('{0}','dd/mm/yyyy')  AND TO_DATE('{1}','dd/mm/yyyy')", oBills.startDate, oBills.endDate);
                string wherePayDate = string.IsNullOrEmpty(oBills.startPayDate) ? "AND FECHA_PROGRAMADA_PAGO = FECHA_PROGRAMADA_PAGO" : string.Format(" AND FECHA_PROGRAMADA_PAGO BETWEEN TO_DATE('{0}','dd/mm/yyyy')  AND TO_DATE('{1}','dd/mm/yyyy')", oBills.startPayDate, oBills.endPayDate);

                OracleCommand cmd = new OracleCommand();


                cmd.CommandText = string.Format("select {0} FROM FACTURAS_CON_SALDO WHERE {1} {2} {3} {4} {5}", select, whereDate, whereClient, whereChannel, whereSorter, wherePayDate);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();
                OracleDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        InvoiceClient oInvoiceClient = new InvoiceClient();
                        oInvoiceClient.idBill = dr["idBill"].ToString();
                        oInvoiceClient.idClient = dr["idClient"].ToString();
                        oInvoiceClient.client = dr["client"].ToString();
                        oInvoiceClient.balance = dr["type"].ToString() == "1" ? string.Empty : dr["balance"].ToString();
                        oInvoiceClient.balanceMn = dr["balanceMn"].ToString();
                        oInvoiceClient.expiration = dr["expiration"].ToString().Replace("/00", "/20").Substring(0, 10);
                        oInvoiceClient.payment = dr["payment"].ToString().Replace("/00", "/20").Substring(0,10);
                        oInvoiceClient.collection = "0";
                        oInvoiceClient.day = dr["day"].ToString();
                        oInvoiceClient.type = dr["type"].ToString() == "1" ? "2" : "3";
                        oInvoiceClient.idDigital = dr["idBill"].ToString();
                        oInvoiceClient.idInvoice  = dr["invoice"].ToString();
                        oInvoiceClient.installation  = dr["installation"].ToString();

                        InvoicesList.Add(oInvoiceClient);
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

    }
}
