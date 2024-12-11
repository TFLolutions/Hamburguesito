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
        public int IdUser { get; set; }

        public AddUserTenantCommand(int idtenant, int idUser)
        {
            IdTenant = idtenant;
            IdUser = idUser;
        }

    }
}
