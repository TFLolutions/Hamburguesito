using Application.Services;
using Domain.Models;
using HamburguesitoNet.Application.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Command.ProductCommand.AdminActionsProduct.AdminActionUpdateProduct
{
    public class AdminActionUpdateProductCommandHandler:IRequestHandler<AdminActionUpdateProductCommand,Product>
    {
        private readonly ProductService _productService;

        public AdminActionUpdateProductCommandHandler(ProductService productService)
        {
            _productService = productService;
        }


        public async Task<Product> Handle(AdminActionUpdateProductCommand request, CancellationToken cancellationToken)
        {

            var product = new Product
            {
                Id=request.Id,
                Price = request.Price,
                Name = request.Name,
                Active = request.Active,
                Description = request.Description,
            };
            
            var response = await _productService.Update(product,cancellationToken);
            return response;
        }

    }
}
