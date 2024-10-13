using Application.Command.Auth.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System;
using HamburguesitoNet.WebUI.Controllers;
using Application.Command.Auth.Login;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Application.Command.Auth.UserLockManagment;
using Application.Command.Auth.ResetPassword;
using Application.Queries.Users;

namespace WebUI.Controllers
{
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController (ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("register")]
        [Authorize(Roles = "Administrator")]
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

        [HttpPost]
        [Route("login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login([FromBody] GetUserByEmailAndPassQuery command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("reset-password")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPost]
        [Route("lock-management")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UserLockManagement([FromBody] UserLockManagementCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Getallusers")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]

        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllUsersQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}
