using KitchenBook.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using KitchenBook.Domain;

namespace KitchenBook.Infrastructure
{
    public class RecipeDbContext : DbContext
    {
        public DbSet<Recipe> Recipe { get; set; }

        public RecipeDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeConfiguration());
        }
    }
}
