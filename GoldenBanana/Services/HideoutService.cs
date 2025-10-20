using GoldenBanana.Api.Dtos.Hideouts;
using GoldenBanana.Api.Infrastructure.Interfaces;
using GoldenBanana.Api.Interfaces;

namespace GoldenBanana.Api.Services;

public class HideoutService(
    IHideoutRepository repository) : IHideoutService
{
    private readonly IHideoutRepository _repository = repository;

    public async Task<PaginatedResponse<HideoutListItem>> GetFilteredAsync(
        int page,
        int pageSize,
        HideoutFilter? filters)
    {
        return await _repository.GetFilteredAsync(
            page,
            pageSize,
            filters,
            h => new HideoutListItem(
                h.Id,
                h.Name,
                [.. h.Images.Select(i => i.Url)],
                [.. h.Tags],
                h.Map,
                h.HasMTX,
                h.Rating,
                h.Author.Username));
    }
}
