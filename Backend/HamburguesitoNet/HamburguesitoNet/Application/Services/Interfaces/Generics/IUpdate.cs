using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Interfaces.Generics
{
    public interface IUpdate<T> where T : class
    {
        Task<T> UpdateLastExecution(int entityId, DateTime lastExecution, CancellationToken cancellationToken);
        Task<T> Update(T entity, CancellationToken cancellationToken);
    }
}
