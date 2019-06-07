using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LamdaForums.data
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int? id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> prdicate);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);

    }
}
