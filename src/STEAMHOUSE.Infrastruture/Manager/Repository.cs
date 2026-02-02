using Microsoft.EntityFrameworkCore;
using STEAMHOUSE.Infrastruture.Data;

namespace STEAMHOUSE.Infrastruture.Manager;

public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();
    public async Task<TEntity?> GetByIdAsync(TKey id) => await _dbSet.FindAsync(id);
    public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);
    public async Task UpdateAsync(TEntity entity) =>  _dbSet.Update(entity);
    public async Task Delete(TEntity entity) => _dbSet.Remove(entity);
}