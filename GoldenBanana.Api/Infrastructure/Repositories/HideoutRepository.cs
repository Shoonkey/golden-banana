using GoldenBanana.Api.Dtos;
using GoldenBanana.Api.Dtos.Hideouts;
using GoldenBanana.Api.Infrastructure.Interfaces;
using GoldenBanana.Api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenBanana.Api.Infrastructure.Repositories;

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
        if (parsedFilter.MapIds != null)
        {
            query = query.Where(h => parsedFilter.MapIds.Contains(h.HideoutMapId));
        }
        if (parsedFilter.Tags != null)
        {
            query = query.Where(h => h.Tags.Any(t => parsedFilter.Tags.Contains(t.Id)));
        }

        return query;
    }
}
