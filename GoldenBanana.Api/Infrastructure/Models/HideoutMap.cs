using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenBanana.Api.Infrastructure.Models;

[Table("HideoutMaps")]
[Index(nameof(Name), IsUnique = true)]
public class HideoutMap : BaseEntity
{
    public string Name { get; set; } = null!;
}
