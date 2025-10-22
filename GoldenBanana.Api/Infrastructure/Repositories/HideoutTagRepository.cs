using GoldenBanana.Api.Infrastructure.Interfaces;
using GoldenBanana.Api.Infrastructure.Models;

namespace GoldenBanana.Api.Infrastructure.Repositories;

public class HideoutTagRepository(AppDbContext context)
    : BaseRepository<HideoutTag>(context), IHideoutTagRepository
{
}

