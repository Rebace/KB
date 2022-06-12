using System.ComponentModel.DataAnnotations;

namespace KitchenBook.Api.MessageContracts;

public class LoginDto
{
    [Required]
    public string Login { get; set; }

    [Required]
    public string Password { get; set; }
    public string Name { get; set; }
}
