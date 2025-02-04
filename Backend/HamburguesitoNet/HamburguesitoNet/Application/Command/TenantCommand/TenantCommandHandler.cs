using Application.Services;
using Domain.Models.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Command.TenantCommand
{
    public class TenantCommandHandler : IRequestHandler<TenantCommand, TenantDTO>
    {
        private readonly TenantService _tenantService;
        public TenantCommandHandler(TenantService tenantService)
        {
            _tenantService = tenantService;
        }



        public async Task<TenantDTO> Handle(TenantCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentException("Request is null");
            }

            var verifyTenant = await _tenantService.GetById(request.id);

            var tenantDTO = new TenantDTO();

            if (verifyTenant == null)
            {
                var tenant = new Tenant()
                {
                    Name = request.Name,
                    Active = request.Active,
                };
                var addedTenant = await _tenantService.Add(tenant, cancellationToken);

                tenantDTO = new TenantDTO
                {
                    id = addedTenant.Id,
                    Name = addedTenant.Name,
                    Active = addedTenant.Active,

                };

            }
            else
            {
                //Verificar que no exista tenant con mismo nombre

                if (string.Equals(request.Name, verifyTenant.Name, StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("This name already exists, choose another one");
                }
            }

            return tenantDTO;

        }
    }
}
