using GoldenBanana.Api.Dtos.Hideouts;

namespace GoldenBanana.Api.Interfaces
{
    public interface IHideoutService
    {
        Task<PaginatedResponse<HideoutListItem>> GetFilteredAsync(
            int page,
            int pageSize,
            HideoutFilter? filters);
    }
}
