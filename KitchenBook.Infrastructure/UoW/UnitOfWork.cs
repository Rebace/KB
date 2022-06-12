namespace KitchenBook.Infrastructure.UoF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KitchenBookDbContext _kitchenBookDbContext;

        public UnitOfWork(KitchenBookDbContext kitchenBookDbContext)
        {
            _kitchenBookDbContext = kitchenBookDbContext;
        }

        public void Commit()
        {
            _kitchenBookDbContext.SaveChanges();
        }
    }
}
