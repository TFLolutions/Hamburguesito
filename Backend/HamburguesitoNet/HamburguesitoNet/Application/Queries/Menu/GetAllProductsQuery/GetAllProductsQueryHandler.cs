using Application.Common.Exceptions;
using Application.Services.Interfaces.Generics;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Menu.GetAllProductsQuery
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IList<Product>>
    {
        private readonly IGet<Product> _productService;
        public GetAllProductsQueryHandler(IGet<Product> productService)
        {
            _productService = productService;
        }

        public async Task<IList<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetAll();
            if (product == null) { throw new GetProductsException(); }
            return new List<Product>(product);
        }
    }
}
