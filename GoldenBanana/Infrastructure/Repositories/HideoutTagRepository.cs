using GoldenBanana.Infrastructure.Models;

namespace GoldenBanana.Infrastructure.Repositories;

public class HideoutTagRepository : BaseRepository<HideoutTag>
{
    private readonly AppDbContext _context;

    public HideoutTagRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}

