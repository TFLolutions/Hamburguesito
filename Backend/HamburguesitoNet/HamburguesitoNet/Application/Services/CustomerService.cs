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
    public class CustomerService
    {
        private readonly IGenericRepository<Customer> _customerRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IGenericRepository<Customer> customerRepository, IUnitOfWork unitOfWork, ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        //Add
        public async Task<Customer> Add(Customer entity, CancellationToken cancellationToken)
        {
            try
            {
                await _customerRepository.AddAsync(entity);
                await _unitOfWork.CommitAsync(cancellationToken);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }

            return entity;
        }

        public async Task<Customer> GetById(int entityId)
        {
            return await _customerRepository.GetByIdAsync(entityId);
        }
    }
}
