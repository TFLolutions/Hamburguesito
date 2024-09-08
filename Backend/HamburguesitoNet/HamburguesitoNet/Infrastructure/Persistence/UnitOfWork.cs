using HamburguesitoNet.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HamburguesitoNet.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IApplicationDbContext Context { get; }

        public UnitOfWork(IApplicationDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await Context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
