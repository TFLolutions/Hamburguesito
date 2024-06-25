using Application.Command.Auth.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System;
using HamburguesitoNet.WebUI.Controllers;

namespace WebUI.Controllers
{
    [ApiController]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("register")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
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

        //[HttpPost]
        //[Route("login")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> Login([FromBody] GetUserByEmailAndPassQuery command)
        //{
        //    try
        //    {
        //        return Ok(await Mediator.Send(command));
        //    }
        //    catch (EmailPasswordWrongException e)
        //    {
        //        _logger.LogInformation(string.Format("User '{0}' failed to login.", command.Email));
        //        return Unauthorized(e.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogInformation(ex.Message);
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPost]
        //[Route("reset-password")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        //{
        //    try
        //    {
        //        return Ok(await Mediator.Send(command));
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogWarning(ex.Message);
        //        return BadRequest(ex.Message);
        //    }
        //}

    }
}
