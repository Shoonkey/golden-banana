using GoldenBanana.Dtos;
using GoldenBanana.Infrastructure.Models;

namespace GoldenBanana.Infrastructure.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    void Create(T data);
    void Update(T data);
    Task DeleteById(Guid id);
    Task<IEnumerable<T>> GetFilteredAsync(int page, int pageSize, Filter filters);
}
