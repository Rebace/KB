using KitchenBook.Domain.UserModel;
using KitchenBook.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace KitchenBook.Infrastructure;

public class UserDbContext : DbContext
{
    public DbSet<User> User { get; set; }

    public UserDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
