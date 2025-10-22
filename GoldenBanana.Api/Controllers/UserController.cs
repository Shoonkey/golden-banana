using GoldenBanana.Api.Dtos;
using GoldenBanana.Api.Dtos.Users;
using GoldenBanana.Api.Enums;
using GoldenBanana.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoldenBanana.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet("{username}")]
    public async Task<ActionResult> GetUserByUsername(string username)
    {
        var user = await _userService.GetByUsernameAsync(username);

        if (user == null)
            return NotFound(new ErrorDto<UserErrorCode>(UserErrorCode.NOT_FOUND));

        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] UserPathLoginDto data)
    {
        if (string.IsNullOrWhiteSpace(data.Code))
            return BadRequest(new ErrorDto<UserErrorCode>(UserErrorCode.INVALID_CREDENTIALS));

        var pathUser = await _userService.GetPathUserAsync(data);
        await _userService.SaveUserAsync(pathUser);

        return BadRequest(new ErrorDto<UserErrorCode>(UserErrorCode.INVALID_CREDENTIALS));
    }
}
