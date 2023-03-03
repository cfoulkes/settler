using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models;

public class Agency : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int NumberOfLicences { get; set; }

    public int AgencyStatusId { get; set; }
    public AgencyStatus? AgencyStatus { get; set; }
    public virtual IList<UserProfile> Users { get; set; } = new List<UserProfile>();
}
