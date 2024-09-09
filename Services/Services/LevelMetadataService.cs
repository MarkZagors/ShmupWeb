namespace ShmupCreator.Services;

using ShmupCreator.Contracts;
using ShmupCreator.Repositories;
using ShmupCreator.Services.Models;

public class LevelMetadataService
{
    private readonly LevelMetadataRepository _levelMetadataReporitory;

    public LevelMetadataService(LevelMetadataRepository levelMetadataRepository)
    {
        _levelMetadataReporitory = levelMetadataRepository;
    }

    public async Task Create(CreateLevelMetadataRequest createLevelMetadataRequest)
    {
        await _levelMetadataReporitory.Insert(
            new Repositories.Models.LevelMetadata
            {
                LevelName = createLevelMetadataRequest.LevelName
            }
        );
    }

    // TODO change to metadata service model
    public async Task<IEnumerable<LevelMetadata>> GetAll()
    {
        var levelMetadataListORM = await _levelMetadataReporitory.GetAll();
        var levelMetadataListService = new List<LevelMetadata>();
        foreach (var levelMetadataORM in levelMetadataListORM)
        {
            levelMetadataListService.Add(
                new LevelMetadata
                {
                    LevelID = levelMetadataORM.LevelID,
                    LevelName = levelMetadataORM.LevelName,
                    Difficulty = levelMetadataORM.Difficulty,
                    LevelScriptId = levelMetadataORM.LevelScriptId,
                    MusicId = levelMetadataORM.MusicId
                }
            );
        }
        return levelMetadataListService;
    }

    public async Task Update(UpdateLevelMetadataRequest updateLevelMetadataRequest)
    {
        await _levelMetadataReporitory.Update(
            new Repositories.Models.LevelMetadata
            {
                LevelID = updateLevelMetadataRequest.LevelID,
                LevelName = updateLevelMetadataRequest.LevelName
            }
        );
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
