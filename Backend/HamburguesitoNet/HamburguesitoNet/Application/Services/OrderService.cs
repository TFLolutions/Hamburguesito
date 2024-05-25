using Application.Services.Interfaces;
using Domain.Models;
using HamburguesitoNet.Application.Common.Interfaces;
using HamburguesitoNet.Application.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderService : IGet<Order>, IUpdate<Order>, IAdd<Order> //IDelete<Order>, 
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IGenericRepository<Order> orderRepository, IUnitOfWork unitOfWork, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        //Add
        public async Task<Order> Add(Order entity, CancellationToken cancellationToken)
        {
            try
            {
                await _orderRepository.AddAsync(entity);
                await _unitOfWork.CommitAsync(cancellationToken);

            }
            catch (Exception)
            {

                throw new Exception();
            }

            return entity;

        }
        //Get
        public Task<IEnumerable<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetById(int entityId)
        {
            return await _orderRepository.GetByIdAsync(entityId);
        }
        //Update
        public Task<Order> Update(Order entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateLastExecution(int entityId, DateTime lastExecution, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //Delete

       
        //public async Task<Order> Delete(int entityId, CancellationToken cancellationToken)
        //{
        //    var orderDb = await GetById(entityId);
        //    orderDb.Active = false;
        //    await _unitOfWork.CommitAsync(cancellationToken);
        //    return true;
        //}

    }
}
