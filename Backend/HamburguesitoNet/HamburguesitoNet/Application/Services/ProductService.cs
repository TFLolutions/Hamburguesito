﻿using Application.Services.Interfaces;
using Domain.Models;
using HamburguesitoNet.Application.Common.Interfaces;
using HamburguesitoNet.Application.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Application.Services
{
    public class ProductService : IAdd<Product>, IGet<Product>, IUpdate<Product>, IDelete<Product>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IGenericRepository<Product> productRepository, IUnitOfWork unitOfWork, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Product> Add(Product entity, CancellationToken cancellationToken)
        {
            await _productRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return entity;
        }

        public Task<Product> Delete(int entityId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAllAsync();
        }

        public Task<Product> GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(Product entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateLastExecution(int entityId, DateTime lastExecution, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
