using api.grupokmm.flujos.Entities;
using api.grupokmm.flujos.Helpers;
using api.grupokmm.flujos.Helpers.Data;
using api.grupokmm.flujos.Helpers.Data.Models;
using api.grupokmm.flujos.Helpers.Emun;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace api.grupokmm.flujos.Services
{
    public interface ITiposLineaServices
    {
        Response Add(TiposLinea oTiposLinea);
        Response Get();
        Response Update(TiposLinea oTiposLinea);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class TiposLineaServices : ITiposLineaServices
    {
        private readonly IConfiguration _configuration;

        public TiposLineaServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(TiposLinea oTiposLinea)
        {
            TiposLineaDataHelper _TiposLineaDataHelper = new TiposLineaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _TiposLineaDataHelper.Add(oTiposLinea);
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Delete(int Id)
        {
            TiposLineaDataHelper _TiposLineaDataHelper = new TiposLineaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _TiposLineaDataHelper.Delete(Id);
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Get(int Id)
        {
            TiposLineaDataHelper _TiposLineaDataHelper = new TiposLineaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _TiposLineaDataHelper.Get(Id);
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
            TiposLineaDataHelper _TiposLineaDataHelper = new TiposLineaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _TiposLineaDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(TiposLinea oTiposLinea)
        {
            TiposLineaDataHelper _TiposLineaDataHelper = new TiposLineaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _TiposLineaDataHelper.Update(oTiposLinea);
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
