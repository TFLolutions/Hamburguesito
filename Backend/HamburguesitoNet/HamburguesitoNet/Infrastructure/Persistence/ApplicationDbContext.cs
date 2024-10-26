using Domain.Models;
using Domain.Models.Common;
using HamburguesitoNet.Application.Common.Interfaces;
using HamburguesitoNet.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserService _userService;

        public ApplicationDbContext(DbContextOptions options,
            IDateTime dateTime,
            IUserService userService) : base(options)
        {
            _dateTime = dateTime;
            _userService = userService;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ApplicationUser> AplicationUsers { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<UserTenant> userTenants { get; set; }




        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Audit>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _userService.GetUser();
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = _userService.GetUser();
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

            // Seed Admin Role
            string adminRoleId = "62000fc2-d381-4169-896a-5939d068ed99"; // Use your specific RoleId
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });

            // Create Admin User
            string adminUserId = "091d1b89-12b8-49ef-9766-6624b1fea3e0"; // Use your specific UserId
            var adminUser = new IdentityUser
            {
                Id = adminUserId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@domain.com",
                NormalizedEmail = "ADMIN@DOMAIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            // Hash the password before seeding
            var passwordHasher = new PasswordHasher<IdentityUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "AdminPassword123!");

            // Seed Admin User
            builder.Entity<IdentityUser>().HasData(adminUser);

            // Assign Admin Role to Admin User
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            });

            // Define additional properties for Product
            builder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18, 2)");

           
        }
    }
}
