using DAL.Models;
using DAL.Repositories;

namespace Patterns.Factories
{
    public interface IRepositoryFactory
    {
        IRepository<Brand> BrandRepository => new BaseRepository<Brand>();

        IRepository<BrandType> BrandTypeRepository => new BaseRepository<BrandType>();

        IRepository<Category> CategoryRepository => new BaseRepository<Category>();

        IRepository<Product> ProductRepository => new BaseRepository<Product>();
    }
}