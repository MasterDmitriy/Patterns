using DAL.Models;

namespace DAL.Repositories
{
    public interface IRepository<TEntity> : IChangeRepository<TEntity>, IReadOnlyRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        
    }

}