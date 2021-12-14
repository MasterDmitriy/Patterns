using DAL.Models;
using DAL.Repositories;

namespace Patterns.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IRepository<Brand> BrandRepository => new BaseRepository<Brand>();

        public IRepository<BrandType> BrandTypeRepository => new BaseRepository<BrandType>();

        public IRepository<Category> CategoryRepository => new BaseRepository<Category>();

        public IRepository<Product> ProductRepository => new BaseRepository<Product>();
    }
}