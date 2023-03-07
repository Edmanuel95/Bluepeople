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
    public interface IBitacorasServices {
        Response Add(Bitacora oBitacora);
        Response Get();
        Response Update(Bitacora oBitacora);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class BitacorasServices : IBitacorasServices
    {
        private readonly IConfiguration _configuration;

        public BitacorasServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(Bitacora oBitacora)
        {
            BitacoraDataHelper _bitacoraDataHelper = new BitacoraDataHelper();
             Response oResponse = new Response();
            try
            {
                oResponse = _bitacoraDataHelper.Add(oBitacora);
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
            BitacoraDataHelper _bitacoraDataHelper = new BitacoraDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _bitacoraDataHelper.Delete(Id);
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
            BitacoraDataHelper _bitacoraDataHelper = new BitacoraDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _bitacoraDataHelper.Get(Id);
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
            BitacoraDataHelper _bitacoraDataHelper = new BitacoraDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _bitacoraDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(Bitacora oBitacora)
        {
            BitacoraDataHelper _bitacoraDataHelper = new BitacoraDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _bitacoraDataHelper.Update(oBitacora);
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
