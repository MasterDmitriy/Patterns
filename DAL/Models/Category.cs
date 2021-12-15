using System.Collections.Generic;

namespace DAL.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public IList<Product> Products { get; set; }
    }
}