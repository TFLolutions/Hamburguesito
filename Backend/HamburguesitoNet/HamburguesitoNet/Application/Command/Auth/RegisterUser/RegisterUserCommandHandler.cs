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
        private readonly UserManager<AplicationUser> _userManager;

        public RegisterUserCommandHandler(UserManager<AplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new AplicationUser
            {
                UserName = request.Username,
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(user);
            var responseRoleUser = await _userManager.AddToRoleAsync(user, request.Role);

            if (result.Succeeded && !string.IsNullOrEmpty(request.Role))
            {
                await _userManager.AddToRoleAsync(user, request.Role);
            }

            return new RegisterUserResponse
            {
                Success = result.Succeeded,
                Errors = String.Join(" - ", result.Errors.Select(x => x.Description))
            };
        }
    }
}
