using AgifyApi.ServiceContracts;
using Xunit;
using FluentAssertions;
using Moq;

namespace Tests;

public class Tests
{
    private readonly IAgeService _ageService;
    private readonly Mock<IAgeService> _mockAgeService;

    public Tests()
    {
        _mockAgeService = new Mock<IAgeService>();
        _ageService = _mockAgeService.Object;
    }
    
    [Fact]
    public async Task GetAge_ToThrowArgumentException()
    {
        Func<Task> action = async () =>
        {
            await _ageService.GetAge(null);
        };
        
        await action.Should().ThrowAsync<ArgumentException>();
    }

    [Fact]
    public async Task GetAge_ToReturnData()
    {
        var expected = new Dictionary<string, object>()
        {
            { "count", 1488 },
            { "name", "vitalii" },
            { "age", 18 }
        };
        
        _mockAgeService.Setup(item => item.GetAge(It.IsAny<string>()))
            .ReturnsAsync(expected);

        var actual = await _ageService.GetAge(It.IsAny<string>());

        actual.Should().BeEquivalentTo(expected);
    }
}