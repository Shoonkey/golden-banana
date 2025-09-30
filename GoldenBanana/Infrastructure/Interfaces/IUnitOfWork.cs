namespace GoldenBanana.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        Task CreateAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
