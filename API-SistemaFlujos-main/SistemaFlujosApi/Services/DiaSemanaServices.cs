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
   
    public interface IDiaSemanaServices
    {
        Response Add(DiaSemana oDiaSemana);
        Response Get();
        Response Update(DiaSemana oDiaSemana);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class DiaSemanaServices : IDiaSemanaServices
    {
        private readonly IConfiguration _configuration;


        public DiaSemanaServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(DiaSemana oDiaSemana)
        {
            DiaSemanaDataHelper _DiaSemanaDataHelper = new DiaSemanaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _DiaSemanaDataHelper.Add(oDiaSemana);
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
            DiaSemanaDataHelper _DiaSemanaDataHelper = new DiaSemanaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _DiaSemanaDataHelper.Delete(Id);
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
            DiaSemanaDataHelper _DiaSemanaDataHelper = new DiaSemanaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _DiaSemanaDataHelper.Get(Id);
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
            DiaSemanaDataHelper _DiaSemanaDataHelper = new DiaSemanaDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = _DiaSemanaDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(DiaSemana oDiaSemana)
        {
            DiaSemanaDataHelper _DiaSemanaDataHelper = new DiaSemanaDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _DiaSemanaDataHelper.Update(oDiaSemana);
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
