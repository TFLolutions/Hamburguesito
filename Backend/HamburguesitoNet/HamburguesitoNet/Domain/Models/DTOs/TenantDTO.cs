using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.DTOs
{
    public class TenantDTO
    {
        public int id {  get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
