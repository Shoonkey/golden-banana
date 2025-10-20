using GoldenBanana.Api.Infrastructure.Models;

namespace GoldenBanana.Api.Infrastructure.Repositories;

public class HideoutChangelogEntryRepository : BaseRepository<HideoutChangelogEntry>
{
    private readonly AppDbContext _context;

    public HideoutChangelogEntryRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
