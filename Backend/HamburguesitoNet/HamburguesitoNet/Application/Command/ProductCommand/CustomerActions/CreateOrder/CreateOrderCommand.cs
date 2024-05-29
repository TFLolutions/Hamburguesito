using Domain.Models;
using Domain.Models.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.ProductCommand.CustomerActions.CreateProduct
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string ShippingAddress { get; set; }
        public decimal Total { get; set; }
        public string Notes { get; set; }
        public ICollection<ProductDTO> ProductsItems { get; set; }
    }
}
