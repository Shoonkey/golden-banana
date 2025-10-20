using GoldenBanana.Api.Infrastructure.Models;

namespace GoldenBanana.Api.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context)
{
}
