using GoldenBanana.Api.Dtos;
using GoldenBanana.Api.Dtos.Hideouts;
using GoldenBanana.Api.Infrastructure.Interfaces;
using GoldenBanana.Api.Infrastructure.Models;
using GoldenBanana.Api.Interfaces;

namespace GoldenBanana.Api.Services;

public class HideoutService(
    IHideoutRepository hideoutRepository,
    IHideoutMapRepository hideoutMapRepository,
    IHideoutTagRepository hideoutTagRepository,
    IFileStorage storage,
    IUserService userService) : IHideoutService
{
    private readonly IHideoutRepository _hideoutRepository = hideoutRepository;
    private readonly IHideoutMapRepository _hideoutMapRepository = hideoutMapRepository;
    private readonly IHideoutTagRepository _hideoutTagRepository = hideoutTagRepository;
    private readonly IFileStorage _storage = storage;
    private readonly IUserService _userService = userService;

    public async Task<Hideout?> CreateAsync(string username, CreateHideoutDto dto)
    {
        var id = Guid.NewGuid();
        var user = await _userService.GetByUsernameAsync(username);
        if (user == null)
        {
            return null;
        }

        var hideout = CreateHideout(dto, id, user.Id);

        try
        {
            foreach (var formFile in dto.Images)
            {
                var images = await SaveImageVersions(formFile);
                hideout.Images.Add(images[0]);
                hideout.Images.Add(images[1]);
            }

            return hideout;
        }
        catch (Exception)
        {
            _storage.Rollback();
            return null;
        }
    }

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
                h.HasMtx,
                h.Rating,
                h.Author.Username,
                h.PoeVersion));
    }

    public async Task<IEnumerable<HideoutMap>> GetHideoutMapsAsync()
    {
        return await _hideoutMapRepository.GetAllAsync();
    }

    public async Task<IEnumerable<HideoutTag>> GetHideoutTagsAsync()
    {
        return await _hideoutTagRepository.GetAllAsync();
    }

    private async Task<HideoutImage[]> SaveImageVersions(IFormFile image)
    {
        using var stream = image.OpenReadStream();

        var thumbnailId = Guid.NewGuid();
        var thumbnailImage = await SaveImage(thumbnailId, true, stream);
        stream.Position = 0;

        var originalId = Guid.NewGuid();
        var originalImage = await SaveImage(originalId, false, stream);

        return
        [
            thumbnailImage,
            originalImage
        ];
    }

    private async Task<HideoutImage> SaveImage(Guid id, bool isThumbnail, Stream stream)
    {
        var url = await _storage.SaveImageAsync(id, isThumbnail, stream) ??
            throw new ApplicationException("Error while saving image.");

        return new HideoutImage()
        {
            Id = id,
            Url = url,
            IsThumbnail = isThumbnail
        };
    }

    private static Hideout CreateHideout(CreateHideoutDto dto, Guid id, Guid userId) => new()
    {
        Id = id,
        Name = dto.Name,
        PoeVersion = dto.PoeVersion,
        Description = dto.Description,
        HasMtx = dto.HasMtx,
        UserId = userId,
        Tags = [.. dto.TagIds.Select(t => new HideoutHideoutTag()
        {
            HideoutId = id,
            HideoutTagId = t
        })]
    };
}
