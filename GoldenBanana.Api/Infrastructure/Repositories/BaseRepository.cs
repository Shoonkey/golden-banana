using GoldenBanana.Api.Dtos;
using GoldenBanana.Api.Infrastructure.Interfaces;
using GoldenBanana.Api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenBanana.Api.Infrastructure.Repositories;

public abstract class BaseRepository<T>(AppDbContext context) 
    where T : BaseEntity
{
    protected readonly DbSet<T> _dbSet = context.Set<T>();
    protected readonly AppDbContext _context = context;

    public async Task<T?> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty) return null;
        return await _dbSet.SingleOrDefaultAsync(obj => obj.Id == id);
    }

    public async Task<IEnumerable<T>> GetAllAsync() =>
        await _dbSet.ToListAsync();

    public void Create(T data) => _dbSet.Add(data);

    public void Update(T data) => _dbSet.Update(data);

    public async Task DeleteById(Guid id)
    {
        var dbObj = await GetByIdAsync(id);
        if (dbObj == null) return;

        _dbSet.Remove(dbObj);
    }

}
