using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.ProductCommand.AdminActionsProduct.AdminActionDeleteProduct
{
    internal class AdminActionDeleteProductCommand : IRequest<bool>
    {
        public int id { get; set; }
    }
}
