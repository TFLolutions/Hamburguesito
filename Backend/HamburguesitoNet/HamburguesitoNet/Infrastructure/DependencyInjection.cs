﻿using HamburguesitoNet.Application.Common.Interfaces;
using HamburguesitoNet.Application.Common.Interfaces.Services;
using HamburguesitoNet.Application.Common.Utils;
using HamburguesitoNet.Infrastructure.Persistence;
using HamburguesitoNet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HamburguesitoNet.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = VariablesUtil.GetConnectionString(configuration);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection,
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
