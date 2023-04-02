using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Dtos;

public class AgencyDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int NumberOfLicences { get; set; }
    public int AgencyStatusId { get; set; }
    public uint RowVer { get; set; }
}
