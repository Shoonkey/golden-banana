using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenBanana.Api.Infrastructure.Models;

[Table("HideoutImages")]
public class HideoutImage : BaseEntity
{
    public Guid HideoutId { get; set; }
    public string Url { get; set; } = null!;
    public bool IsThumbnail { get; set; }
    public string Alt { get; set; } = null!;
    public virtual Hideout Hideout { get; set; } = null!;
}
