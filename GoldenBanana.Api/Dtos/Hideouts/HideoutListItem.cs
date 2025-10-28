using GoldenBanana.Api.Enums;
using GoldenBanana.Api.Infrastructure.Models;

namespace GoldenBanana.Api.Dtos.Hideouts;

public record HideoutListItem(
    Guid Id,
    string Name,
    ImageDto[] Images,
    HideoutTag[] Tags,
    HideoutMap Map,
    bool HasMTX,
    decimal Rating,
    string Author,
    PoeVersion PoeVersion);
