using DAL.Models;
using DAL.Repositories;

namespace Patterns.Factories
{
    public interface IRepositoryFactory
    {
        IRepository<Brand> BrandRepository { get; }

        IRepository<BrandType> BrandTypeRepository { get; }

        IRepository<Category> CategoryRepository { get; }

        IRepository<Product> ProductRepository { get; }
    }
}