using GoldenBanana.Api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenBanana.Api.Infrastructure.Seeds;

public static class HideoutMapSeeds
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HideoutMap>().HasData(
            new HideoutMap
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                Name = "Baleful Hideout"
            },
            new HideoutMap
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                Name = "Trial of the Ancestors Hideout"
            }
        );
    }
}
