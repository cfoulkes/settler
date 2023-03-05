using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Dtos;

public class CreateUserDto
{
    [Required]
    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
}
