using DAL.Models;
using DAL.Repositories;

namespace Patterns.Factories
{
    public class ObservableRepositoryFactory<TEntity> : IObservableRepositoryFactory<TEntity>
        where TEntity : BaseEntity, new()
    {
        public IObservableRepository<TEntity> Repository => new ObservableRepository<TEntity>();
    }
}