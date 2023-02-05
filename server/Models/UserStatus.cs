using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class UserStatus : EntityBase
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
