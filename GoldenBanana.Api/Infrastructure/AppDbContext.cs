using GoldenBanana.Api.Infrastructure.Models;
using GoldenBanana.Api.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;

namespace GoldenBanana.Api.Infrastructure;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        UserSeeds.Seed(modelBuilder);
        HideoutTagSeeds.Seed(modelBuilder);
        HideoutMapSeeds.Seed(modelBuilder);
    }
 
    public DbSet<User> Users { get; set; }
    public DbSet<Hideout> Hideouts { get; set; }
    public DbSet<HideoutTag> HideoutTags { get; set; }
    public DbSet<HideoutMap> HideoutMaps { get; set; }
    public DbSet<HideoutChangelogEntry> HideoutChangelogEntries { get; set; }
    public DbSet<HideoutComment> HideoutComments { get; set; }
    public DbSet<UserFavoritedHideout> UserFavoritedHideouts { get; set; }
}
