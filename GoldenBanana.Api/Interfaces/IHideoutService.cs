using GoldenBanana.Api.Dtos.Hideouts;
using GoldenBanana.Api.Infrastructure.Models;

namespace GoldenBanana.Api.Interfaces;

public interface IHideoutService
{
    Task<PaginatedResponse<HideoutListItem>> GetFilteredAsync(
        int page,
        int pageSize,
        HideoutFilter? filters);
    Task<IEnumerable<HideoutMap>> GetHideoutMaps();
    Task<IEnumerable<HideoutTag>> GetHideoutTags();
}
