using GoldenBanana.Enums;

namespace GoldenBanana.Dtos
{
    public class HideoutFilter : Filter
    {
        string? Name { get; set; }
        PoeVersion? PoeVersion { get; set; }
        bool? HasMTX { get; set; }
        Guid[]? MapIds { get; set; }
        Guid[]? Tags { get; set; }
    }
}
