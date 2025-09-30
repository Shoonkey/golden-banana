using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenBanana.Infrastructure.Models;

[Table("HideoutTags")]
public class HideoutTag : BaseEntity
{
    public string Name { get; set; } = null!;
}
