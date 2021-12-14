using System.Collections.Generic;
using DAL.Models;

namespace Patterns.Builders
{
    public class BrandTypeBuilder : Builder<BrandType>
    {
        public BrandTypeBuilder()
        {
            
        }

        public BrandTypeBuilder(BrandType brandType)
            : base(brandType)
        {

        }

        public BrandTypeBuilder AddName(string name)
        {
            Entity.Name = name;

            return this;
        }

        public BrandTypeBuilder AddBrand(Brand brand)
        {
            Entity.Brands ??= new List<Brand>();
            Entity.Brands.Add(brand);

            return this;
        }
    }
}