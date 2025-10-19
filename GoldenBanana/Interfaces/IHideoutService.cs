using GoldenBanana.Dtos;
using GoldenBanana.Infrastructure.Models;

namespace GoldenBanana.Interfaces
{
    public interface IHideoutService
    {
        Task<IEnumerable<Hideout>> GetFilteredAsync(int page, int pageSize, HideoutFilter filters);
    }
}
