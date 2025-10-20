using GoldenBanana.Dtos;
using GoldenBanana.Dtos.Hideouts;
using GoldenBanana.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenBanana.Infrastructure.Repositories;
public abstract class FilterableRepository<T>(AppDbContext context)
    : BaseRepository<T>(context) 
        where T : BaseEntity
{
    public async Task<PaginatedResponse<T2>> GetFilteredAsync<T2>(
        int page,
        int pageSize,
        Filter? filter,
        Func<T, T2> convertTo)
    {
        page = page < 1 ? 1 : page;
        pageSize = pageSize < 1 ? 16 : pageSize;

        var query = DefineNavigationProperties();

        query = Filter(query, filter);
        var totalCount = query.Count();

        query = query.Skip((page - 1) * pageSize).Take(pageSize);
        var res = await query.ToListAsync();
    
        return new PaginatedResponse<T2>
        {
            TotalCount = totalCount,
            Items = res.Select(convertTo)
        };
    }

    protected abstract IQueryable<T> Filter(IQueryable<T> query, Filter? filter);
    protected abstract IQueryable<T> DefineNavigationProperties();
}
