using GoldenBanana.Api.Dtos.Path;
using GoldenBanana.Api.Dtos.Users;

namespace GoldenBanana.Api.Interfaces;

public interface IUserService
{
    Task<UserDto?> GetByUsernameAsync(string username);
    Task<PathTokenResponse> GetPathUserAsync(UserPathLoginDto data);
    Task<bool> SaveUserAsync(PathTokenResponse data);
}
