using GoldenBanana.Dtos;
using GoldenBanana.Infrastructure.Interfaces;
using GoldenBanana.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenBanana.Infrastructure.Repositories;

public abstract class BaseRepository<T> where T : BaseEntity
{
    protected readonly DbSet<T> _dbSet;
    
    public BaseRepository(AppDbContext context)
    {
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty) return null;
        return await _dbSet.SingleOrDefaultAsync(obj => obj.Id == id);
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public void Create(T data) => _dbSet.Add(data);

    public void Update(T data) => _dbSet.Update(data);

    public async Task DeleteById(Guid id)
    {
        var dbObj = await GetByIdAsync(id);
        if (dbObj == null) return;

        _dbSet.Remove(dbObj);
    }

}
