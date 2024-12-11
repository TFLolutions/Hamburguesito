using Application.Command.Auth.RegisterUser;
using HamburguesitoNet.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System;
using Application.Command.TenantCommand;
using Application.Command.AddUserTenantCommand;

namespace WebUI.Controllers
{
    public class TenantController : ApiController
    {
        [HttpPost]
        [Route("registerTenant")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegisterTenant([FromBody] TenantCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest($"Tenant id not active {ex}");
            }
        }


        [HttpPost]
        [Route("AddUserTenant")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UserTenant([FromBody] AddUserTenantCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest($"UserTenant is not active {ex}");
            }
        }




    }
}
