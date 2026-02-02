using STEAMHOUSE.Infrastruture.Data;

namespace STEAMHOUSE.Infrastruture.Manager;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private Dictionary<Type, object>? _repositories;
    private bool _disposed;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : class
    {
        _repositories ??= new Dictionary<Type, object>();

        var type = typeof(TEntity);
        if (!_repositories.ContainsKey(type))
        {
            _repositories[type] = new Repository<TEntity, TKey>(_context);
        }

        return (IRepository<TEntity, TKey>)_repositories[type];
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _repositories?.Clear();
            _context.Dispose();
            _disposed = true;
        }
        GC.SuppressFinalize(this);
    }
}