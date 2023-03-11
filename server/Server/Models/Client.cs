using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Client : EntityBase
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public DateOnly? DateOfBirth { get; set; }

        [Required]
        public int AgencyId { get; set; }
        public Agency? Agency { get; set; }
    }
}
