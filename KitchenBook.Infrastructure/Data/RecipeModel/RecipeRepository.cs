using KitchenBook.Domain;
using KitchenBook.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace KitchenBook.Infrastructure.Data.RecipeModel
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly KitchenBookDbContext _dbContext;

        public RecipeRepository(KitchenBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Recipe>> GetRecipeList()
        {
            return await _dbContext.Recipe.ToListAsync();
        }

        public async Task<Recipe> GetById(int id)
        {
            return await _dbContext.Recipe.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Recipe> Create(Recipe recipe)
        {
            var entity = await _dbContext.Recipe.AddAsync(recipe);
            return entity.Entity;
        }

        public async void Delete(Recipe recipe)
        {
            _dbContext.Recipe.Remove(recipe);
        }

        public async void Update(Recipe recipe)
        {
            _dbContext.Recipe.Update(recipe);
        }
    }
}
