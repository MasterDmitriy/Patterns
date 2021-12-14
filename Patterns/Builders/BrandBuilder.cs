using System.Collections.Generic;
using System.Linq;
using DAL.Models;

namespace Patterns.Builders
{
    public class BrandBuilder : Builder<Brand>
    {
        public BrandBuilder()
        {

        }

        public BrandBuilder(Brand brand)
            : base(brand)
        {

        }

        public BrandBuilder AddName(string name)
        {
            Entity.Name = name;

            return this;
        }

        public BrandBuilder AddBrandType(BrandType brandType)
        {
            Entity.BrandType = brandType;

            return this;
        }

        public BrandBuilder AddProduct(Product product)
        {
            Entity.Products ??= new List<Product>();
            Entity.Products.Add(product);

            return this;
        }

        public BrandBuilder AddBrandTypeId(int brandTypeId)
        {
            Entity.BrandTypeId = brandTypeId;

            return this;
        }
    }
}