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
    public class ProyeccionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private ProyeccionServices _proyeccionServices;

        public ProyeccionController(ProyeccionServices proyeccionServices, IConfiguration configuration)
        {
            _proyeccionServices = proyeccionServices;
            _configuration = configuration;
        }

        [HttpGet]
        [Consumes("application/json")]
        public IActionResult Get()
        {
            Response oResponse = _proyeccionServices.Get();

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        public IActionResult Get(int id)
        {
            Response oResponse = _proyeccionServices.Get(id);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpPost("New")]
        [Consumes("application/json")]
        public IActionResult New([FromBody] Projection oProyeccion)
        {
            Response oResponse = _proyeccionServices.Add(oProyeccion);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }
        

       [HttpGet("Dashboard/{Id}")]
        [Consumes("application/json")]
        public IActionResult Dashboard(int Id)
        {
            Response oResponse = _proyeccionServices.Dashboard(Id);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpGet("UpdatePayments")]
        [Consumes("application/json")]
        public IActionResult UpdatePayments()
        {
            Response oResponse = _proyeccionServices.UpdatePayments();

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }


        [HttpPost("Update")]
        [Consumes("application/json")]
        public IActionResult Update([FromBody] Proyeccion oProyeccion)
        {
            Response oResponse = _proyeccionServices.Update(oProyeccion);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpDelete("{id}")]
        [Consumes("application/json")]
        public IActionResult Delete(int id)
        {
            Response oResponse = _proyeccionServices.Delete(id);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }
    }
}
