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
    public class VariacionProyeccionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private VariacionProyeccionServices _variacionProyeccionServices;

        public VariacionProyeccionController(VariacionProyeccionServices variacionProyeccionServices, IConfiguration configuration)
        {
            _variacionProyeccionServices = variacionProyeccionServices;
            _configuration = configuration;
        }

        [HttpGet]
        [Consumes("application/json")]
        public IActionResult Get()
        {
            Response oResponse = _variacionProyeccionServices.Get();

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        public IActionResult Get(int id)
        {
            Response oResponse = _variacionProyeccionServices.Get(id);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpPost("New")]
        [Consumes("application/json")]
        public IActionResult New([FromBody] VariacionProyeccion oVariacionProyeccion)
        {
            Response oResponse = _variacionProyeccionServices.Add(oVariacionProyeccion);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }


        [HttpPost("Update")]
        [Consumes("application/json")]
        public IActionResult Update([FromBody] VariacionProyeccion oVariacionProyeccion)
        {
            Response oResponse = _variacionProyeccionServices.Update(oVariacionProyeccion);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpDelete("{id}")]
        [Consumes("application/json")]
        public IActionResult Delete(int id)
        {
            Response oResponse = _variacionProyeccionServices.Delete(id);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }
    }
}
