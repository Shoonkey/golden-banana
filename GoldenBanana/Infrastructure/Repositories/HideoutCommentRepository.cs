using GoldenBanana.Infrastructure.Models;

namespace GoldenBanana.Infrastructure.Repositories;

public class HideoutCommentRepository : BaseRepository<HideoutComment>
{
    private readonly AppDbContext _context;

    public HideoutCommentRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
