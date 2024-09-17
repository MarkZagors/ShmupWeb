namespace ShmupCreator.Controllers.Mappers;

public interface ILevelMetadataControllerMapper
{
    ShmupCreator.Contracts.LevelMetadataResponse MapToLevelMetadataResponse(ShmupCreator.Services.Models.LevelMetadata levelMetadata);
}

public class LevelMetadataControllerMapper : ILevelMetadataControllerMapper
{
    public ShmupCreator.Contracts.LevelMetadataResponse MapToLevelMetadataResponse(ShmupCreator.Services.Models.LevelMetadata levelMetadata)
    {
        return new ShmupCreator.Contracts.LevelMetadataResponse
        {
            LevelID = levelMetadata.LevelID,
            LevelName = levelMetadata.LevelName,
            LevelScriptId = levelMetadata.LevelScriptId,
            MusicId = levelMetadata.MusicId,
            Difficulty = levelMetadata.Difficulty
        };
    }
}
