using GoldenBanana.Api.Infrastructure.Models;

namespace GoldenBanana.Api.Infrastructure.Repositories;

public class UserFavoritedHideoutRepository(AppDbContext context) : BaseRepository<UserFavoritedHideout>(context)
{
}

