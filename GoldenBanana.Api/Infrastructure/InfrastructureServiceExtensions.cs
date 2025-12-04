using GoldenBanana.Api.Infrastructure.Interfaces;
using GoldenBanana.Api.Infrastructure.Repositories;
using GoldenBanana.Api.Infrastructure.Services;

namespace GoldenBanana.Api.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static void AddInfrastructureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IHideoutRepository, HideoutRepository>();
        builder.Services.AddScoped<IHideoutMapRepository, HideoutMapRepository>();
        builder.Services.AddScoped<IHideoutTagRepository, HideoutTagRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IImageHandler, ImageHandler>();
        builder.Services.AddScoped<IFileStorage, LocalFileStorage>();
    }
}
