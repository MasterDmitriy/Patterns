using DAL.Models;

namespace Patterns.Services
{
    public interface IService<TEntity>
        where TEntity : BaseEntity, new()
    {
        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(int entityId);
    }
}