using GoldenBanana.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenBanana.Infrastructure.Models;

[Table("Hideouts")]
public class Hideout : BaseEntity
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = null!;
    public PoeVersion PoeVersion { get; set; }
    public string Description { get; set; } = null!;
    public bool HasMTX { get; set; }
    public int TimesDownloaded { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual ICollection<HideoutImage> Images { get; set; } = [];
    public virtual ICollection<UserFavoritedHideout> UsersFavorited { get; set; } = [];
    public virtual User Author { get; set; } = null!;
}
