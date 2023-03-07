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
    public interface IClasificacionesServices
    {
        Response Add(Clasificacione clasificacion);
        Response Get();
        Response Update(Clasificacione clasificacion);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class ClasificacionesServices : IClasificacionesServices
    {
        private readonly IConfiguration _configuration;

        public ClasificacionesServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(Clasificacione clasificacion)
        {
            ClasificacionDataHelper clasificacionDataHelper = new ClasificacionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = clasificacionDataHelper.Add(clasificacion);
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
            ClasificacionDataHelper clasificacionDataHelper = new ClasificacionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = clasificacionDataHelper.Delete(Id);
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
            ClasificacionDataHelper clasificacionDataHelper = new ClasificacionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = clasificacionDataHelper.Get(Id);
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
            ClasificacionDataHelper clasificacionDataHelper = new ClasificacionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = clasificacionDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(Clasificacione clasificacion)
        {
            ClasificacionDataHelper clasificacionDataHelper = new ClasificacionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = clasificacionDataHelper.Update(clasificacion);
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
