using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Command.ProductCommand.AdminActionsProduct.AdminActionCreateProduct
{
    public class AdminActionCreateProductCommand : IRequest<Product>
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
       

    }
}
