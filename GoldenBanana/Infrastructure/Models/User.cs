using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenBanana.Api.Infrastructure.Models;

[Table("Users")]
[Index(nameof(Username), IsUnique = true)]
public class User : BaseEntity
{
    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public virtual ICollection<Hideout> Hideouts { get; set; } = [];
    public virtual ICollection<UserFavoritedHideout> FavoritedHideouts { get; set; } = [];
}
