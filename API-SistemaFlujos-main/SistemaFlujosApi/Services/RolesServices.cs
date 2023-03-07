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
    public interface IRolesServices
    {
        Response Add(Role oRole);
        Response Get();
        Response Update(Role oRole);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class RolesServices : IRolesServices
    {
        private readonly IConfiguration _configuration;

        public RolesServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(Role oRole)
        {
            RoleDataHelper _RoleDataHelper = new RoleDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _RoleDataHelper.Add(oRole);
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
            RoleDataHelper _RoleDataHelper = new RoleDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _RoleDataHelper.Delete(Id);
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
            RoleDataHelper _RoleDataHelper = new RoleDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _RoleDataHelper.Get(Id);
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
            RoleDataHelper _RoleDataHelper = new RoleDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = _RoleDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(Role oRole)
        {
            RoleDataHelper _RoleDataHelper = new RoleDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = _RoleDataHelper.Update(oRole);
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
