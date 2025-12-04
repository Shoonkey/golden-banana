using GoldenBanana.Api.Dtos.Hideouts;
using GoldenBanana.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoldenBanana.Api.Controllers;

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

    [HttpGet("maps")]
    public async Task<ActionResult> GetHideoutMaps()
    {
        var maps = await _hideoutService.GetHideoutMapsAsync();
        return Ok(maps);
    }

    [HttpGet("tags")]
    public async Task<ActionResult> GetHideoutTags()
    {
        var tags = await _hideoutService.GetHideoutTagsAsync();
        return Ok(tags);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromForm] CreateHideoutDto dto)
    {
        // TODO: Change to actual username
        var res = await _hideoutService.CreateAsync("julião", dto);
        return Ok(res);
    }
}
