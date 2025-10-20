using GoldenBanana.Api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenBanana.Api.Infrastructure.Seeds;

public class HideoutTagSeeds
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HideoutTag>().HasData(
            new HideoutTag
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                Name = "Cozy"
            },
            new HideoutTag
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                Name = "Spacious"
            },
            new HideoutTag
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                Name = "Dark"
            },
            new HideoutTag
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                Name = "Bright"
            },
            new HideoutTag
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000005"),
                Name = "Efficient"
            }
        );
    }
}
