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
    public interface IDetalleProyeccionServices
    {
        Response Add(Details[] oDetalleProyeccion);
        Response Get();
        Response Update(DetalleProyeccion oDetalleProyeccion);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class DetalleProyeccionServices : IDetalleProyeccionServices
    {
        private readonly IConfiguration _configuration;

        public DetalleProyeccionServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(Details[] oDetalleProyeccion)
        {
            DetalleProyeccionDataHelper _DetalleProyeccionDataHelper = new DetalleProyeccionDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = _DetalleProyeccionDataHelper.Add(oDetalleProyeccion);
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
            DetalleProyeccionDataHelper _DetalleProyeccionDataHelper = new DetalleProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _DetalleProyeccionDataHelper.Delete(Id);
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
            DetalleProyeccionDataHelper _DetalleProyeccionDataHelper = new DetalleProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _DetalleProyeccionDataHelper.Get(Id);
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
            DetalleProyeccionDataHelper _DetalleProyeccionDataHelper = new DetalleProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _DetalleProyeccionDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(DetalleProyeccion oDetalleProyeccion)
        {
            DetalleProyeccionDataHelper _DetalleProyeccionDataHelper = new DetalleProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _DetalleProyeccionDataHelper.Update(oDetalleProyeccion);
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
