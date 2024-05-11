using HamburguesitoNet.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HamburguesitoNet.Application.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task ReloadEntityAsync(TEntity entity);

        #region Métodos asincrónicos
        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> GetByIdAsync(ISpecification<TEntity> specification);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetManyAsync(ISpecification<TEntity> specification);

        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetByConditionAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByConditionAsync(ISpecification<TEntity> specification);

        Task AddAsync(TEntity entity);

        Task AddRangeAsync(TEntity entity);
        #endregion

        #region Métodos sincrónicos
        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate);

        TEntity GetByCondition(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void AddRange(TEntity entity);

        void Update(TEntity entity);

        void UpdateRange(TEntity entity);

        void Remove (TEntity entity);
        #endregion
    }
}
