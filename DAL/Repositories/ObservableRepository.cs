using System.Collections.Generic;
using DAL.Models;
using DAL.Observers;

namespace DAL.Repositories
{
    public class ObservableRepository<TEntity> : BaseRepository<TEntity>, IObservableRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        private TEntity _entity;

        private readonly IList<IObserver<TEntity>> _observers;

        public ObservableRepository()
        {
            _observers = new List<IObserver<TEntity>>();
        }

        public void NotifyObservers()
        {
            foreach (var o in _observers)
            {
                o.Update(_entity);
            }
        }

        public void RegisterObserver(IObserver<TEntity> o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver<TEntity> o)
        {
            _observers.Remove(o);
        }

        public override TEntity Add(TEntity entity)
        {
            var addedEntity = base.Add(entity);
            _entity = addedEntity;
            NotifyObservers();
            return addedEntity;
        }

        public override void Update(TEntity entity)
        {
            base.Update(entity);
            _entity = entity;
            NotifyObservers();
        }

        public override void DeleteById(int id)
        {
            base.DeleteById(id);
            _entity = new TEntity {Id = id};
            NotifyObservers();
        }
    }
}