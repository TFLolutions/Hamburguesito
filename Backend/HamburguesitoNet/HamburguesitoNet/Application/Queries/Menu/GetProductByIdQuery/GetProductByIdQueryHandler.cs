using Application.Services.Interfaces.Generics;
using Domain.Models;
using Domain.Models.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Menu.GetProductByIdQuery
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductByIdDTO>
    {
        private readonly IGet<Product> _productService;

        public GetProductByIdQueryHandler(IGet<Product> productService)
        {
            _productService = productService;
        }

        public async Task<ProductByIdDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetById(request.Id);



            if (product == null)
            {
                throw new ArgumentException(); // Personalizar excepcion 
            }
            else
            {
                return new ProductByIdDTO()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,

                };
            }
        }



    }
}
