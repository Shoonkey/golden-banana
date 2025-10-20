using GoldenBanana.Infrastructure.Models;

namespace GoldenBanana.Dtos.Hideouts;

public record HideoutListItem(
    Guid Id,
    string Name,
    string[] ImageUrls,
    HideoutTag[] Tags,
    HideoutMap Map,
    bool HasMTX,
    decimal Rating,
    string Author);
