using GoldenBanana.Infrastructure.Models;

namespace GoldenBanana.Dtos
{
    public class HideoutListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string[] ImageUrls { get; set; } = [];
        public HideoutTag[] Tags { get; set; } = [];
        public HideoutMap Map { get; set; } = null!;
        public bool HasMTX { get; set; }
        public decimal Rating { get; set; }
    }
}
