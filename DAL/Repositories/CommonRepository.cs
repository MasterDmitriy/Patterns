using DAL.Models;

namespace DAL.Repositories
{
    public class CommonRepository<TEntity> : BaseRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        
    }
}