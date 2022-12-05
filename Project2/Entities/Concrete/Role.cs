using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Role: BaseEntity
    {
        public string Definition { get; set; }
        public List<UserRole> Roles { get; set; }

    }
}
