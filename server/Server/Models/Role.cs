using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Role : EntityBase
    {
        public string Description { get; set; } = string.Empty;
    }
}
