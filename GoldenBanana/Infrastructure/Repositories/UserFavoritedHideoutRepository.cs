using GoldenBanana.Infrastructure.Models;

namespace GoldenBanana.Infrastructure.Repositories;

public class UserFavoritedHideoutRepository : BaseRepository<UserFavoritedHideout>
{
    private readonly AppDbContext _context;

    public UserFavoritedHideoutRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}

