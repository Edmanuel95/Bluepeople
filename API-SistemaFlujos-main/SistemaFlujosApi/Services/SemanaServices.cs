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
    public interface ISemanaServices
    {
        Response Add(Semana oSemana);
        Response Get();
        Response Update(Semana oSemana);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class SemanaServices : ISemanaServices
    {
        private readonly IConfiguration _configuration;

        public SemanaServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(Semana oSemana)
        {
            SemanaDataHelper _SemanaDataHelper = new SemanaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _SemanaDataHelper.Add(oSemana);
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
            SemanaDataHelper _SemanaDataHelper = new SemanaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _SemanaDataHelper.Delete(Id);
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
            SemanaDataHelper _SemanaDataHelper = new SemanaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _SemanaDataHelper.Get(Id);
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response GetSearch()
        {
            SemanaDataHelper _SemanaDataHelper = new SemanaDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = _SemanaDataHelper.GetSearch();
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
            SemanaDataHelper _SemanaDataHelper = new SemanaDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = _SemanaDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(Semana oSemana)
        {
            SemanaDataHelper _SemanaDataHelper = new SemanaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _SemanaDataHelper.Update(oSemana);
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
