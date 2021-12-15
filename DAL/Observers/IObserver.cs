using DAL.Models;

namespace DAL.Observers
{
    public interface IObserver<in T>
        where T : BaseEntity
    {
        void Update(T entity);
    }
}