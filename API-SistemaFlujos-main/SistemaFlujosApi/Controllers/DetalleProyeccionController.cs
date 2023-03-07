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
    public class DetalleProyeccionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private DetalleProyeccionServices _detalleProyeccionServices;

        public DetalleProyeccionController(DetalleProyeccionServices detalleProyeccionServices, IConfiguration configuration)
        {
            _detalleProyeccionServices = detalleProyeccionServices;
            _configuration = configuration;
        }

        [HttpGet]
        [Consumes("application/json")]
        public IActionResult Get()
        {
            Response oResponse = _detalleProyeccionServices.Get();

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        public IActionResult Get(int id)
        {
            Response oResponse = _detalleProyeccionServices.Get(id);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpPost("New")]
        [Consumes("application/json")]
        public IActionResult New([FromBody] Details[] oDetalleProyeccion)
        {
            Response oResponse = _detalleProyeccionServices.Add(oDetalleProyeccion);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }


        [HttpPut("Update")]
        [Consumes("application/json")]
        public IActionResult Update(int id, [FromBody] DetalleProyeccion oDetalleProyeccion)
        {
            oDetalleProyeccion.IdDetalleProyeccion = id; //ID del detalle de Proyeccion que se actualizara
            Response oResponse = _detalleProyeccionServices.Update(oDetalleProyeccion);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpDelete("{id}")]
        [Consumes("application/json")]
        public IActionResult Delete(int id)
        {
            Response oResponse = _detalleProyeccionServices.Delete(id);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }
    }
}
