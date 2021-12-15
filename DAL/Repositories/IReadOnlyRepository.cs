using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Models;

namespace DAL.Repositories
{
    public interface IReadOnlyRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);
    }
}