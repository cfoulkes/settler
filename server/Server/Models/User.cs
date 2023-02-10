using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models;

public class User : EntityBase
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string PasswordSalt { get; set; } = string.Empty;

    public int UserStatusId { get; set; }
    public UserStatus? UserStatus { get; set; }
    public virtual IList<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
