namespace STEAMHOUSE.Infrastruture.Manager;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : class;
    Task<int> SaveChangesAsync();
}