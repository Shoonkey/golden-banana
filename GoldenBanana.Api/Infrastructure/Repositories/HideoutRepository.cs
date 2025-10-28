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
        _dbSet
            .Include(h => h.Map)
            .Include(h => h.Author)
            .Include(h => h.Images)
            .Include(h => h.Tags).ThenInclude(ht => ht.Tag);

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
        if (parsedFilter.TagIds != null)
        {
            query = query.Where(h => h.Tags.Any(t => parsedFilter.TagIds.Contains(t.HideoutTagId)));
        }
        if (parsedFilter.Author != null)
        {
            query = query.Where(h => h.Author.Username == parsedFilter.Author);
        }

        return query;
    }
}
