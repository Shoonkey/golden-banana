using GoldenBanana.Api.Infrastructure.Models;

namespace GoldenBanana.Api.Infrastructure.Repositories;

public class HideoutTagRepository : BaseRepository<HideoutTag>
{
    private readonly AppDbContext _context;

    public HideoutTagRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}

