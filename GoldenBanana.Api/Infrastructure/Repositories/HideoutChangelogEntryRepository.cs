using GoldenBanana.Api.Infrastructure.Models;

namespace GoldenBanana.Api.Infrastructure.Repositories;

public class HideoutChangelogEntryRepository(AppDbContext context) : BaseRepository<HideoutChangelogEntry>(context)
{
}
