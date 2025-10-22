using GoldenBanana.Api.Infrastructure.Interfaces;
using GoldenBanana.Api.Infrastructure.Models;

namespace GoldenBanana.Api.Infrastructure.Repositories;

public class HideoutMapRepository(AppDbContext context)
    : BaseRepository<HideoutMap>(context), IHideoutMapRepository
{
}
