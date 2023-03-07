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
    public class DiaSemanaDataHelper
    {
        public SistemaFlujosContext _DbContext;
        public string message { get; set; }
        public bool status { get; set; }


        private string _flujos = string.Empty;

        private readonly IConfiguration _configuration;
        public DiaSemanaDataHelper(SistemaFlujosContext dbContext)
        {
            _DbContext = dbContext;
        }

        public DiaSemanaDataHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _flujos = configuration.GetConnectionString("flujos");

        }
        public DiaSemanaDataHelper()
        {
            _DbContext = new SistemaFlujosContext();
        }
        public Response Add(DiaSemana oDiaSemana)
        {
            Response oResponse = new Response();
            try
            {
                var resultAdd = _DbContext.DiaSemanas.Add(oDiaSemana);
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
                DiaSemana resultDelete = _DbContext.DiaSemanas.FirstOrDefault(x => x.IdDiaSemana == id);
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
                    oResponse.result = "No se elimino el DiaSemana";
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
                DiaSemana resultGet = _DbContext.DiaSemanas.FirstOrDefault(x => x.IdDiaSemana == id); ;

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
                    oResponse.result = "No existe el DiaSemana";
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
                DataTable tb = getDays();

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

        public Response Update(DiaSemana oDiaSemana)
        {
            Response oResponse = new Response();
            try
            {
                var resultUpdate = _DbContext.DiaSemanas.Update(oDiaSemana);
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


        public DataTable getDays()
        {
            DataAccess db = new DataAccess();
            DataTable result = new DataTable();

            try
            {
                string[] strParms = null;
                DataSet ds = db.ExecuteSP("getDays", strParms, _flujos);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    status = false;
                    message = string.Format("Error al obtener datos {0}, {1}", "getChannels");
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
