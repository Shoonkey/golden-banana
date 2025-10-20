using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenBanana.Api.Infrastructure.Models;

[Table("UserFavoritedHideouts")]
[PrimaryKey(nameof(UserId), nameof(HideoutId))]
public class UserFavoritedHideout : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid HideoutId { get; set; }
    public virtual Hideout Hideout { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
