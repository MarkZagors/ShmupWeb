using ShmupCreator.Contracts;
using ShmupCreator.Repositories;
using ShmupCreator.Services.Mappers;
using ShmupCreator.Services.Models;

namespace ShmupCreator.Services;

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
    private readonly ILevelMetadataServiceMapper _mapper;

    public LevelMetadataService(ILevelMetadataRepository levelMetadataRepository, ILevelMetadataServiceMapper mapper)
    {
        _levelMetadataReporitory = levelMetadataRepository;
        _mapper = mapper;
    }

    public async Task<LevelMetadata> Create(CreateLevelMetadataRequest createLevelMetadataRequest)
    {
        var levelMetadataORM = await _levelMetadataReporitory.Insert(_mapper.MapToLevelMetadataORM(createLevelMetadataRequest));
        return _mapper.MapToLevelMetadataService(levelMetadataORM);
    }

    public async Task<IEnumerable<LevelMetadata>> GetAll()
    {
        var levelMetadataListORM = await _levelMetadataReporitory.GetAll();

        return levelMetadataListORM
            .Select(levelMetadataORM => _mapper.MapToLevelMetadataService(levelMetadataORM))
            .ToList();
    }

    public async Task<LevelMetadata> Update(UpdateLevelMetadataRequest updateLevelMetadataRequest)
    {
        var levelMetadataORM = await _levelMetadataReporitory.Update(_mapper.MapToLevelMetadataORM(updateLevelMetadataRequest));
        return _mapper.MapToLevelMetadataService(levelMetadataORM);
    }

    public async Task Delete(DeleteLevelMetadataRequest deleteLevelMetadataRequest)
    {
        await _levelMetadataReporitory.Delete(_mapper.MapToLevelMetadataORM(deleteLevelMetadataRequest));
    }
}
