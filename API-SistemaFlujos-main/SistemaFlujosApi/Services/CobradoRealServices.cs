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
    public interface ICobradoRealServices
    {
        Response Add(requestNew oCobradoReal);
        Response Get();
        Response Update(CobradoReal oCobradoReal);
        Response Delete(int Id);
        Response Get(int Id);
        Response Get(requestCobradoReal oCobradoReal);
        Response Search(requestCobradoReal oCobradoReal);
    }


    public class CobradoRealServices : ICobradoRealServices
    {
        private readonly IConfiguration _configuration;

        public CobradoRealServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(requestNew oCobradoReal)
        {
            CobradoRealDataHelper _CobradoRealDataHelper = new CobradoRealDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = _CobradoRealDataHelper.Add(oCobradoReal);
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
            CobradoRealDataHelper _CobradoRealDataHelper = new CobradoRealDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _CobradoRealDataHelper.Delete(Id);
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
            CobradoRealDataHelper _CobradoRealDataHelper = new CobradoRealDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _CobradoRealDataHelper.Get(Id);
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }


        public Response Get(requestCobradoReal oCobradoReal)
        {
            CobradoRealDataHelper _CobradoRealDataHelper = new CobradoRealDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = _CobradoRealDataHelper.Get(oCobradoReal);
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Search(requestCobradoReal oCobradoReal)
        {
            CobradoRealDataHelper _CobradoRealDataHelper = new CobradoRealDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = _CobradoRealDataHelper.GetSearch(oCobradoReal);
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
            CobradoRealDataHelper _CobradoRealDataHelper = new CobradoRealDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _CobradoRealDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(CobradoReal oCobradoReal)
        {
            CobradoRealDataHelper _CobradoRealDataHelper = new CobradoRealDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _CobradoRealDataHelper.Update(oCobradoReal);
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
