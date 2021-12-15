using DAL.Models;
using DAL.Observers;
using DAL.Repositories;
using Patterns.Factories;

namespace Patterns.Services
{
    public class CommonService<TEntity> : IService<TEntity>
        where TEntity : BaseEntity, new()
    {
        private readonly IObservableRepository<TEntity> _observableRepository;

        public CommonService()
        {
            var observableRepositoryFactory = new ObservableRepositoryFactory<TEntity>();
            _observableRepository = observableRepositoryFactory.Repository;
        }

        public TEntity Add(TEntity entity)
        {
            var observer = new InsertObserver<TEntity>();
            _observableRepository.RegisterObserver(observer);

            var result = _observableRepository.Add(entity);

            _observableRepository.RemoveObserver(observer);
            return result;
        }

        public void Update(TEntity entity)
        {
            var observer = new UpdateObserver<TEntity>();
            _observableRepository.RegisterObserver(observer);

            _observableRepository.Update(entity);

            _observableRepository.RemoveObserver(observer);
        }

        public void Delete(int entityId)
        {
            var observer = new RemoveObserver<TEntity>();
            _observableRepository.RegisterObserver(observer);

            _observableRepository.DeleteById(entityId);

            _observableRepository.RemoveObserver(observer);
        }
    }
}