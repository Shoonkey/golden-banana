using GoldenBanana.Api.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenBanana.Api.Infrastructure.Models;

[Table("Hideouts")]
public class Hideout : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid HideoutMapId { get; set; }
    public string Name { get; set; } = null!;
    public PoeVersion PoeVersion { get; set; }
    public string Description { get; set; } = null!;
    public bool HasMTX { get; set; }
    public decimal Rating { get; set; }
    public int TimesDownloaded { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; } = null;
    public virtual ICollection<HideoutHideoutTag> Tags { get; set; } = [];
    public virtual ICollection<HideoutImage> Images { get; set; } = [];
    public virtual ICollection<UserFavoritedHideout> UsersFavorited { get; set; } = [];
    public virtual HideoutMap Map { get; set; } = null!;
    public virtual User Author { get; set; } = null!;
}
