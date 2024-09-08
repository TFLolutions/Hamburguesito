using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Interfaces.Generics
{
    public interface IDelete<T>
    {
        Task<T> Delete(int entityId, CancellationToken cancellationToken);
    }
}
