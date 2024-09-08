using Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Table : Audit
    {

        public int TableId { get; set; }

        public string Name { get; set; }

    }
}
