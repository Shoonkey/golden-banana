using GoldenBanana.Api.Infrastructure.Models;

namespace GoldenBanana.Api.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
