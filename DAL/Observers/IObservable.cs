using DAL.Models;

namespace DAL.Observers
{
    public interface IObservable<out TEntity>
        where TEntity : BaseEntity
    {
        void RegisterObserver(IObserver<TEntity> o);
        void RemoveObserver(IObserver<TEntity> o);
        void NotifyObservers();
    }
}