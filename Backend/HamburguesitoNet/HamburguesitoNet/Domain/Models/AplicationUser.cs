using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AplicationUser 
    {
        [DefaultValue("true")]
        public bool? Active { get; set; }
    }
}
