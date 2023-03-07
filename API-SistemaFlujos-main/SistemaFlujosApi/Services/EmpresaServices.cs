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
    public interface IEmpresaServices
    {
        Response Add(Empresa oEmpresa);
        Response Get();
        Response Update(Empresa oEmpresa);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class EmpresaServices : IEmpresaServices
    {
        private readonly IConfiguration _configuration;

        public EmpresaServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(Empresa oEmpresa)
        {
            EmpresaDataHelper _EmpresaDataHelper = new EmpresaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _EmpresaDataHelper.Add(oEmpresa);
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
            EmpresaDataHelper _EmpresaDataHelper = new EmpresaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _EmpresaDataHelper.Delete(Id);
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
            EmpresaDataHelper _EmpresaDataHelper = new EmpresaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _EmpresaDataHelper.Get(Id);
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
            EmpresaDataHelper _EmpresaDataHelper = new EmpresaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _EmpresaDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(Empresa oEmpresa)
        {
            EmpresaDataHelper _EmpresaDataHelper = new EmpresaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _EmpresaDataHelper.Update(oEmpresa);
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
