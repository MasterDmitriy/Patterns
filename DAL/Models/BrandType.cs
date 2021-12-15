using System.Collections.Generic;

namespace DAL.Models
{
    public class BrandType : BaseEntity
    {
        public string Name { get; set; }

        public IList<Brand> Brands { get; set; }
    }
}