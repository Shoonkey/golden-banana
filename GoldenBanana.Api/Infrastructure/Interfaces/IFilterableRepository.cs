using GoldenBanana.Api.Dtos;
using GoldenBanana.Api.Dtos.Hideouts;
using GoldenBanana.Api.Infrastructure.Models;

namespace GoldenBanana.Api.Infrastructure.Interfaces;

public interface IFilterableRepository<T> where T : BaseEntity
{
    Task<PaginatedResponse<T2>> GetFilteredAsync<T2>(
        int page,
        int pageSize,
        Filter? filter,
        Func<T, T2> convertTo);
}
