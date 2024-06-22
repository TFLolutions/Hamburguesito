using Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Order : Audit
    {
        public int OrderId { get; set; }
        public int TableId { get; set; }
        public string Status { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string ShippingAddress { get; set; }
        public decimal Total { get; set; }
        public string Notes { get; set; }

        // Navigation property to link with Customer
        public virtual Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}