using api.grupokmm.flujos.Entities;
using api.grupokmm.flujos.Helpers;
using api.grupokmm.flujos.Helpers.Data;
using api.grupokmm.flujos.Helpers.Emun;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace api.grupokmm.flujos.Services
{
    
    public interface IBillServices { 
        Response getBills(Bills oBills);
        Response getClients( );
        Response getChannels();
        Response getBillsByCliente(Bills oBills);
    }


    public class BillServices : IBillServices
    {
        private readonly IConfiguration _configuration;
        public BillServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Response getChannels()
        {
            BillsDataHelper _billsDataHelper = new BillsDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = _billsDataHelper.Channels();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response getClients()
        {
            BillsDataHelper _billsDataHelper = new BillsDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = _billsDataHelper.Clients();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }
        public Response getSorters()
        {
            BillsDataHelper _billsDataHelper = new BillsDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = _billsDataHelper.Sorters();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }



        public Response getBillsByCliente(Bills oBills)
        {
            BillsDataHelper _billsDataHelper = new BillsDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = _billsDataHelper.BillsByCliente(oBills);
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;  
        }

        public Response getBills(Bills oBills)
        {
            BillsDataHelper _billsDataHelper = new BillsDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = _billsDataHelper.Bills(oBills);
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;


        }
    }
}
