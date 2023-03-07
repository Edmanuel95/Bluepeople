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
    public class RoleDataHelper
    {
        public SistemaFlujosContext _DbContext;
        public string message { get; set; }
        public bool status { get; set; }


        private string _flujos = string.Empty;
        private readonly IConfiguration _configuration;

        public RoleDataHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _flujos = configuration.GetConnectionString("flujos");

        }
        public RoleDataHelper(SistemaFlujosContext dbContext)
        {
            _DbContext = dbContext;
        }
        public RoleDataHelper()
        {
            _DbContext = new SistemaFlujosContext();
        }
        public Response Add(Role oRole)
        {
            Response oResponse = new Response();
            try
            {
                var resultAdd = _DbContext.Roles.Add(oRole);
                if (resultAdd != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = _DbContext.SaveChanges();
                }
                else
                {
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "";
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
                Role resultDelete = _DbContext.Roles.FirstOrDefault(x => x.IdRol == id);
                if (resultDelete != null)
                {
                    _DbContext.Remove(resultDelete);
                    _DbContext.SaveChanges();

                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = _DbContext.SaveChanges();
                }
                else
                {
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "No se elimino el Role";
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
                Role resultGet = _DbContext.Roles.FirstOrDefault(x => x.IdRol == id); ;

                if (resultGet != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = resultGet;
                }
                else
                {
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "No existe el Role";
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
                DataTable tb = this.get();

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
    

        public Response Update(Role oRole)
        {
            Response oResponse = new Response();
            try
            {
                var resultUpdate = _DbContext.Roles.Update(oRole);
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

        private DataTable get()
        {
            DataAccess db = new DataAccess();
            DataTable result = new DataTable();

            try
            {
                string[] strParms = null;
                DataSet ds = db.ExecuteSP("getRoles", strParms, _flujos);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    status = false;
                    message = string.Format("Error obtener los roles", ".");
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
