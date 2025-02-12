using Application.Services.Interfaces;
using Application.Services.Interfaces.Generics;
using Domain.Models;
using HamburguesitoNet.Application.Common.Interfaces;
using HamburguesitoNet.Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserTenantService : IUserTenantService 
    {
        private readonly IGenericRepository<UserTenant> _userTenantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserTenantService(IGenericRepository<UserTenant> usertenantRepository, IUnitOfWork unitOfWork)
        {
            _userTenantRepository = usertenantRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<UserTenant> Add(UserTenant entity, CancellationToken cancellationToken)
        {

            try
            {
                await _userTenantRepository.AddAsync(entity);
                await _unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Add failed", ex);
            }
            return entity;

        }

        public Task<IEnumerable<UserTenant>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserTenant> GetById(int entityId)
        {
            return await _userTenantRepository.GetByIdAsync(entityId);
        }

        public async Task<IEnumerable<UserTenant>> GetTenantUsersByTenantId(int tenantId)
        {
            var userTenant = await _userTenantRepository.GetManyAsync(ut => ut.TenantId == tenantId);

            return userTenant;
        }
    }
}
