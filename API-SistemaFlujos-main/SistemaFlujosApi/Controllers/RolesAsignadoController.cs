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
    public class RolesAsignadoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private RolesAsignadoServices _rolesAsignadoServices;

        public RolesAsignadoController(RolesAsignadoServices rolesAsignadoServices, IConfiguration configuration)
        {
            _rolesAsignadoServices = rolesAsignadoServices;
            _configuration = configuration;
        }

        [HttpGet]
        [Consumes("application/json")]
        public IActionResult Get()
        {
            Response oResponse = _rolesAsignadoServices.Get();

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        public IActionResult Get(int id)
        {
            Response oResponse = _rolesAsignadoServices.Get(id);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpPost("New")]
        [Consumes("application/json")]
        public IActionResult New([FromBody] RolesAsignado oRolesAsignado)
        {
            Response oResponse = _rolesAsignadoServices.Add(oRolesAsignado);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }


        [HttpPost("Update")]
        [Consumes("application/json")]
        public IActionResult Update([FromBody] RolesAsignado oRolesAsignado)
        {
            Response oResponse = _rolesAsignadoServices.Update(oRolesAsignado);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }

        [HttpDelete("{id}")]
        [Consumes("application/json")]
        public IActionResult Delete(int id)
        {
            Response oResponse = _rolesAsignadoServices.Delete(id);

            if (oResponse.code == 400)
                return NotFound(oResponse);
            else
                return Ok(oResponse);

        }
    }
}
