using Application.Queries.Users;
using HamburguesitoNet.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System;
using Application.Queries.Role;

namespace WebUI.Controllers
{
    public class RoleController : ApiController
    {
        [HttpGet]
        [Route("Getallroles")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]

        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllRolesQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
