using GoldenBanana.Api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenBanana.Api.Infrastructure.Seeds;

public static class UserSeeds
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                Username = "shinjinho",
                PathId = "test",
                CreatedAt = DateTime.Parse("2025-10-20 11:31").ToUniversalTime(),
            }
        );
    }
}
