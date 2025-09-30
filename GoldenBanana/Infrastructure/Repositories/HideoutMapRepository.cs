using GoldenBanana.Infrastructure.Models;

namespace GoldenBanana.Infrastructure.Repositories;

public class HideoutMapRepository : BaseRepository<HideoutMap>
{
    private readonly AppDbContext _context;

    public HideoutMapRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
