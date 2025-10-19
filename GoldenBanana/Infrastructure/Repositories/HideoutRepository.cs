using GoldenBanana.Dtos;
using GoldenBanana.Infrastructure.Interfaces;
using GoldenBanana.Infrastructure.Models;

namespace GoldenBanana.Infrastructure.Repositories;

public class HideoutRepository : FilterableRepository<Hideout>, IHideoutRepository
{
    private readonly AppDbContext _context;

    public HideoutRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    protected override IQueryable<Hideout> Filter(Filter filter)
    {
        // TODO: Implement hideout filtering based on filter
        throw new NotImplementedException("Hideout filters not implemented yet");
    }
}
