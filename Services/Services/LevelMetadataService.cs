namespace ShmupCreator.Services;

using Npgsql;
using ShmupCreator.Contracts;
using ShmupCreator.Repositories;
// using ShmupCreator.Services.Models;

public class LevelMetadataService
{
    private readonly LevelMetadataRepository _levelMetadataReporitory;

    public LevelMetadataService(LevelMetadataRepository levelMetadataRepository)
    {
        _levelMetadataReporitory = levelMetadataRepository;
    }

    public async Task CreateNew(LevelMetadata levelMetadata)
    {
        await _levelMetadataReporitory.CreateNew(levelMetadata);
    }

    // TODO change to metadata service model
    public async Task<IEnumerable<LevelMetadata>> GetAll()
    {
        return await _levelMetadataReporitory.GetAll();
    }

    public async Task Update(LevelMetadata levelMetadata)
    {
        await _levelMetadataReporitory.Update(levelMetadata);
    }

    public async Task Delete(LevelMetadata levelMetadata)
    {
        await _levelMetadataReporitory.Delete(levelMetadata);
    }
}
