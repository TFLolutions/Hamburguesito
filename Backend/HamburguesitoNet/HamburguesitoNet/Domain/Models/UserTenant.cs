using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserTenant
    {
        [Key]
        public int TenantId { get; set; }

        public Guid UserId { get; set; }

    }
}
