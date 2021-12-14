using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        private readonly DbSet<TEntity> _entities;
        private readonly DbContext _dbContext;

        public BaseRepository()
        {
            _dbContext = SingletonContext.Context;
            _entities = _dbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            var result = _entities.Add(entity);
            _dbContext.SaveChanges();

            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.State = EntityState.Detached);

            return result.Entity;
        }

        public TEntity GetById(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entity = GetById(id);
            _dbContext.Remove(entity);

            _dbContext.SaveChanges();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _entities.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }

}