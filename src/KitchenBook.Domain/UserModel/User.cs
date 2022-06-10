namespace KitchenBook.Domain;

public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Login { get; private set; }
    public string Token { get; set; }
    public string Password { get; private set; }
    public string Description { get; private set; }

    // Workaround for EF
    protected User()
    {
    }

    public User(string name, string login, string password, string description, string token)
    {
        Name = name;
        Token = token;
        Login = login;
        Password = password;
        Description = description;
    }
}
