using Domain.Models.Common;
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

        public Customer Customer { get; set; }

    }
}
