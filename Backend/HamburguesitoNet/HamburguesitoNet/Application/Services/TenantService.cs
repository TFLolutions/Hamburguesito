using Application.Services.Interfaces.Generics;
using HamburguesitoNet.Application.Common.Interfaces;
using HamburguesitoNet.Application.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TenantService : IAdd<Tenant>,IGet<Tenant>//, IUpdate<Tenant>, IDelete<Tenant>,
    {
        private readonly IGenericRepository<Tenant> _tenantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TenantService(IGenericRepository<Tenant> tenantRepository,IUnitOfWork unitOfWork) {
            _tenantRepository = tenantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Tenant> Add(Tenant entity, CancellationToken cancellationToken)
        {

            try
            {
                await _tenantRepository.AddAsync(entity);
                await _unitOfWork.CommitAsync(cancellationToken);

            }
            catch   (Exception ex)
            {
                //Personalizar excepcion 
                throw new NotImplementedException();
            }
            return entity;
        }

        public async Task<IEnumerable<Tenant>> GetAll()
        {
          return await _tenantRepository.GetAllAsync();
        }

        public async Task<Tenant> GetById(int entityId)
        {
            return await _tenantRepository.GetByIdAsync(entityId);
        }
    }
}

