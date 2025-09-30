using GoldenBanana.Infrastructure.Models;

namespace GoldenBanana.Infrastructure.Repositories;

public class HideoutRepository : BaseRepository<Hideout>
{
    private readonly AppDbContext _context;

    public HideoutRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
