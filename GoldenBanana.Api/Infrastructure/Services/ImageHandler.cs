using GoldenBanana.Api.Infrastructure.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace GoldenBanana.Api.Infrastructure.Services;

public class ImageHandler : IImageHandler
{
    public async Task<MemoryStream> CreateThumbnailAsync(Stream fileStream)
    {
        using var image = await Image.LoadAsync(fileStream);
        var resizedImage = Resize(
            image,
            image.Width / 2,
            image.Height / 2);

        var stream = new MemoryStream();
        await image.SaveAsPngAsync(stream);
        stream.Position = 0;

        return stream;
    }

    public async Task<MemoryStream> ConvertToStreamAsync(Stream fileStream)
    {
        var stream = new MemoryStream();
        await fileStream.CopyToAsync(stream);
        stream.Position = 0;

        return stream;
    }

    private static Image Resize(Image image, int width, int height)
    {
        image.Mutate(x => x.Resize(width, height));
        return image;
    }
}
