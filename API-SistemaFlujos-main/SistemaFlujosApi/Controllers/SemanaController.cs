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
    public class SemanaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private SemanaServices _semanaServices;

        public SemanaController(SemanaServices semanaServices, IConfiguration configuration)
        {
            _semanaServices = semanaServices;
            _configuration = configuration;
        }

        [HttpGet("getWeeksbySearch")]
        [Consumes("application/json")]
        public IActionResult getWeeksbySearch()
        {
            Response oResponse = _semanaServices.GetSearch();

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpGet]
        [Consumes("application/json")]
        public IActionResult getWeeks()
        {
            Response oResponse = _semanaServices.Get();

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        public IActionResult Get(int id)
        {
            Response oResponse = _semanaServices.Get(id);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpPost("New")]
        [Consumes("application/json")]
        public IActionResult New([FromBody] Semana oSemana)
        {
            Response oResponse = _semanaServices.Add(oSemana);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }


        [HttpPost("Update")]
        [Consumes("application/json")]
        public IActionResult Update([FromBody] Semana oSemana)
        {
            Response oResponse = _semanaServices.Update(oSemana);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpDelete("{id}")]
        [Consumes("application/json")]
        public IActionResult Delete(int id)
        {
            Response oResponse = _semanaServices.Delete(id);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }
    }
}
