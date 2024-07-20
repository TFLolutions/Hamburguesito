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

        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.Username,
                Email = request.Email
            };

            var responseUser = await _userManager.CreateAsync(user);

            if (responseUser.Succeeded)
            {
                foreach (var role in request.Role)
                {
                    if (!await _roleManager.RoleExistsAsync(role))
                        throw new Exception("The specified role don't exists.");
                    else
                    {
                        var responseRoleUser = await _userManager.AddToRoleAsync(user, role);
                    }
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
