using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenBanana.Api.Infrastructure.Models;

[Table("Users")]
[Index(nameof(Username), IsUnique = true)]
[Index(nameof(PathId), IsUnique = true)]
public class User : BaseEntity
{
    public string Username { get; set; } = null!;
    public string PathId { get; set; } = null!;
    public decimal Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<Hideout> Hideouts { get; set; } = [];
    public virtual ICollection<UserFavoritedHideout> FavoritedHideouts { get; set; } = [];
}
