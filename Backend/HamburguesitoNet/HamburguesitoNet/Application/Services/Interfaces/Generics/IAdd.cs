using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Interfaces.Generics
{
    public interface IAdd<T> where T : class
    {
        Task<T> Add(T entity, CancellationToken cancellationToken);
    }
}
