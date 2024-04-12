using QuarterlySalesApp.Models.DomainModels;

namespace QuarterlySalesApp.Models.DataLayer.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        int Complete();
    }
}

