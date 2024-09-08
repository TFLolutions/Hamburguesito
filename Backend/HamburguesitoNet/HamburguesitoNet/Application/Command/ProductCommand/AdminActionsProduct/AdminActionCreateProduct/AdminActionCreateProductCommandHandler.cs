using Application.Command.ProductCommand.AdminActionsProduct.AdminActionUpdateProduct;
using Application.Services;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Command.ProductCommand.AdminActionsProduct.AdminActionCreateProduct
{
    public class AdminActionCreateProductCommandHandler: IRequestHandler<AdminActionCreateProductCommand, Product>
    {
        private readonly ProductService _productService;

        public AdminActionCreateProductCommandHandler(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<Product> Handle(AdminActionCreateProductCommand request, CancellationToken cancellationToken)
        {
            var producto = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Active = true,
            };
            return await _productService.Add(producto, cancellationToken);
        }



    }
}
