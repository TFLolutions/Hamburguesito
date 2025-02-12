using Domain.Models;
using Domain.Models.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Tenant
{
    public class GetAllTenantUsersQuery : IRequest<IEnumerable<UserTenant>>
    {
        public int TenantId { get; set; }
    }
}
