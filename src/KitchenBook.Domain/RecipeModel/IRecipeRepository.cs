using KitchenBook.Domain;

namespace KitchenBook.Infrastructure.Repository
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetRecipeList();
        Task<Recipe> GetById(int id);
        Task<Recipe> Create(Recipe recipe);
        void Delete(Recipe recipe);
        void Update(Recipe recipe);
    }
}
