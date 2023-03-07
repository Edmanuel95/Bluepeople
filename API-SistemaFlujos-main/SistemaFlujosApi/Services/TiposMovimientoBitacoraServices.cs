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
    public interface ITiposMovimientoBitacoraServices
    {
        Response Add(TiposMovimientoBitacora oTiposMovimientoBitacora);
        Response Get();
        Response Update(TiposMovimientoBitacora oTiposMovimientoBitacora);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class TiposMovimientoBitacoraServices : ITiposMovimientoBitacoraServices
    {
        private readonly IConfiguration _configuration;

        public TiposMovimientoBitacoraServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(TiposMovimientoBitacora oTiposMovimientoBitacora)
        {
            TiposMovimientoBitacoraDataHelper _TiposMovimientoBitacoraDataHelper = new TiposMovimientoBitacoraDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _TiposMovimientoBitacoraDataHelper.Add(oTiposMovimientoBitacora);
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
            TiposMovimientoBitacoraDataHelper _TiposMovimientoBitacoraDataHelper = new TiposMovimientoBitacoraDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _TiposMovimientoBitacoraDataHelper.Delete(Id);
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
            TiposMovimientoBitacoraDataHelper _TiposMovimientoBitacoraDataHelper = new TiposMovimientoBitacoraDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _TiposMovimientoBitacoraDataHelper.Get(Id);
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
            TiposMovimientoBitacoraDataHelper _TiposMovimientoBitacoraDataHelper = new TiposMovimientoBitacoraDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _TiposMovimientoBitacoraDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(TiposMovimientoBitacora oTiposMovimientoBitacora)
        {
            TiposMovimientoBitacoraDataHelper _TiposMovimientoBitacoraDataHelper = new TiposMovimientoBitacoraDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _TiposMovimientoBitacoraDataHelper.Update(oTiposMovimientoBitacora);
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
