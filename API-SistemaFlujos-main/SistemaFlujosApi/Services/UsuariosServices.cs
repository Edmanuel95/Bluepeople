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
    public interface IUsuariosServices {
        Response Add(Users usuario);
        Response Get();
        Response Update(Usuario usuario);
        Response Delete(int Id);
        Response Get(int Id);
    }

    public class UsuariosServices : IUsuariosServices
    {
        private readonly IConfiguration _configuration;

        public UsuariosServices(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Add(Users usuario)
        {

            UsuarioDataHelper usuarioDataHelper = new UsuarioDataHelper(_configuration);
             Response oResponse = new Response();
            try
            {
                oResponse = usuarioDataHelper.Add(usuario);
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
            UsuarioDataHelper usuarioDataHelper = new UsuarioDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = usuarioDataHelper.Delete(Id);
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
            UsuarioDataHelper usuarioDataHelper = new UsuarioDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = usuarioDataHelper.Get(Id);
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
            UsuarioDataHelper usuarioDataHelper = new UsuarioDataHelper(_configuration);
            Response oResponse = new Response();
            try
            {
                oResponse = usuarioDataHelper.Get();
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        public Response Update(Usuario usuario)
        {
            UsuarioDataHelper usuarioDataHelper = new UsuarioDataHelper();
            Response oResponse = new Response();
            try
            {
                oResponse = usuarioDataHelper.Update(usuario);
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
