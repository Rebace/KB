using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenBook.Infrastructure
{
    public class DbInitializer
    {
        public static void Initialize(RecipeDbContext recipeDbContext, UserDbContext userDbContext)
        {
            recipeDbContext.Database.EnsureCreated();
            userDbContext.Database.EnsureCreated();
        }
    }
}
