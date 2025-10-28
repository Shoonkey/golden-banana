using GoldenBanana.Api.Dtos;
using GoldenBanana.Api.Dtos.Hideouts;
using GoldenBanana.Api.Infrastructure.Interfaces;
using GoldenBanana.Api.Infrastructure.Models;
using GoldenBanana.Api.Interfaces;

namespace GoldenBanana.Api.Services;

public class HideoutService(
    IHideoutRepository hideoutRepository,
    IHideoutMapRepository hideoutMapRepository,
    IHideoutTagRepository hideoutTagRepository) : IHideoutService
{
    private readonly IHideoutRepository _hideoutRepository = hideoutRepository;
    private readonly IHideoutMapRepository _hideoutMapRepository = hideoutMapRepository;
    private readonly IHideoutTagRepository _hideoutTagRepository = hideoutTagRepository;

    public async Task<PaginatedResponse<HideoutListItem>> GetFilteredAsync(
        int page,
        int pageSize,
        HideoutFilter? filters)
    {
        return await _hideoutRepository.GetFilteredAsync(
            page,
            pageSize,
            filters,
            h => new HideoutListItem(
                h.Id,
                h.Name,
                [.. h.Images.Select(i => new ImageDto(i.Url, i.Alt))],
                [.. h.Tags.Select(t => t.Tag)],
                h.Map,
                h.HasMTX,
                h.Rating,
                h.Author.Username,
                h.PoeVersion));
    }

    public async Task<IEnumerable<HideoutMap>> GetHideoutMaps()
    {
        return await _hideoutMapRepository.GetAllAsync();
    }

    public async Task<IEnumerable<HideoutTag>> GetHideoutTags()
    {
        return await _hideoutTagRepository.GetAllAsync();
    }
}
