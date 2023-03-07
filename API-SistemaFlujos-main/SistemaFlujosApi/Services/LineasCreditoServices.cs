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
    public interface ILineasCreditoServices
    {
        Response Add(LineasCredito oLineasCredito);
        Response Get();
        Response Update(LineasCredito oLineasCredito);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class LineasCreditoServices : ILineasCreditoServices
    {
        private readonly IConfiguration _configuration;

        public LineasCreditoServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(LineasCredito oLineasCredito)
        {
            LineasCreditoDataHelper _LineasCreditoDataHelper = new LineasCreditoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _LineasCreditoDataHelper.Add(oLineasCredito);
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
            LineasCreditoDataHelper _LineasCreditoDataHelper = new LineasCreditoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _LineasCreditoDataHelper.Delete(Id);
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
            LineasCreditoDataHelper _LineasCreditoDataHelper = new LineasCreditoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _LineasCreditoDataHelper.Get(Id);
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
            LineasCreditoDataHelper _LineasCreditoDataHelper = new LineasCreditoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _LineasCreditoDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(LineasCredito oLineasCredito)
        {
            LineasCreditoDataHelper _LineasCreditoDataHelper = new LineasCreditoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _LineasCreditoDataHelper.Update(oLineasCredito);
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
