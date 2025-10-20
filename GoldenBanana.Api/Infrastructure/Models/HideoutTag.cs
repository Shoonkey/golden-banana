using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenBanana.Api.Infrastructure.Models;

[Table("HideoutTags")]
public class HideoutTag : BaseEntity
{
    public string Name { get; set; } = null!;
}
