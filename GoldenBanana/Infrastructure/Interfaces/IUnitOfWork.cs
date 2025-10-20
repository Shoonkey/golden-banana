namespace GoldenBanana.Api.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        Task CreateAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
