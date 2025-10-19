using GoldenBanana.Dtos;
using GoldenBanana.Infrastructure.Interfaces;
using GoldenBanana.Infrastructure.Models;
using GoldenBanana.Interfaces;

namespace GoldenBanana.Services;

public class HideoutService(IHideoutRepository repository) : IHideoutService
{
    private readonly IHideoutRepository _repository = repository;

    public async Task<IEnumerable<Hideout>> GetFilteredAsync(int page, int pageSize, HideoutFilter filters)
    {
        return await _repository.GetFilteredAsync(page, pageSize, filters);
    }
}
