using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models;

public class UserProfile : EntityBase
{
    [Required]
    public string LanguagePreference { get; set; } = string.Empty;

    [Required]
    public int AgencyId { get; set; }
    public Agency? Agency { get; set; }
}
