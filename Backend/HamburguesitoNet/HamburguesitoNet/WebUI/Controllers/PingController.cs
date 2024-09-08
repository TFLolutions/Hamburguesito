using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;

namespace HamburguesitoNet.WebUI.Controllers
{
    [Route("ping")]
    public class PingController : ApiController
    {
        private readonly IConfiguration _configuration;

        public PingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Ping a la aplicacion
        /// </summary>
        /// <response code="200">Devuelve el ping a la aplicacion</response>
        /// <response code="400">Error inesperado</response> 
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Ping()
        {
            try
            {
                return Ok(new
                {
                    Response = "Pong",
                    KeyWord = _configuration.GetSection("KeyWord").Value,
                    Fecha = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
