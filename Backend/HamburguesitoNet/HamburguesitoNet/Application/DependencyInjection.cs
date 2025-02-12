using AutoMapper;
using HamburguesitoNet.Application.Common.Behaviours;
using HamburguesitoNet.Application.Repositories.Interfaces;
using HamburguesitoNet.Application.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System.Reflection;
using Domain.Models;
using Application.Services;
using Application.Services.Interfaces.Generics;
using Application.Common.Utils;
using Application.Services.Interfaces;

namespace HamburguesitoNet.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            #region Services
            services.AddTransient<ProductService>();
            services.AddTransient<OrderService>();
            services.AddTransient<CustomerService>();
            services.AddTransient<TenantService>();
            services.AddTransient<UserTenantService>();
            #endregion

            #region Generic Repository
            services.AddTransient<IGenericRepository<Product>, GenericRepository<Product>>();
            services.AddTransient<IAdd<Product>, ProductService>();
            services.AddTransient<IGet<Product>, ProductService>();
            services.AddTransient<IUpdate<Product>, ProductService>();
            services.AddTransient<IDelete<bool>, ProductService>();
            #endregion

            #region Order Service
            services.AddTransient<IGenericRepository<Order>, GenericRepository<Order>>();
            services.AddTransient<IAdd<Order>, OrderService>();
            services.AddTransient<IGet<Order>, OrderService>();
            services.AddTransient<IUpdate<Order>, OrderService>();
            // services.AddTransient<IDelete<bool>, OrderService>();
            #endregion

            #region TenantService
            services.AddTransient<IGenericRepository<Tenant>, GenericRepository<Tenant>>();
            #endregion

            #region UserTenantService
            services.AddTransient<IGenericRepository<UserTenant>, GenericRepository<UserTenant>>();
            services.AddTransient<IUserTenantService, UserTenantService>();

            #endregion

            #region JWT
            services.AddSingleton<JwtHelper>();
            #endregion

            #region Customer Service
            services.AddTransient<IGenericRepository<Customer>, GenericRepository<Customer>>();
            #endregion

            return services;
        }
    }
}
