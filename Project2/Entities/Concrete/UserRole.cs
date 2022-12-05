using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserRole:BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; } // ilişki için

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
