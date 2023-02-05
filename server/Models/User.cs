using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models;

public class User : EntityBase
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = new byte[32];
    public byte[] PasswordSalt { get; set; } = new byte[32];

    public virtual IList<UserRole> UserRoles { get; set; }

}
