using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class UserRole : EntityBase
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public User? User { get; set; }
        public Role? Role { get; set; }
    }
}
