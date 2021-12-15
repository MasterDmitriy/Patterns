using DAL.Models;
using DAL.Repositories;

namespace Patterns.Factories
{
    public interface IObservableRepositoryFactory<TEntity>
        where TEntity : BaseEntity, new()
    {
        IObservableRepository<TEntity> Repository { get; }
    }
}