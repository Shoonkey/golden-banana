namespace GoldenBanana.Api.Dtos.Users;

public record UserDto(
    Guid Id,
    string Username,
    decimal Rating
);