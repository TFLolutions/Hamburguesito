using Application.Services;
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
        private readonly UserTenantService _userTenantService;
        private readonly TenantService _tenantService;
        private readonly UserManager<ApplicationUser> _userManager;


        public AddUserTenantCommandHandler(UserTenantService userTenantService, TenantService tenantService, UserManager<ApplicationUser> userManager)
        {
            _userTenantService = userTenantService;
            _tenantService = tenantService;
            _userManager = userManager;
        }
        public async Task<UserTenant> Handle(AddUserTenantCommand request, CancellationToken cancellationToken)
        {

            //Validar si existe el tenant 

            var tenant = await _tenantService.GetById(request.IdTenant) ?? throw new ArgumentException($"This tenant {request.IdTenant} doesn´t exists");

            // Validar si existe el user en la bbdd
            /*var user = await _userManager.FindByIdAsync(request.IdUser.ToString());
            if (user == null)
            {
                throw new ArgumentException($"This user {request.IdUser} doesn't exist");
            }*/



            //Revisar esta parte de codigo 
            //Validar si existe el usuario en ese tenant 
            var isUserPartOfTenant = await _userTenantService.IsUserPartOfTenant(request.IdUser, request.IdTenant);
            if (isUserPartOfTenant)
            {
                throw new ArgumentException($"This user {request.IdUser} already exists in this tenant");
            }






            var userTenant = new UserTenant()
            {
                IdUser = request.IdUser,
                IdTenant = request.IdTenant,
            };

            await _userTenantService.Add(userTenant, cancellationToken);

            return userTenant;



        }
    }
}
