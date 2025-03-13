using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using UserRegister.Domain.Commons;

namespace UserRegister.Domain.Entities;

public class User : Auditable
{
    [Required, NotNull]
    public string Firstname { get; set; }
    public string Lastname { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
}
