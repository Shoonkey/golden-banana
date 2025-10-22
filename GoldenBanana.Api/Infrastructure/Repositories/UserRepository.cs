using GoldenBanana.Api.Dtos;
using GoldenBanana.Api.Dtos.Hideouts;
using GoldenBanana.Api.Infrastructure.Interfaces;
using GoldenBanana.Api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenBanana.Api.Infrastructure.Repositories;

public class UserRepository(AppDbContext context)
    : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> GetByUsernameAsync(string username) =>
        await _dbSet
            .Where(u => u.Username == username)
            .FirstOrDefaultAsync();
}
