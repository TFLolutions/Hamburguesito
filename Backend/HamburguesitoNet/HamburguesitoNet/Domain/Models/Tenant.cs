using Domain.Models.Common;
using Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Tenant : Audit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

    }
}
