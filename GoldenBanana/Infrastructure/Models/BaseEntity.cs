using System.ComponentModel.DataAnnotations;

namespace GoldenBanana.Api.Infrastructure.Models;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}
