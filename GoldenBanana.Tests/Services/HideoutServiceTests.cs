using GoldenBanana.Api.Dtos;
using GoldenBanana.Api.Dtos.Hideouts;
using GoldenBanana.Api.Infrastructure.Interfaces;
using GoldenBanana.Api.Infrastructure.Models;
using GoldenBanana.Api.Services;
using Moq;
using System.Linq.Expressions;

namespace GoldenBanana.Tests.Services;

public class HideoutServiceTests
{
    private readonly Mock<IHideoutRepository> _hideoutRepoMock = new();
    private readonly Mock<IHideoutMapRepository> _hideoutMapRepoMock = new();
    private readonly Mock<IHideoutTagRepository> _hideoutTagRepoMock = new();

    private readonly HideoutService _service;

    public HideoutServiceTests()
    {
        _service = new HideoutService(_hideoutRepoMock.Object, _hideoutMapRepoMock.Object, _hideoutTagRepoMock.Object);
    }

    [Fact]
    public async Task GetFilteredAsync_ShouldReturnSuccess()
    {
        // Arrange
        Expression<Func<IHideoutRepository, Task<PaginatedResponse<HideoutListItem>>>> filteringCall = r => r.GetFilteredAsync(
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<Filter>(),
            It.IsAny<Func<Hideout, HideoutListItem>>());

        _hideoutRepoMock.Setup(filteringCall)
            .ReturnsAsync(new PaginatedResponse<HideoutListItem>());

        // Act
        var res = await _service.GetFilteredAsync(1, 1, null);

        // Assert
        Assert.NotNull(res);
        Assert.Empty(res.Items);
        _hideoutRepoMock.Verify(filteringCall, Times.Once);
    }
}
