using Application.Services;
using Domain.Models;
using MediatR;
using MoreLinq.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Command.ProductCommand.CustomerActions.CreateProduct
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly OrderService _orderService;

        public CreateOrderCommandHandler(OrderService orderService)
        {
            _orderService=orderService;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                Status=request.Status, 
                DeliveryDate=request.DeliveryDate,  
                ShippingAddress=request.ShippingAddress,
                Total=request.Total,
                Notes=request.Notes,
                Products=request.ProductsItems.Select(item => new Product
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,                 
                }).ToList()
            };
            

            return await _orderService.Add(order, cancellationToken);
        }

        
    }
}
