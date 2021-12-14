using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BrandTypeId { get; set; }

        public BrandType BrandType { get; set; }

        public IList<Product> Products { get; set; }
    }
}