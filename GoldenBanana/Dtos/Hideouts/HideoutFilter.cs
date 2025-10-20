using GoldenBanana.Enums;

namespace GoldenBanana.Dtos.Hideouts;

public class HideoutFilter : Filter
{
    public string? Name { get; set; }
    public PoeVersion? PoeVersion { get; set; }
    public bool? HasMTX { get; set; }
    public Guid[]? MapIds { get; set; }
    public Guid[]? Tags { get; set; }
}
