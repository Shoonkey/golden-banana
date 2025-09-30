using GoldenBanana.Infrastructure.Models;

namespace GoldenBanana.Infrastructure.Repositories;

public class HideoutChangelogEntryRepository : BaseRepository<HideoutChangelogEntry>
{
    private readonly AppDbContext _context;

    public HideoutChangelogEntryRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
