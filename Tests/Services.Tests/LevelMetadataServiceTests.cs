using ShmupCreator.Services;
using Moq;
using ShmupCreator.Repositories;
using ShmupCreator.Services.Mappers;
using ShmupCreator.Services.Models;
using Castle.Components.DictionaryAdapter.Xml;

namespace Services.Tests;

public class LevelMetadataServiceTests
{
    private readonly Mock<ILevelMetadataRepository> _mockLevelMetadataRepository;
    private readonly Mock<ILevelMetadataServiceMapper> _mockMapper;

    public LevelMetadataServiceTests()
    {
        _mockLevelMetadataRepository = new Mock<ILevelMetadataRepository>(MockBehavior.Strict);
        _mockMapper = new Mock<ILevelMetadataServiceMapper>(MockBehavior.Strict);
    }

    [Fact]
    public async Task GetAll_ShouldReturnLevelMetadata()
    {
        //Arrange
        var levelMetadataListORM = new List<ShmupCreator.Repositories.Models.LevelMetadata>
        {
            new ShmupCreator.Repositories.Models.LevelMetadata {
                LevelID = 1,
                LevelName = "getall_test_1"
            },
            new ShmupCreator.Repositories.Models.LevelMetadata {
                LevelID = 2,
                LevelName = "getall_test_2"
            }
        };
        _mockLevelMetadataRepository
            .Setup(repo => repo.GetAll())
            .ReturnsAsync(
                levelMetadataListORM
            );

        var levelMetadataService = new LevelMetadataService(
            _mockLevelMetadataRepository.Object,
            _mockMapper.Object);

        //Act
        var result = await levelMetadataService.GetAll();

        //Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }
}
