using Application.Queries.Users;
using Application.Services.Interfaces;
using Domain.Models;
using Domain.Models.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Tenant
{
    public class GetAllTenantUsersQueryHandler : IRequestHandler<GetAllTenantUsersQuery, IEnumerable<UserTenant>>
    {
        public readonly IUserTenantService _userTenantService;

        public GetAllTenantUsersQueryHandler(IUserTenantService userTenantService)
        {
            _userTenantService = userTenantService;
        }

        public Task<IEnumerable<UserTenant>> Handle(GetAllTenantUsersQuery request, CancellationToken cancellationToken)
        {
            return _userTenantService.GetTenantUsersByTenantId(request.TenantId);
        }
    }
}
