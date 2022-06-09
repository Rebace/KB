namespace KitchenBook.Api.MessageContracts.UserModel;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
    public string Description { get; set; }
}
