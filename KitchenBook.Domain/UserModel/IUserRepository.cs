namespace KitchenBook.Domain.UserModel;

public interface IUserRepository
{
    Task<User> Add(User user);

    Task<User> GetById(int id);
    Task<User> GetByLogin(string login);
    void Update(User user);
}
