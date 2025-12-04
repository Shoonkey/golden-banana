using GoldenBanana.Api.Infrastructure.Interfaces;

namespace GoldenBanana.Api.Infrastructure.Services;

public class LocalFileStorage(IImageHandler imageHandler) : IFileStorage
{
    private readonly IImageHandler _imageHandler = imageHandler;
    private readonly List<string> _storedFiles = [];

    public async Task<string?> SaveImageAsync(Guid id, bool isThumbnail, Stream imageStream)
    {
        var url = GetImageUrl(id);
        using var memoryStream = isThumbnail ?
            await _imageHandler.CreateThumbnailAsync(imageStream) :
            await _imageHandler.ConvertToStreamAsync(imageStream);

        try
        {
            if (!Directory.Exists("Images"))
            {
                Directory.CreateDirectory("Images");
            }

            using var file = new FileStream(url, FileMode.Create, FileAccess.Write);
            await memoryStream.CopyToAsync(file);
            _storedFiles.Add(url);
        }
        catch (Exception)
        {
            return null;
        }

        return url;
    }

    public void Rollback()
    {
        foreach(var image in _storedFiles)
        {
            DeleteFile(image);
        }

        _storedFiles.Clear();
    }

    private static void DeleteFile(string fileUrl)
    {
        if (!File.Exists(fileUrl)) return;
        File.Delete(fileUrl);
    }

    private static string GetImageUrl(Guid id) =>
        $"Images/{id}.png";
}
