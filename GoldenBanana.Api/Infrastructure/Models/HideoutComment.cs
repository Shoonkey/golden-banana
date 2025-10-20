using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenBanana.Api.Infrastructure.Models;

[Table("HideoutComments")]
public class HideoutComment : BaseEntity
{
    public Guid HideoutId { get; set; }
    public Guid UserId { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual Hideout Hideout { get; set; } = null!;
    [ForeignKey("UserId")]
    public virtual User Author { get; set; } = null!;
}
