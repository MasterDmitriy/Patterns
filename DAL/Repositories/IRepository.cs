using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        void DeleteById(int id);
    }

}