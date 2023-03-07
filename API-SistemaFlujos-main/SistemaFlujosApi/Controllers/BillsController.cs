using api.grupokmm.flujos.Entities;
using api.grupokmm.flujos.Helpers.Emun;
using api.grupokmm.flujos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.grupokmm.flujos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private BillServices _billServices;


        public BillsController(BillServices billServices, IConfiguration configuration)
        {
            _billServices = billServices;
            _configuration = configuration;
        }

        [HttpPost("Bill")]
        [Consumes("application/json")]
        public IActionResult Bill([FromBody] Bills oBills)
        {
            Response oResponse = oResponse = _billServices.getBills(oBills);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);
        }


        [HttpPost("BillByClient")]
        [Consumes("application/json")]
        public IActionResult BillByClient([FromBody] Bills oBills)
        {
            Response oResponse = oResponse = _billServices.getBillsByCliente(oBills);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);
        }



        [HttpGet("getClients")]
        [Consumes("application/json")]
        public IActionResult getClients()
        {
            Response oResponse = new Response();

            try
            {

                oResponse = _billServices.getClients ();

                if (oResponse == null)
                {
                    oResponse = new Response();
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "Company or user_id are incorrect";
                }
            }
            catch (System.Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();

            }


            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);
        }

        [HttpGet("getChannels")]
        [Consumes("application/json")]
        public IActionResult getChannels()
        {
            Response oResponse = new Response();

            try
            {

                oResponse = _billServices.getChannels ();

                if (oResponse == null)
                {
                    oResponse = new Response();
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "Company or user_id are incorrect";
                }
            }
            catch (System.Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();

            }


            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);
        }

        [HttpGet("getSorter")]
        [Consumes("application/json")]
        public IActionResult getSorter()
        {
            Response oResponse = new Response();

            try
            {

                oResponse = _billServices.getSorters();

                if (oResponse == null)
                {
                    oResponse = new Response();
                    oResponse.code = (int)StatusResponse.Warning;
                    oResponse.message = StatusResponse.Warning.ToString();
                    oResponse.result = "Company or user_id are incorrect";
                }
            }
            catch (System.Exception ex)
            {
                oResponse.code = (int)StatusResponse.Error;
                oResponse.message = StatusResponse.Error.ToString();
                oResponse.result = ex.Message.ToString();

            }


            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);
        }
    }
}
