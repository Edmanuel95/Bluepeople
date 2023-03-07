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
    public interface IProyeccionServices
    {
        Response Add(Projection oProyeccion);
        Response Get();
        Response Update(Proyeccion oProyeccion);
        Response Delete(int Id);
        Response Get(int Id);
        Response Dashboard(int Id);
    }

    public class ProyeccionServices : IProyeccionServices
    {
        private readonly IConfiguration _configuration;

        public ProyeccionServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Response Dashboard(int Id)
        {
            ProyeccionDataHelper _ProyeccionDataHelper = new ProyeccionDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = _ProyeccionDataHelper.Dashboard(Id);
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
            ProyeccionDataHelper _ProyeccionDataHelper = new ProyeccionDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = _ProyeccionDataHelper.Add(oProyeccion);
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
            ProyeccionDataHelper _ProyeccionDataHelper = new ProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _ProyeccionDataHelper.Delete(Id);
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
            ProyeccionDataHelper _ProyeccionDataHelper = new ProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _ProyeccionDataHelper.Get(Id);
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
            ProyeccionDataHelper _ProyeccionDataHelper = new ProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _ProyeccionDataHelper.Get();
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
            ProyeccionDataHelper _ProyeccionDataHelper = new ProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _ProyeccionDataHelper.Update(oProyeccion);
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        
         public Response UpdatePayments( )
        {
            ProyeccionDataHelper _ProyeccionDataHelper = new ProyeccionDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = _ProyeccionDataHelper.UpdatePayments();
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
