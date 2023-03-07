using api.grupokmm.flujos.Entities;
using api.grupokmm.flujos.Helpers.Data.Models;
using api.grupokmm.flujos.Helpers.Emun;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api.grupokmm.flujos.Helpers.Data
{
    public class RolesAsignadoDataHelper
    {
        public SistemaFlujosContext _DbContext;
        public RolesAsignadoDataHelper(SistemaFlujosContext dbContext)
        {
            _DbContext = dbContext;
        }
        public RolesAsignadoDataHelper()
        {
            _DbContext = new SistemaFlujosContext();
        }
        public Response Add(RolesAsignado oRolesAsignado)
        {
            Response oResponse = new Response();
            try
            {
                var resultAdd = _DbContext.RolesAsignados.Add(oRolesAsignado);
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
                RolesAsignado resultDelete = _DbContext.RolesAsignados.FirstOrDefault(x => x.RolId  == id);
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
                    oResponse.result = "No se elimino el RolesAsignado";
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
                RolesAsignado resultGet = _DbContext.RolesAsignados.FirstOrDefault(x => x.RolId == id); ;

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
                    oResponse.result = "No existe el RolesAsignado";
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
                List<RolesAsignado> resultGet = _DbContext.RolesAsignados.ToList();

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

        public Response Update(RolesAsignado oRolesAsignado)
        {
            Response oResponse = new Response();
            try
            {
                var resultUpdate = _DbContext.RolesAsignados.Update(oRolesAsignado);
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
    }
}
