using Domain.Models.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.TenantCommand
{
    public class TenantCommand : IRequest<TenantDTO>
    {
        public int id { get; set; }
        public string Name { get; set; }

        public bool Active { get; set; }
       
    }
}
