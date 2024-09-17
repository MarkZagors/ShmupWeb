using Microsoft.AspNetCore.Mvc;
using ShmupCreator.Contracts;
using ShmupCreator.Services;

namespace ShmupCreator.Controllers;

[ApiController]
[Route("[controller]")]
public class LevelMetadataController : ControllerBase
{
    private readonly ILevelMetadataService _levelMetadataService;
    private readonly ILevelMetadataControllerMapper _mapper;

    public LevelMetadataController(ILevelMetadataService levelMetadataService, ILevelMetadataControllerMapper mapper)
    {
        _levelMetadataService = levelMetadataService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNew([FromBody] CreateLevelMetadataRequest createLevelMetadataRequest)
    {
        var levelMetadata = await _levelMetadataService.Create(createLevelMetadataRequest);
        return Ok(_mapper.MapToLevelMetadataResponse(levelMetadata));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var levelMetadataList = await _levelMetadataService.GetAll();
        var levelMetadataResponses = levelMetadataList.Select(levelMetadata => _mapper.MapToLevelMetadataResponse(levelMetadata));
        return Ok(levelMetadataResponses);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLevelMetadataRequest updateLevelMetadataRequest)
    {
        var levelMetadata = await _levelMetadataService.Update(updateLevelMetadataRequest);
        return Ok(_mapper.MapToLevelMetadataResponse(levelMetadata));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteLevelMetadataRequest deleteLevelMetadataRequest)
    {
        await _levelMetadataService.Delete(deleteLevelMetadataRequest);
        return Ok("Level metadata deleted.");
    }
}
