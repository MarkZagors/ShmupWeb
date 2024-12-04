using ShmupCreator.Contracts;

namespace ShmupCreator.Services.Mappers;

public interface ILevelMetadataServiceMapper
{
    ShmupCreator.Repositories.Models.LevelMetadata MapToLevelMetadataORM(CreateLevelMetadataRequest createLevelMetadataRequest);
    ShmupCreator.Repositories.Models.LevelMetadata MapToLevelMetadataORM(UpdateLevelMetadataRequest updateLevelMetadataRequest);
    ShmupCreator.Repositories.Models.LevelMetadata MapToLevelMetadataORM(DeleteLevelMetadataRequest deleteLevelMetadataRequest);
    ShmupCreator.Services.Models.LevelMetadata MapToLevelMetadataService(ShmupCreator.Repositories.Models.LevelMetadata levelMetadataORM);
}

public class LevelMetadataServiceMapper : ILevelMetadataServiceMapper
{
    public ShmupCreator.Services.Models.LevelMetadata MapToLevelMetadataService(ShmupCreator.Repositories.Models.LevelMetadata levelMetadataORM)
    {
        return new ShmupCreator.Services.Models.LevelMetadata
        {
            LevelID = levelMetadataORM.LevelID,
            LevelName = levelMetadataORM.LevelName,
            Difficulty = levelMetadataORM.Difficulty,
            LevelScriptId = levelMetadataORM.LevelScriptId,
            MusicId = levelMetadataORM.MusicId
        };
    }

    public ShmupCreator.Repositories.Models.LevelMetadata MapToLevelMetadataORM(ShmupCreator.Contracts.CreateLevelMetadataRequest createLevelMetadataRequest)
    {
        return new ShmupCreator.Repositories.Models.LevelMetadata
        {
            LevelName = createLevelMetadataRequest.LevelName
        };
    }

    public ShmupCreator.Repositories.Models.LevelMetadata MapToLevelMetadataORM(ShmupCreator.Contracts.UpdateLevelMetadataRequest updateLevelMetadataRequest)
    {
        return new ShmupCreator.Repositories.Models.LevelMetadata
        {
            LevelID = updateLevelMetadataRequest.LevelID,
            LevelName = updateLevelMetadataRequest.LevelName
        };
    }

    public ShmupCreator.Repositories.Models.LevelMetadata MapToLevelMetadataORM(ShmupCreator.Contracts.DeleteLevelMetadataRequest deleteLevelMetadataRequest)
    {
        return new ShmupCreator.Repositories.Models.LevelMetadata
        {
            LevelID = deleteLevelMetadataRequest.LevelID
        };
    }
}
