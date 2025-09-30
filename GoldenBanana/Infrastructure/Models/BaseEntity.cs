using System.ComponentModel.DataAnnotations;

namespace GoldenBanana.Infrastructure.Models;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}
