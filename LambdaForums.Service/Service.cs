using LamdaForums.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LambdaForums.Service
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _entities;
        protected readonly DbContext Context;
        public Service(DbContext context)
        {
            Context = context;
            _entities = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
           await _entities.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> prdicate)
        {
            return _entities.Where(prdicate);
        }

        public async Task<TEntity> GetAsync(int? id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }
    }
}
