using GoldenBanana.Dtos;
using GoldenBanana.Dtos.Hideouts;
using GoldenBanana.Infrastructure.Models;

namespace GoldenBanana.Infrastructure.Interfaces;

public interface IFilterableRepository<T> where T : BaseEntity
{
    Task<PaginatedResponse<T2>> GetFilteredAsync<T2>(
        int page,
        int pageSize,
        Filter? filter,
        Func<T, T2> convertTo);
}
