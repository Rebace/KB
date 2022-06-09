using System.Security.Cryptography;
using System.Text;
using KitchenBook.Domain.UserModel;
using Microsoft.EntityFrameworkCore;

namespace KitchenBook.Infrastructure.Data.UserModel;

public class UserRepository : IUserRepository
{
    private readonly KitchenBookDbContext _dbContext;

    public UserRepository(KitchenBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetById(int id)
    {
        return await _dbContext.User.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User> GetByLogin(string login)
    {
        return await _dbContext.User.SingleOrDefaultAsync(x => x.Login == login);
    }

    public async Task<User> Add(User user)
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
            sb.Append(bytes[i].ToString("x2"));
        }

        return sb.ToString();
    }
}
