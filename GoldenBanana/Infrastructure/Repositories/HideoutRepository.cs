using GoldenBanana.Dtos;
using GoldenBanana.Dtos.Hideouts;
using GoldenBanana.Infrastructure.Interfaces;
using GoldenBanana.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenBanana.Infrastructure.Repositories;

public class HideoutRepository(AppDbContext context) 
    : FilterableRepository<Hideout>(context), IHideoutRepository
{
    protected override IQueryable<Hideout> DefineNavigationProperties() =>
        _dbSet.Include(h => h.Map)
        .Include(h => h.Author);

    protected override IQueryable<Hideout> Filter(
        IQueryable<Hideout> query,
        Filter? filter)
    {
        if (filter == null || filter is not HideoutFilter parsedFilter)
        {
            return query;
        }

        if (parsedFilter.Name != null)
        {
            query = query.Where(h => h.Name.Contains(parsedFilter.Name));
        }
        if (parsedFilter.PoeVersion != null)
        {
            query = query.Where(h => h.PoeVersion == parsedFilter.PoeVersion);
        }
        if (parsedFilter.HasMTX != null)
        {
            query = query.Where(h => h.HasMTX == parsedFilter.HasMTX);
        }

        return query;
    }
}
