using Application.Command.ProductCommand.AdminActionsProduct.AdminActionUpdateProduct;
using Application.Common.Exceptions;
using Application.Services.Interfaces.Generics;
using Domain.Models;
using HamburguesitoNet.Application.Common.Interfaces;
using HamburguesitoNet.Application.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Application.Services
{
    public class ProductService : IAdd<Product>, IGet<Product>, IUpdate<Product>, IDelete<bool>
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
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetById(int entityId)
        {
            return await _productRepository.GetByIdAsync(entityId);
        }

        public async Task<Product> Add(Product entity, CancellationToken cancellationToken)
        {
            try
            {
                await _productRepository.AddAsync(entity);
                await _unitOfWork.CommitAsync(cancellationToken);
            }
            catch (CreateProductException ex)
            {
                throw new CreateProductException("No se pudo crear el producto");
            }
            
            return entity;
        }
        public async Task<Product> Update(Product entity, CancellationToken cancellationToken)
        {
            try
            {
                var productDb = await GetById(entity.Id);
                if (productDb != null || productDb.Active != false)
                {
                    productDb.Price = entity.Price;
                    productDb.Name = entity.Name;
                    productDb.Active = entity.Active;
                    productDb.Description = entity.Description;
                    _productRepository.Update(productDb);
                    await _unitOfWork.CommitAsync(cancellationToken);
                    return productDb;

                }
                else { throw new UpdateProductException("Error al actualizar producto"); }
            }
            catch (UpdateProductException ex) {
            throw new UpdateProductException("Error al actualizar producto");
            }               
        }

        public Task<Product> UpdateLastExecution(int entityId, DateTime lastExecution, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> Delete(int entityId, CancellationToken cancellationToken)
        {
            var productDb = await GetById(entityId);
            productDb.Active = false;
            await _unitOfWork.CommitAsync(cancellationToken);
            return true; 
        }
    }
}
