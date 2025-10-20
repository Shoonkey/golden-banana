using GoldenBanana.Api.Infrastructure.Models;

namespace GoldenBanana.Api.Infrastructure.Repositories;

public class HideoutMapRepository : BaseRepository<HideoutMap>
{
    private readonly AppDbContext _context;

    public HideoutMapRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
