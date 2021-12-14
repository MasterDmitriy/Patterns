using System.Collections.Generic;

namespace DAL.Models
{
    public class BrandType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Brand> Brands { get; set; }
    }
}