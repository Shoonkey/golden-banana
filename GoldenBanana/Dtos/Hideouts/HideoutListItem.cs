using GoldenBanana.Api.Infrastructure.Models;

namespace GoldenBanana.Api.Dtos.Hideouts;

public record HideoutListItem(
    Guid Id,
    string Name,
    string[] ImageUrls,
    HideoutTag[] Tags,
    HideoutMap Map,
    bool HasMTX,
    decimal Rating,
    string Author);
