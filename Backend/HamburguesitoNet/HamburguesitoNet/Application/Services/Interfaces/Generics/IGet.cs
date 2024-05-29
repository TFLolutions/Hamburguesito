using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces.Generics
{
    public interface IGet<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int entityId);

    }
}
