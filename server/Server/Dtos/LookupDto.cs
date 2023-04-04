using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Dtos;

public class LookupDto
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
}
