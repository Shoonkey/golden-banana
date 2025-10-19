using Microsoft.AspNetCore.Mvc;
using GoldenBanana.Infrastructure.Models;
using GoldenBanana.Dtos;
using GoldenBanana.Interfaces;

namespace GoldenBanana.Controllers;

public class HideoutController(IHideoutService hideoutService) : Controller
{
    private readonly IHideoutService _hideoutService = hideoutService;

    [HttpGet("/hideout/list")]
    public async Task<ActionResult> GetFilteredAsync([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] HideoutFilter filters)
    {
        var filtered = await _hideoutService.GetFilteredAsync(page, pageSize, filters);
        // TODO: Transform to DTO { list: HideoutDto[], matchCount: int }
        return Ok(filtered);
    }
}
