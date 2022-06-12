using System.Security.Cryptography;
using System.Text;
using KitchenBook.Domain.AuthenticateModel;
using KitchenBook.Domain.UserModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KitchenBook.Infrastructure.Data.UserModel;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public UserRepository(UserDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    public async Task<User> Authenticate(AuthenticateRequest model)
    {
        var user = await _dbContext.User.SingleOrDefaultAsync(x =>
            x.Login == model.Login && Hashing.ToSHA256(x.Password) == model.Password);

        if (user == null)
        {
            return null;
        }

        var token = Guid.NewGuid().ToString();

        return new User(user.Name, user.Login, user.Password, user.Description, token);
    }

    public async Task<User> GetById(int id)
    {
        return await _dbContext.User.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User> GetByLogin(string login)
    {
        return await _dbContext.User.SingleOrDefaultAsync(x => x.Login == login);
    }

    public async Task<User> Register(User user)
    {
        var entity = await _dbContext.User.AddAsync(user);
        return entity.Entity;
    }

    public void Update(User user)
    {
        _dbContext.User.Update(user);
    }
}

public static class Hashing
{
    public static string ToSHA256(string s)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));

        var sb = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            sb.Append(bytes[i].ToString("SecredHashing123"));
        }

        return sb.ToString();
    }
}
