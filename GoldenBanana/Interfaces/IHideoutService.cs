using GoldenBanana.Dtos.Hideouts;

namespace GoldenBanana.Interfaces
{
    public interface IHideoutService
    {
        Task<PaginatedResponse<HideoutListItem>> GetFilteredAsync(
            int page,
            int pageSize,
            HideoutFilter? filters);
    }
}
