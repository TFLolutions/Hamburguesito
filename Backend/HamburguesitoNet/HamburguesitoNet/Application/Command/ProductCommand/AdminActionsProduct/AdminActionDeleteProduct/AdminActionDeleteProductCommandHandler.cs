using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Services;
using Application.Services.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Command.ProductCommand.AdminActionsProduct.AdminActionDeleteProduct
{
    public class AdminActionDeleteProductCommandHandler : IRequestHandler<AdminActionDeleteProductCommand, bool>
    {

        private readonly IDelete<Product> _productService;
        
        public AdminActionDeleteProductCommandHandler(ProductService productService) {

            _productService = productService;
        }


        public async Task<bool> Handle(AdminActionDeleteProductCommand request, CancellationToken cancellationToken)
        {
            var prod = _productService.


            if (product == null ||  )
            {
               
            }

            else
            {
                await _productService.Delete(request.id, cancellationToken);
            }
           
           
        }
    }
}
