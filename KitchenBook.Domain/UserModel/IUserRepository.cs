using KitchenBook.Domain.AuthenticateModel;

namespace KitchenBook.Domain.UserModel;

public interface IUserRepository
{
    Task<User> Authenticate(AuthenticateRequest model);
    Task<User> Register(User user);

    Task<User> GetById(int id);
    Task<User> GetByLogin(string login);
    void Update(User user);
}
