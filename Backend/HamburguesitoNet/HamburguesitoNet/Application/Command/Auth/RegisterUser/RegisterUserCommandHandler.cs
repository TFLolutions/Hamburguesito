using Application.DTOs;
using Domain.Models;
using HamburguesitoNet.Application.Common.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Command.Auth.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        public readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            //Cambiar esto cuando ya tengamos autenticación
            var isAdmin = true;

            var user = new ApplicationUser
            {
                UserName = request.Username,
                Email = request.Email
            };

            var responseUser = await _userManager.CreateAsync(user);

            if (responseUser.Succeeded)
            {
                if (isAdmin)
                {
                  foreach(var role in request.Role)
                    {
                        IdentityRole roles = new IdentityRole();

                        roles.Name = role;
                        await _roleManager.CreateAsync(roles);
                    }
                }
                
                foreach (var role in request.Role)
                {
                    if (await _roleManager.RoleExistsAsync(role) == false)
                        throw new Exception("The specified role don't exists.");
                    else
                        await _userManager.AddToRoleAsync(user, role);
                }
            }

            return new RegisterUserResponse
            {
                Success = responseUser.Succeeded,
                Errors = String.Join(" - ", responseUser.Errors.Select(x => x.Description))
            };
        }
    }
}
