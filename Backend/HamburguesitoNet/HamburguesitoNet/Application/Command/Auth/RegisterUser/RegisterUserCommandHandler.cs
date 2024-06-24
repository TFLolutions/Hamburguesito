using Domain.Models;
using HamburguesitoNet.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Auth.RegisterUser
{
    public class RegisterUserCommandHandler
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterUserCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(RegisterUserCommand command)
        {
            var user = new IdentityUser
            {
                UserName = command.Username,
                Email = command.Email
            };

            var result = await _userManager.CreateAsync(user, command.Password);

            if (result.Succeeded && !string.IsNullOrEmpty(command.Role))
            {
                await _userManager.AddToRoleAsync(user, command.Role);
            }

            return result;
        }
    }
}
