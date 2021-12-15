using DAL.Models;
using DAL.Repositories;

namespace Patterns.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IRepository<Brand> BrandRepository => new CommonRepository<Brand>();

        public IRepository<BrandType> BrandTypeRepository => new CommonRepository<BrandType>();

        public IRepository<Category> CategoryRepository => new CommonRepository<Category>();

        public IRepository<Product> ProductRepository => new CommonRepository<Product>();

        public IRepository<Role> RoleRepository => new CommonRepository<Role>();

        public IRepository<User> UserRepository => new CommonRepository<User>();
    }
}