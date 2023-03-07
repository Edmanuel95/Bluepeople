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
    public interface IDepartamentoServices
    {
        Response Add(Departamento oDepartamento);
        Response Get();
        Response Update(Departamento oDepartamento);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class DepartamentoServices : IDepartamentoServices
    {
        private readonly IConfiguration _configuration;

        public DepartamentoServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(Departamento oDepartamento)
        {
            DepartamentoDataHelper _DepartamentoDataHelper = new DepartamentoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _DepartamentoDataHelper.Add(oDepartamento);
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
            DepartamentoDataHelper _DepartamentoDataHelper = new DepartamentoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _DepartamentoDataHelper.Delete(Id);
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
            DepartamentoDataHelper _DepartamentoDataHelper = new DepartamentoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _DepartamentoDataHelper.Get(Id);
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
            DepartamentoDataHelper _DepartamentoDataHelper = new DepartamentoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _DepartamentoDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(Departamento oDepartamento)
        {
            DepartamentoDataHelper _DepartamentoDataHelper = new DepartamentoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _DepartamentoDataHelper.Update(oDepartamento);
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
