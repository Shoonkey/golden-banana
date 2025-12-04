using SixLabors.ImageSharp;

namespace GoldenBanana.Api.Infrastructure.Interfaces;

public interface IImageHandler
{
    Task<MemoryStream> CreateThumbnailAsync(Stream fileStream);
    Task<MemoryStream> ConvertToStreamAsync(Stream fileStream);
}
