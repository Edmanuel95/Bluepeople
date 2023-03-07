using api.grupokmm.flujos.Entities;
using api.grupokmm.flujos.Helpers.Data.Models;
using api.grupokmm.flujos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace api.grupokmm.flujos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposMovimientoBitacoraController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private TiposMovimientoBitacoraServices _tiposMovimientoBitacoraServices;

        public TiposMovimientoBitacoraController(TiposMovimientoBitacoraServices tiposMovimientoBitacoraServices, IConfiguration configuration)
        {
            _tiposMovimientoBitacoraServices = tiposMovimientoBitacoraServices;
            _configuration = configuration;
        }

        [HttpGet]
        [Consumes("application/json")]
        public IActionResult Get()
        {
            Response oResponse = _tiposMovimientoBitacoraServices.Get();

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        public IActionResult Get(int id)
        {
            Response oResponse = _tiposMovimientoBitacoraServices.Get(id);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpPost("New")]
        [Consumes("application/json")]
        public IActionResult New([FromBody] TiposMovimientoBitacora oTiposMovimientoBitacora)
        {
            Response oResponse = _tiposMovimientoBitacoraServices.Add(oTiposMovimientoBitacora);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }


        [HttpPost("Update")]
        [Consumes("application/json")]
        public IActionResult Update([FromBody] TiposMovimientoBitacora oTiposMovimientoBitacora)
        {
            Response oResponse = _tiposMovimientoBitacoraServices.Update(oTiposMovimientoBitacora);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpDelete("{id}")]
        [Consumes("application/json")]
        public IActionResult Delete(int id)
        {
            Response oResponse = _tiposMovimientoBitacoraServices.Delete(id);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }
    }
}
