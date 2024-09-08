using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Command.ProductCommand.CustomerActions.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<Order>
    {
        public string Status { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string ShippingAddress { get; set; }
        public decimal Total { get; set; }
        public string Notes { get; set; }
    }
}
