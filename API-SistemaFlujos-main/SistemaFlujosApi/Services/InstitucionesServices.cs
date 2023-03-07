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
    public interface IInstitucionesServices
    {
        Response Add(Institucione oInstitucion);
        Response Get();
        Response Update(Institucione oInstitucion);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class InstitucionesServices : IInstitucionesServices
    {
        private readonly IConfiguration _configuration;

        public InstitucionesServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(Institucione oInstituciones)
        {
            InstitucionesDataHelper _InstitucionesDataHelper = new InstitucionesDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _InstitucionesDataHelper.Add(oInstituciones);
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
            InstitucionesDataHelper _InstitucionesDataHelper = new InstitucionesDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _InstitucionesDataHelper.Delete(Id);
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
            InstitucionesDataHelper _InstitucionesDataHelper = new InstitucionesDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _InstitucionesDataHelper.Get(Id);
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
            InstitucionesDataHelper _InstitucionesDataHelper = new InstitucionesDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _InstitucionesDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(Institucione oInstituciones)
        {
            InstitucionesDataHelper _InstitucionesDataHelper = new InstitucionesDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _InstitucionesDataHelper.Update(oInstituciones);
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
