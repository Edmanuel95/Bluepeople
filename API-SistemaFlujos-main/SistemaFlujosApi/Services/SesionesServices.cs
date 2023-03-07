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
    public interface ISesionesServices
    {
        Response Add(Sesione oSesione);
        Response Get();
        Response Update(Sesione oSesione);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class SesionesServices : ISesionesServices
    {
        private readonly IConfiguration _configuration;

        public SesionesServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(Sesione oSesione)
        {
            SesionesDataHelper _SesionesDataHelper = new SesionesDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _SesionesDataHelper.Add(oSesione);
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
            SesionesDataHelper _SesionesDataHelper = new SesionesDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _SesionesDataHelper.Delete(Id);
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
            SesionesDataHelper _SesionesDataHelper = new SesionesDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _SesionesDataHelper.Get(Id);
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
            SesionesDataHelper _SesionesDataHelper = new SesionesDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _SesionesDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(Sesione oSesione)
        {
            SesionesDataHelper _SesionesDataHelper = new SesionesDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _SesionesDataHelper.Update(oSesione);
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
