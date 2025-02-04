using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.AddUserTenantCommand
{
    public class AddUserTenantCommand:IRequest<UserTenant>
    {
        public int IdTenant { get; set; }
        public Guid UserId { get; set; }

        public AddUserTenantCommand(int idtenant, Guid userId)
        {
            IdTenant = idtenant;
            UserId = userId;   
        }

    }
}
