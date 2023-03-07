using api.grupokmm.flujos.Entities;
using api.grupokmm.flujos.Helpers;
using api.grupokmm.flujos.Helpers.Data;
using api.grupokmm.flujos.Helpers.Data.Models;
using api.grupokmm.flujos.Helpers.Emun;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;

namespace api.grupokmm.flujos.Services
{
    public interface ITipoProyeccionServices
    {
        Response Add(TipoProyeccion oTipoProyeccion);
        Response Get();
        Response Update(TipoProyeccion oTipoProyeccion);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class TipoProyeccionServices : ITipoProyeccionServices
    {
        private readonly IConfiguration _configuration;

        public TipoProyeccionServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(TipoProyeccion oTipoProyeccion)
        {
            TipoProyeccionDataHelper _TipoProyeccionDataHelper = new TipoProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _TipoProyeccionDataHelper.Add(oTipoProyeccion);
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
            TipoProyeccionDataHelper _TipoProyeccionDataHelper = new TipoProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _TipoProyeccionDataHelper.Delete(Id);
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
            TipoProyeccionDataHelper _TipoProyeccionDataHelper = new TipoProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _TipoProyeccionDataHelper.Get(Id);
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
            TipoProyeccionDataHelper _TipoProyeccionDataHelper = new TipoProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _TipoProyeccionDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(TipoProyeccion oTipoProyeccion)
        {
            TipoProyeccionDataHelper _TipoProyeccionDataHelper = new TipoProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _TipoProyeccionDataHelper.Update(oTipoProyeccion);
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
