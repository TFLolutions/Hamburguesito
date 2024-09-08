using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Auth.UserLockManagment
{
    public class UserLockManagementCommand : IRequest<string>
    {
        public string Id { get; set; } 

        public DateTime? EndDate { get; set; }
    }
}
