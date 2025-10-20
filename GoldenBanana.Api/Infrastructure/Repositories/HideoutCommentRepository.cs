using GoldenBanana.Api.Infrastructure.Models;

namespace GoldenBanana.Api.Infrastructure.Repositories;

public class HideoutCommentRepository(AppDbContext context) : BaseRepository<HideoutComment>(context)
{
}
