using System.ComponentModel.DataAnnotations;

namespace KitchenBook.Domain.AuthenticateModel;

public class AuthenticateRequest
{
    [Required]
    public string Login { get; set; }

    [Required]
    public string Password { get; set; }
}
