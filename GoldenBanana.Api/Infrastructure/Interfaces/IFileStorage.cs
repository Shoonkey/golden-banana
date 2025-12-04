namespace GoldenBanana.Api.Infrastructure.Interfaces;

public interface IFileStorage
{
    Task<string?> SaveImageAsync(Guid id, bool isThumbnail, Stream imageStream);
    void Rollback();
}
