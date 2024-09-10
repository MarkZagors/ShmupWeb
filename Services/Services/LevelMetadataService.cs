namespace ShmupCreator.Services;

using ShmupCreator.Contracts;
using ShmupCreator.Repositories;
using ShmupCreator.Services.Models;

public interface ILevelMetadataService
{
    Task<LevelMetadata> Create(CreateLevelMetadataRequest createLevelMetadataRequest);
    Task Delete(DeleteLevelMetadataRequest deleteLevelMetadataRequest);
    Task<IEnumerable<LevelMetadata>> GetAll();
    Task<LevelMetadata> Update(UpdateLevelMetadataRequest updateLevelMetadataRequest);
}

public class LevelMetadataService : ILevelMetadataService
{
    private readonly ILevelMetadataRepository _levelMetadataReporitory;

    public LevelMetadataService(ILevelMetadataRepository levelMetadataRepository)
    {
        _levelMetadataReporitory = levelMetadataRepository;
    }

    public async Task<LevelMetadata> Create(CreateLevelMetadataRequest createLevelMetadataRequest)
    {
        var levelMetadataORM = await _levelMetadataReporitory.Insert(
            new Repositories.Models.LevelMetadata
            {
                LevelName = createLevelMetadataRequest.LevelName
            }
        );
        return new LevelMetadata
        {
            LevelID = levelMetadataORM.LevelID,
            LevelName = levelMetadataORM.LevelName,
            Difficulty = levelMetadataORM.Difficulty,
            LevelScriptId = levelMetadataORM.LevelScriptId,
            MusicId = levelMetadataORM.MusicId
        };
    }

    public async Task<IEnumerable<LevelMetadata>> GetAll()
    {
        var levelMetadataListORM = await _levelMetadataReporitory.GetAll();

        return levelMetadataListORM
            .Select(levelMetadataORM => new LevelMetadata
            {
                LevelID = levelMetadataORM.LevelID,
                LevelName = levelMetadataORM.LevelName,
                Difficulty = levelMetadataORM.Difficulty,
                LevelScriptId = levelMetadataORM.LevelScriptId,
                MusicId = levelMetadataORM.MusicId
            })
            .ToList();
    }

    public async Task<LevelMetadata> Update(UpdateLevelMetadataRequest updateLevelMetadataRequest)
    {
        var levelMetadataORM = await _levelMetadataReporitory.Update(
            new Repositories.Models.LevelMetadata
            {
                LevelID = updateLevelMetadataRequest.LevelID,
                LevelName = updateLevelMetadataRequest.LevelName
            }
        );
        return new LevelMetadata
        {
            LevelID = levelMetadataORM.LevelID,
            LevelName = levelMetadataORM.LevelName,
            Difficulty = levelMetadataORM.Difficulty,
            LevelScriptId = levelMetadataORM.LevelScriptId,
            MusicId = levelMetadataORM.MusicId
        };
    }

    public async Task Delete(DeleteLevelMetadataRequest deleteLevelMetadataRequest)
    {
        await _levelMetadataReporitory.Delete(
            new Repositories.Models.LevelMetadata
            {
                LevelID = deleteLevelMetadataRequest.LevelID
            }
        );
    }
}
