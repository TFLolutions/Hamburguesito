using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AplicationUser : IdentityUser
    {
        [DefaultValue("true")]
        public DateTime CreationDate { get; set; }

        [ForeignKey("CustomerFK")]
        public Customer Customer { get; set; }
    }
}
