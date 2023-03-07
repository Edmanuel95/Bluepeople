using api.grupokmm.flujos.Entities;
using api.grupokmm.flujos.Helpers.Data.Models;
using api.grupokmm.flujos.Helpers.Emun;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api.grupokmm.flujos.Helpers.Data
{
    public class ConceptoDataHelper
    {
        public SistemaFlujosContext _DbContext;
        public ConceptoDataHelper(SistemaFlujosContext dbContext)
        {
            _DbContext = dbContext;
        }
        public ConceptoDataHelper()
        {
            _DbContext = new SistemaFlujosContext();
        }
        public Response Add(Concepto oConcepto)
        {
            Response oResponse = new Response();
            try
            {
                var resultAdd = _DbContext.Conceptos.Add(oConcepto);
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
                var concepto = _DbContext.Conceptos.FirstOrDefault(x => x.IdConcepto  == id);
                if (concepto != null)
                {
                    _DbContext.Remove(concepto);
                    _DbContext.SaveChanges();

                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = _DbContext.SaveChanges();
                }
                else
                {
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "No se elimino el concepto";
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
                Concepto concepto = _DbContext.Conceptos.FirstOrDefault(x => x.IdConcepto == id); ;

                if (concepto != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = concepto;
                }
                else
                {
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "No existe el concepto";
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
                List<Concepto> conceptos = _DbContext.Conceptos.ToList();

                if (conceptos != null)
                {
                    oResponse.code = (int)StatusResponse.OK;
                    oResponse.message = StatusResponse.OK.ToString();
                    oResponse.result = conceptos;
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

        public Response Update(Concepto oConcepto)
        {
            Response oResponse = new Response();
            try
            {
                var resultUpdate = _DbContext.Conceptos.Update(oConcepto);
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