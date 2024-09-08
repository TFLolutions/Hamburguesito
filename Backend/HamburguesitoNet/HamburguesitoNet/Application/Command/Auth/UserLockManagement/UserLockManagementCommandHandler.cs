using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Command.Auth.UserLockManagment
{
    public class UserLockManagementCommandHandler : IRequestHandler<UserLockManagementCommand, string>
    {
        public readonly UserManager<ApplicationUser> _userManager;

        public UserLockManagementCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> Handle(UserLockManagementCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            var userLocked = await _userManager.IsLockedOutAsync(user);

            if (userLocked && request.EndDate == null)
            {
                await _userManager.SetLockoutEndDateAsync(user, DateTime.Now - TimeSpan.FromMinutes(1));
                var restoredUserMessage = $"User: {user.Email} restored";
               
                return (restoredUserMessage);
            }
            else
            {
                await _userManager.SetLockoutEndDateAsync(user, request.EndDate);
                var lockedUserMessage = $"User: {user.Email} is locked until {request.EndDate}";
                return (lockedUserMessage);
            }
        }


    }


}
