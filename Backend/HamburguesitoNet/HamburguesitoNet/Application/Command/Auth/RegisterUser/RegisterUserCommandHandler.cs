using Application.DTOs;
using Domain.Models;
using HamburguesitoNet.Application.Common.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.Username,
                Email = request.Email,
                CreationDate = request.CreationDate
            };

            var responseUser = await _userManager.CreateAsync(user, request.Password);

            if (responseUser.Succeeded)
            {
                foreach (var role in request.Role)
                {


                    // Cambiar hardcodeo y agregar validacion para ver si existe usuario 



                    if (await _roleManager.RoleExistsAsync(role) == false) {
                        IdentityRole roleRole = new IdentityRole();
                        roleRole.NormalizedName = role;
                        await _roleManager.CreateAsync(roleRole);
                        //throw new Exception("The specified role don't exists.");
                    }


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
