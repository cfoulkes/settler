using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class ReferenceBase : EntityBase
    {
        public string Description { get; set; } = string.Empty;
    }
}
