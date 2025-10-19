using GoldenBanana.Dtos;
using GoldenBanana.Infrastructure.Models;

namespace GoldenBanana.Infrastructure.Interfaces;

public interface IFilterableRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetFilteredAsync(int page, int pageSize, Filter filter);
}
