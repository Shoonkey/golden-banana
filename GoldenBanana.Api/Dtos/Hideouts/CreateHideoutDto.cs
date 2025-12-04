using GoldenBanana.Api.Enums;

namespace GoldenBanana.Api.Dtos.Hideouts;

public record CreateHideoutDto(
    string Name,
    PoeVersion PoeVersion,
    string Description,
    bool HasMtx,
    Guid[] TagIds,
    Guid HideoutMapId,
    IFormFile[] Images);
