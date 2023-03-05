using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models;

public class User : EntityBase
{
    [Required]
    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    [Required]
    public string PasswordSalt { get; set; } = string.Empty;

    [Required]
    public int UserStatusId { get; set; }
    public UserStatus? UserStatus { get; set; }

    public virtual IList<UserRole> UserRoles { get; set; } = new List<UserRole>();

    [NotMapped]
    public string FullName
    {
        get => $"{FirstName} {LastName}";
    }
}
