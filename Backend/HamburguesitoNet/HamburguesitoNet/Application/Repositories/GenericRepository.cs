using HamburguesitoNet.Application.Common.Interfaces;
using HamburguesitoNet.Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HamburguesitoNet.Application.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public readonly IUnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task ReloadEntityAsync(TEntity entity)
        {
            return _unitOfWork.Context.ReloadEntityAsync(entity);
        }

        #region Métodos asincrónicos
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _unitOfWork.Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(ISpecification<TEntity> specification)
        {
            var queryableResult = QueryableResult(specification);

            return await queryableResult
                    .FirstOrDefaultAsync(specification.Criteria);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _unitOfWork.Context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync(ISpecification<TEntity> specification)
        {
            var queryableResult = QueryableResult(specification);

            return await queryableResult
                    .Where(specification.Criteria).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _unitOfWork.Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetByConditionAsync(ISpecification<TEntity> specification)
        {
            var queryableResult = QueryableResult(specification);

            return await queryableResult
                    .FirstOrDefaultAsync(specification.Criteria);
        }

        public async Task<TEntity> GetByConditionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _unitOfWork.Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _unitOfWork.Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(TEntity entity)
        {
            await _unitOfWork.Context.Set<TEntity>().AddRangeAsync(entity);
        }

        #endregion

        #region Métodos sincrónicos
        public TEntity GetById(int id)
        {
            return _unitOfWork.Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _unitOfWork.Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.Context.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity GetByCondition(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            _unitOfWork.Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(TEntity entity)
        {
            _unitOfWork.Context.Set<TEntity>().AddRange(entity);
        }

        public void Update(TEntity entity)
        {
            _unitOfWork.Context.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(TEntity entity)
        {
            _unitOfWork.Context.Set<TEntity>().UpdateRange(entity);
        }

        public void Remove(TEntity entity)
        {
            _unitOfWork.Context.Set<TEntity>().Remove(entity);
        }

        #endregion

        private IQueryable<TEntity> QueryableResult(ISpecification<TEntity> specification)
        {
            var queryableResultWithIncludes = specification.Includes
                .Aggregate(_unitOfWork.Context.Set<TEntity>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = specification.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            return secondaryResult;
        }
    }
}