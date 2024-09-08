using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Menu
{
    public class GetAllProductsQuery : IRequest<IList<Product>>
    {

    }
}
