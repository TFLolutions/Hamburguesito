using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserTenant
    {
        public int IdTenant { get; set; }

        public Guid UserId { get; set; }

    }
}
