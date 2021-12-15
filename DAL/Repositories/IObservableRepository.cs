using DAL.Models;
using DAL.Observers;

namespace DAL.Repositories
{
    public interface IObservableRepository<TEntity> : IRepository<TEntity>, IObservable<TEntity>
        where TEntity : BaseEntity, new()
    {
        
    }
}