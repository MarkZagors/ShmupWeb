using ShmupCreator.Contracts;
using ShmupCreator.Services.Models;

public interface ILevelMetadataControllerMapper
{
    LevelMetadataResponse MapToLevelMetadataResponse(LevelMetadata levelMetadata);
}

public class LevelMetadataControllerMapper : ILevelMetadataControllerMapper
{
    public LevelMetadataResponse MapToLevelMetadataResponse(ShmupCreator.Services.Models.LevelMetadata levelMetadata)
    {
        return new LevelMetadataResponse
        {
            LevelID = levelMetadata.LevelID,
            LevelName = levelMetadata.LevelName,
            LevelScriptId = levelMetadata.LevelScriptId,
            MusicId = levelMetadata.MusicId,
            Difficulty = levelMetadata.Difficulty
        };
    }
}
