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
    public interface IRolesAsignadoServices
    {
        Response Add(RolesAsignado oRolesAsignado);
        Response Get();
        Response Update(RolesAsignado oRolesAsignado);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class RolesAsignadoServices : IRolesAsignadoServices
    {
        private readonly IConfiguration _configuration;

        public RolesAsignadoServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(RolesAsignado oRolesAsignado)
        {
            RolesAsignadoDataHelper _RolesAsignadoDataHelper = new RolesAsignadoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _RolesAsignadoDataHelper.Add(oRolesAsignado);
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
            RolesAsignadoDataHelper _RolesAsignadoDataHelper = new RolesAsignadoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _RolesAsignadoDataHelper.Delete(Id);
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
            RolesAsignadoDataHelper _RolesAsignadoDataHelper = new RolesAsignadoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _RolesAsignadoDataHelper.Get(Id);
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
            RolesAsignadoDataHelper _RolesAsignadoDataHelper = new RolesAsignadoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _RolesAsignadoDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(RolesAsignado oRolesAsignado)
        {
            RolesAsignadoDataHelper _RolesAsignadoDataHelper = new RolesAsignadoDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _RolesAsignadoDataHelper.Update(oRolesAsignado);
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
