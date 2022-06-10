using KitchenBook.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using KitchenBook.Domain;

namespace KitchenBook.Infrastructure
{
    public class KitchenBookDbContext : DbContext
    {
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<User> User { get; set; }

        public KitchenBookDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
