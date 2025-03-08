using Domain.Models;
using Domain.Models.Common;
using HamburguesitoNet.Application.Common.Interfaces;
using HamburguesitoNet.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace HamburguesitoNet.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        private readonly IDateTime _dateTime;
        private readonly IServiceProvider _serviceProvider;

        public ApplicationDbContext(DbContextOptions options, IDateTime dateTime, IServiceProvider serviceProvider) : base(options)
        {
            _dateTime = dateTime;
            _serviceProvider = serviceProvider;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ApplicationUser> AplicationUsers { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<UserTenant> UserTenants { get; set; }




        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var userService = _serviceProvider.GetRequiredService<IUserService>();

            foreach (var entry in ChangeTracker.Entries<Audit>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = userService.GetUser();
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = userService.GetUser();
                        entry.Entity.Updated = _dateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public Task ReloadEntityAsync<TEntity>(TEntity entity) where TEntity : class
        {
            return Entry(entity).ReloadAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Apply configurations from the assembly
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Define additional properties for Product
            builder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18, 2)");
        }
    }
}
