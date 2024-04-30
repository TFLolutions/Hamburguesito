using Application.Services.Interfaces;
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
            #endregion

            #region Generic Repository
            services.AddTransient<IGenericRepository<Product>, GenericRepository<Product>>();
            services.AddTransient<IAdd<Product>, ProductService>();
            services.AddTransient<IGet<Product>, ProductService>();
            services.AddTransient<IUpdate<Product>, ProductService>();
            services.AddTransient<IDelete<bool>, ProductService>();
            #endregion

            return services;
        }
    }
}
