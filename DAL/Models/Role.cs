using System.Collections.Generic;

namespace DAL.Models
{
    public class Role : BaseEntity
    {
        public RoleType Type { get; set; }

        public IList<User> Users { get; set; }
    }
}