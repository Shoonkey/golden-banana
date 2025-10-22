using GoldenBanana.Api.Enums;

namespace GoldenBanana.Api.Dtos.Hideouts;

public class HideoutFilter : Filter
{
    public string? Name { get; set; }
    public PoeVersion? PoeVersion { get; set; }
    public bool? HasMTX { get; set; }
    public Guid[]? MapIds { get; set; }
    public Guid[]? Tags { get; set; }
    public string? Author { get; set; }
}
