using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Server.Auth
{
    public class CustomIdentity : ClaimsIdentity
    {
        public long AgencyId { get; set; }
        public long UserId { get; set; }

        public CustomIdentity(IEnumerable<Claim> claims, string authenticationType)
            : base(claims, authenticationType) { }
    }
}
