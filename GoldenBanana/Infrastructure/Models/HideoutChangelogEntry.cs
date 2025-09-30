using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenBanana.Infrastructure.Models;

[Table("HideoutChangelogEntries")]
public class HideoutChangelogEntry : BaseEntity
{
    public Guid HideoutId { get; set; }
    public string Version { get; set; } = null!;
    public string FileURL { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime PublishedAt { get; set; }
    public virtual Hideout Hideout { get; set; } = null!;
}
