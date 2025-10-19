using Microsoft.EntityFrameworkCore;

using GoldenBanana.Dtos;
using GoldenBanana.Infrastructure.Models;

namespace GoldenBanana.Infrastructure.Repositories;
public abstract class FilterableRepository<T> : BaseRepository<T> where T : BaseEntity
{
    public FilterableRepository(AppDbContext context) : base(context)
    { }

    public async Task<IEnumerable<T>> GetFilteredAsync(int page, int pageSize, Filter filter)
    {
        var query = Filter(filter);
        query.Skip((page - 1) * pageSize).Take(pageSize);
        return await query.ToListAsync();
    }
    protected abstract IQueryable<T> Filter(Filter filter);
}
