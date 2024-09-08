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
        private readonly ProductService _productService;
        private readonly CustomerService _customerService;


        public CreateOrderCommandHandler(OrderService orderService, ProductService productService, CustomerService customerService)
        {
            _orderService = orderService;
            _productService = productService;
            _customerService = customerService;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var productList = new List<Product>();

            
            var customer = await _customerService.GetById(request.CustomerId);
            if (customer == null)
                throw new Exception($"CustomerId : {request.CustomerId} doesn't exists");

            foreach (var product in request.ProductsItems)
            {
                var productDB = await _productService.GetById(product.Id);

                if (productDB == null)
                    throw new Exception($"ProductId : {product.Id} doesn't exists");

                productList.Add(productDB);
            }

            var order = new Order()
            {
                Status = request.Status,
                DeliveryDate = request.DeliveryDate,
                ShippingAddress = request.ShippingAddress,
                Total = request.Total,
                Notes = request.Notes,
                Customer = customer,
                Products = productList
            };


            return await _orderService.Add(order, cancellationToken);
        }


    }
}
