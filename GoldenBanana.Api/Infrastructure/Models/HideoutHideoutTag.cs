using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenBanana.Api.Infrastructure.Models;

[Table("HideoutHideoutTags")]
[PrimaryKey(nameof(HideoutId), nameof(HideoutTagId))]
public class HideoutHideoutTag : BaseEntity
{
    public Guid HideoutId { get; set; }
    public Guid HideoutTagId { get; set; }
    public virtual Hideout Hideout { get; set; } = null!;
    public virtual HideoutTag Tag { get; set; } = null!;
}
