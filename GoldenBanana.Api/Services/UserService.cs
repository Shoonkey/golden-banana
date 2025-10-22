using GoldenBanana.Api.Dtos.Path;
using GoldenBanana.Api.Dtos.Users;
using GoldenBanana.Api.Infrastructure.Interfaces;
using GoldenBanana.Api.Infrastructure.Models;
using GoldenBanana.Api.Interfaces;

namespace GoldenBanana.Api.Services;

public class UserService(IUnitOfWork unitOfWork, IUserRepository userRepository) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<UserDto?> GetByUsernameAsync(string username)
    {
        var user = await _userRepository.GetByUsernameAsync(username);

        if (user == null)
        {
            return null;
        }

        return new UserDto(
            user.Id,
            user.Username,
            user.Rating);
    }

    public async Task<bool> SaveUserAsync(PathTokenResponse data)
    {
        await _unitOfWork.CreateAsync();

        _userRepository.Create(
            new User
            {
                PathId = data.Sub,
                Username = data.Username,
                CreatedAt = DateTime.UtcNow,
                Rating = 0
            });

        await _unitOfWork.CommitAsync();

        return true;
    }

    public Task<PathTokenResponse> GetPathUserAsync(UserPathLoginDto data)
    {
        // request Path API with code to get user info
        throw new NotImplementedException();
    }
}
