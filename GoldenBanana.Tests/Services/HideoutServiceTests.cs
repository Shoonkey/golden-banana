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
    private readonly HideoutService _service;
    private readonly Mock<IHideoutRepository> _repositoryMock;

    public HideoutServiceTests()
    {
        _repositoryMock = new Mock<IHideoutRepository>();
        _service = new HideoutService(_repositoryMock.Object);
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

        _repositoryMock.Setup(filteringCall)
            .ReturnsAsync(new PaginatedResponse<HideoutListItem>());

        // Act
        var res = await _service.GetFilteredAsync(1, 1, null);

        // Assert
        Assert.NotNull(res);
        Assert.Empty(res.Items);
        _repositoryMock.Verify(filteringCall, Times.Once);
    }
}
