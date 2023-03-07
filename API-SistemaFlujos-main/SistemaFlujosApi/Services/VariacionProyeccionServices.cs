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
    public interface IVariacionProyeccionServices
    {
        Response Add(VariacionProyeccion oVariacionProyeccion);
        Response Get();
        Response Update(VariacionProyeccion oVariacionProyeccion);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class VariacionProyeccionServices : IVariacionProyeccionServices
    {
        private readonly IConfiguration _configuration;

        public VariacionProyeccionServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(VariacionProyeccion oVariacionProyeccion)
        {
            VariacionProyeccionDataHelper _VariacionProyeccionDataHelper = new VariacionProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _VariacionProyeccionDataHelper.Add(oVariacionProyeccion);
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
            VariacionProyeccionDataHelper _VariacionProyeccionDataHelper = new VariacionProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _VariacionProyeccionDataHelper.Delete(Id);
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
            VariacionProyeccionDataHelper _VariacionProyeccionDataHelper = new VariacionProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _VariacionProyeccionDataHelper.Get(Id);
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
            VariacionProyeccionDataHelper _VariacionProyeccionDataHelper = new VariacionProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _VariacionProyeccionDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(VariacionProyeccion oVariacionProyeccion)
        {
            VariacionProyeccionDataHelper _VariacionProyeccionDataHelper = new VariacionProyeccionDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _VariacionProyeccionDataHelper.Update(oVariacionProyeccion);
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
