using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUserTenantService
    {
        Task<UserTenant> Add(UserTenant entity, CancellationToken cancellationToken);
        Task<IEnumerable<UserTenant>> GetTenantUsersByTenantId(int tenantId);
        

    }
}
