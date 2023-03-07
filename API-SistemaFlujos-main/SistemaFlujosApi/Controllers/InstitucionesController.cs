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
    public class InstitucionesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private InstitucionesServices _institucionesServices;

        public InstitucionesController(InstitucionesServices institucionesServices, IConfiguration configuration)
        {
            _institucionesServices = institucionesServices;
            _configuration = configuration;
        }

        [HttpGet]
        [Consumes("application/json")]
        public IActionResult Get()
        {
            Response oResponse = _institucionesServices.Get();

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        public IActionResult Get(int id)
        {
            Response oResponse = _institucionesServices.Get(id);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpPost("New")]
        [Consumes("application/json")]
        public IActionResult New([FromBody] Institucione oInstitucione)
        {
            Response oResponse = _institucionesServices.Add(oInstitucione);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }


        [HttpPost("Update")]
        [Consumes("application/json")]
        public IActionResult Update([FromBody] Institucione oInstitucione)
        {
            Response oResponse = _institucionesServices.Update(oInstitucione);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpDelete("{id}")]
        [Consumes("application/json")]
        public IActionResult Delete(int id)
        {
            Response oResponse = _institucionesServices.Delete(id);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }
    }
}
