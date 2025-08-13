using System.ComponentModel.DataAnnotations;

namespace storeapi.Dtos.Auth;

public class RegisterDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}