using Application.DTO;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Command.Auth.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResetPasswordResponse>
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public ResetPasswordCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResetPasswordResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user == null)
                {
                    //TODO agregar logica de logueo
                    return new ResetPasswordResponse
                    {
                        Success = true,
                        Error = "",
                    };
                }
                var response = await _userManager.ResetPasswordAsync(user, request.Code, request.Password);
                return new ResetPasswordResponse
                {
                    Success = response.Succeeded,
                    Error = response.ToString()
                };
            }
            catch (Exception ex)
            {
                return new ResetPasswordResponse
                {
                    Success = false,
                    Error = ex.Message
                };
            }
        }
    }
}
