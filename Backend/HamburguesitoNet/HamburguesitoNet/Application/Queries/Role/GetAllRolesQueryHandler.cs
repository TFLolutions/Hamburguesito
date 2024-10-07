using Domain.Models;
using Domain.Models.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Role
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<RolesDTO>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public GetAllRolesQueryHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<RolesDTO>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleManager.Roles.ToListAsync();

            var rolesDto = roles.Select(role => new RolesDTO
            {
                Id = role.Id,
                Name = role.Name,
                NormalizedName = role.NormalizedName,
            }).ToList();

            return rolesDto;
        }
    }

   
}
