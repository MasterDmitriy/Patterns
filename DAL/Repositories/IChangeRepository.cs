using DAL.Models;

namespace DAL.Repositories
{
    public interface IChangeRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        void DeleteById(int id);
    }
}