namespace KitchenBook.Infrastructure.UoF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RecipeDbContext _recipeDbContext;
        private readonly UserDbContext _userDbContext;

        public UnitOfWork(RecipeDbContext recipeDbContext, UserDbContext userDbContext)
        {
            _recipeDbContext = recipeDbContext;
            _userDbContext = userDbContext;
        }

        public void Commit()
        {
            _recipeDbContext.SaveChanges();
            _userDbContext.SaveChanges();
        }
    }
}
