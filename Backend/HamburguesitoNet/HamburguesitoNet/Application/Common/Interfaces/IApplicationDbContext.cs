using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HamburguesitoNet.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task ReloadEntityAsync<TEntity>(TEntity entity) where TEntity : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        public void Dispose();
    }
}