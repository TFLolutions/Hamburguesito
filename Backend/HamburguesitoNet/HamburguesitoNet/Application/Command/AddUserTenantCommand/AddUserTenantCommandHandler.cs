using Application.Services;
using Application.Services.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Command.AddUserTenantCommand
{
    public class AddUserTenantCommandHandler : IRequestHandler<AddUserTenantCommand, UserTenant>
    {
        private readonly IUserTenantService _userTenantService;
        private readonly TenantService _tenantService;
        private readonly UserManager<ApplicationUser> _userManager;


        public AddUserTenantCommandHandler(IUserTenantService userTenantService, TenantService tenantService, UserManager<ApplicationUser> userManager)
        {
            _userTenantService = userTenantService;
            _tenantService = tenantService;
            _userManager = userManager;
        }

        public async Task<UserTenant> Handle(AddUserTenantCommand request, CancellationToken cancellationToken)
        {
            //Validar si existe el tenant 
            var tenant = await _tenantService.GetById(request.TenantId) ?? throw new ArgumentException($"This tenant {request.TenantId} doesn´t exists");

            // Validar si existe el user en la bbdd

            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                throw new ArgumentException($"This user {request.UserId} doesn't exist");
            }

            //Revisar esta parte de codigo 
            //Validar si existe el usuario en ese tenant 
            var isUserPartOfTenant = await _userTenantService.GetTenantUsersByTenantId(request.TenantId);

            if (isUserPartOfTenant.FirstOrDefault(x => x.UserId == request.UserId) != null)
            {
                throw new ArgumentException($"This user {request.UserId} already exists in this tenant");
            }

            var userTenant = new UserTenant()
            {
                UserId = request.UserId,
                TenantId = request.TenantId,
            };

            await _userTenantService.Add(userTenant, cancellationToken);

            return userTenant;



        }
    }
}
