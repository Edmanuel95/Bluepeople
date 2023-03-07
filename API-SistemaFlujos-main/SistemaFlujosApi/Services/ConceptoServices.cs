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
    public interface IConceptoServices
    {
        Response Add(Concepto oConcepto);
        Response Get();
        Response Update(Concepto oConcepto);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class ConceptoServices : IConceptoServices
    {
        private readonly IConfiguration _configuration;

        public ConceptoServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(Concepto oConcepto)
        {
            ConceptoDataHelper _ConceptoDataHelper = new ConceptoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _ConceptoDataHelper.Add(oConcepto);
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
            ConceptoDataHelper _ConceptoDataHelper = new ConceptoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _ConceptoDataHelper.Delete(Id);
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
            ConceptoDataHelper _ConceptoDataHelper = new ConceptoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _ConceptoDataHelper.Get(Id);
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
            ConceptoDataHelper _ConceptoDataHelper = new ConceptoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _ConceptoDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(Concepto oConcepto)
        {
            ConceptoDataHelper _ConceptoDataHelper = new ConceptoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _ConceptoDataHelper.Update(oConcepto);
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
