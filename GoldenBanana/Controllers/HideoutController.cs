using GoldenBanana.Dtos.Hideouts;
using GoldenBanana.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoldenBanana.Controllers;

[ApiController]
[Route("[controller]")]
public class HideoutController(
    IHideoutService hideoutService) : ControllerBase
{
    private readonly IHideoutService _hideoutService = hideoutService;

    [HttpGet("list")]
    public async Task<ActionResult> GetFilteredAsync([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] HideoutFilter filters)
    {
        var filtered = await _hideoutService.GetFilteredAsync(
            page,
            pageSize,
            filters);

        return Ok(filtered);
    }
}
