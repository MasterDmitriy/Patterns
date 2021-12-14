using System.Collections.Generic;
using DAL.Models;

namespace Patterns.Builders
{
    public class CategoryBuilder : Builder<Category>
    {
        public CategoryBuilder()
        {
            
        }

        public CategoryBuilder(Category brandType)
            : base(brandType)
        {

        }

        public CategoryBuilder AddName(string name)
        {
            Entity.Name = name;

            return this;
        }

        public CategoryBuilder AddProduct(Product product)
        {
            Entity.Products ??= new List<Product>();
            Entity.Products.Add(product);

            return this;
        }
    }
}