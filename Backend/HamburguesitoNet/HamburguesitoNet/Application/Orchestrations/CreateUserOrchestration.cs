using Application.DTOs;
using Application.Orchestrations.Interfaces;
using Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Orchestrations
{
    public class CreateUserOrchestration : ICreateUserOrchestration
    {
        public Task<RegisterUserResponse> ExecuteCreateUser(RegisterUserDto registerUserDto, AplicationUser user, CancellationToken cancellationToken)
        {
            var responseUser = new IdentityResult();
            var responseRoleUser = new IdentityResult();

            _logger.LogInformation(String.Format("Creating user: '{0}'", user.UserName));
            responseUser = await _userManager.CreateAsync(user, registerUserDto.Password);
            if (responseUser.Succeeded)
            {
                foreach (var role in registerUserDto.Role)
                {
                    _logger.LogInformation(String.Format("Adding Role: {0} and User: '{1}'", role, user.UserName));
                    responseRoleUser = await _userManager.AddToRoleAsync(user, role);
                }

                return new RegisterUserResponse
                {
                    Success = responseUser.Succeeded || responseRoleUser.Succeeded,
                    Errors = String.Join(" - ", responseUser.Errors.Select(x => x.Description))
                };
            }

            throw new CreateUserException(String.Join(" - ", responseUser.Errors.Select(x => x.Description)));

        }
    }
}
