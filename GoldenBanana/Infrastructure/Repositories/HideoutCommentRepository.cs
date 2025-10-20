using GoldenBanana.Api.Infrastructure.Models;

namespace GoldenBanana.Api.Infrastructure.Repositories;

public class HideoutCommentRepository : BaseRepository<HideoutComment>
{
    private readonly AppDbContext _context;

    public HideoutCommentRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
