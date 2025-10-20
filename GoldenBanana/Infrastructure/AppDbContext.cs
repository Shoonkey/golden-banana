using GoldenBanana.Api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenBanana.Api.Infrastructure;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
 
    public DbSet<User> Users { get; set; }
    public DbSet<Hideout> Hideouts { get; set; }
    public DbSet<HideoutTag> HideoutTags { get; set; }
    public DbSet<HideoutMap> HideoutMaps { get; set; }
    public DbSet<HideoutChangelogEntry> HideoutChangelogEntries { get; set; }
    public DbSet<HideoutComment> HideoutComments { get; set; }
    public DbSet<UserFavoritedHideout> UserFavoritedHideouts { get; set; }
}
