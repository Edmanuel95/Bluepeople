using api.grupokmm.flujos.Entities;
using api.grupokmm.flujos.Helpers.Data.Models;
using api.grupokmm.flujos.Helpers.Emun;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace api.grupokmm.flujos.Helpers.Data
{
    public class UsuarioDataHelper
    {
        public SistemaFlujosContext _DbContext;

        public string message { get; set; }
        public bool status { get; set; }

        private string _flujos = string.Empty;
        private readonly IConfiguration _configuration;

        public UsuarioDataHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _flujos = configuration.GetConnectionString("flujos");

        }
        public UsuarioDataHelper(SistemaFlujosContext dbContext)
        {
            _DbContext = dbContext;
        }
        public UsuarioDataHelper()
        {
            _DbContext = new SistemaFlujosContext();
        }
        public Response Add(Users oUsuario)
        {
            Response oResponse = new Response();
            try
            {
                DataTable tb = add(oUsuario);

                if (tb != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = tb.Rows[0][0].ToString();
                }
                else
                {
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "No existen protecciones";
                }
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }

            return oResponse;
        }

        public Response Delete(int id)
        {
            Response oResponse = new Response();
            try
            {
                DataTable tb = delete(id.ToString());

                if (tb != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = tb.Rows[0][0].ToString();
                }
                else
                {
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "No existen protecciones";
                }
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }

            return oResponse;
        }

        public Response Get(int id)
        {

            Response oResponse = new Response();
            try
            {
                DataTable tb = get(id);

                if (tb != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = tb.Rows[0][0].ToString();
                }
                else
                {
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "No existen protecciones";
                }
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
            Response oResponse = new Response();
            try
            {
                DataTable tb = get();

                if (tb != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = tb.Rows[0][0].ToString();
                }
                else
                {
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "No existen protecciones";
                }
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }

            return oResponse;
        }

        public Response Update(Usuario oUsuario)
        {
            Response oResponse = new Response();
            try
            {
                var resultUpdate = _DbContext.Usuarios.Update(oUsuario);
                if (resultUpdate != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = _DbContext.SaveChanges();
                }
                else
                {
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "Update no realizado";
                }
            }
            catch (Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();
            }
            return oResponse;
        }

        private DataTable get(int idUser)
        {
            DataAccess db = new DataAccess();
            DataTable result = new DataTable();

            try
            {
                string[] strParms = new string[] { idUser.ToString() };
                DataSet ds = db.ExecuteSP("getUser", strParms, _flujos);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    status = false;
                    message = string.Format("Error obtener el usuario{0}", idUser);
                }
                else
                {
                    status = true;
                    message = "Ok";
                    result = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }
        private DataTable get( )
        {
            DataAccess db = new DataAccess();
            DataTable result = new DataTable();

            try
            {
                string[] strParms = null;
                DataSet ds = db.ExecuteSP("getUsers", strParms, _flujos);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    status = false;
                    message = string.Format("Error ontener los usuarios");
                }
                else
                {
                    status = true;
                    message = "Ok";
                    result = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }


        private DataTable add(Users oUsers)
        {
            DataAccess db = new DataAccess();
            DataTable result = new DataTable();

            try
            {
                string[] strParms = new string[] { oUsers.iduser, oUsers.name, oUsers.login, oUsers.password, oUsers.idrol.ToString(), oUsers.email, oUsers.status.ToString()};
                DataSet ds = db.ExecuteSP("setUsers", strParms, _flujos);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    status = false;
                    message = string.Format("Error al crear e usuario {0}", oUsers.name );
                }
                else
                {
                    status = true;
                    message = "Ok";
                    result = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        private DataTable delete(string idUser)
        {
            DataAccess db = new DataAccess();
            DataTable result = new DataTable();

            try
            {
                string[] strParms = new string[] { idUser };
                DataSet ds = db.ExecuteSP("delUsers", strParms, _flujos);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    status = false;
                    message = string.Format("Error al eleminar el usuario", idUser);
                }
                else
                {
                    status = true;
                    message = "Ok";
                    result = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

    }
}
