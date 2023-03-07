using api.grupokmm.flujos.Services;
using api.grupokmm.flujos.Entities;
using api.grupokmm.flujos.Helpers.Emun;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using api.grupokmm.flujos.Helpers.Data.Models;

namespace api.grupokmm.flujos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CobradoRealController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private CobradoRealServices _cobradoRealServices;

        public CobradoRealController(CobradoRealServices cobradoRealServices, IConfiguration configuration)
        {
            _cobradoRealServices = cobradoRealServices;
            _configuration = configuration;
        }

        [HttpGet]
        [Consumes("application/json")]
        public IActionResult Get()
        {
            Response oResponse = _cobradoRealServices.Get();

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        public IActionResult Get(int id)
        {
            Response oResponse = _cobradoRealServices.Get(id);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpPost("New")]
        [Consumes("application/json")]
        public IActionResult New([FromBody] requestNew oCobradoReal)
        {
            Response oResponse = _cobradoRealServices.Add(oCobradoReal);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }


        [HttpPost("Update")]
        [Consumes("application/json")]
        public IActionResult Update([FromBody] CobradoReal oCobradoReal)
        {
            Response oResponse = _cobradoRealServices.Update(oCobradoReal);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpPost("CobradoReal")]
        [Consumes("application/json")]
        public IActionResult CobradoReal([FromBody] requestCobradoReal oCobradoReal)
        {
            Response oResponse = _cobradoRealServices.Get(oCobradoReal);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }


        [HttpPost("Search")]
        [Consumes("application/json")]
        public IActionResult Search([FromBody] requestCobradoReal oCobradoReal)
        {
            Response oResponse = _cobradoRealServices.Search(oCobradoReal);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpDelete("{id}")]
        [Consumes("application/json")]
        public IActionResult Delete(int id)
        {
            Response oResponse = _cobradoRealServices.Delete(id);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }
    }
}