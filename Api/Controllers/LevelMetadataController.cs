using Microsoft.AspNetCore.Mvc;
using ShmupCreator.Contracts;
using ShmupCreator.Services;

namespace ShmupCreator.Controllers;

[ApiController]
[Route("[controller]")]
public class LevelMetadataController : ControllerBase
{
    private readonly ILevelMetadataService _levelMetadataService;

    public LevelMetadataController(ILevelMetadataService levelMetadataService)
    {
        _levelMetadataService = levelMetadataService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNew([FromBody] CreateLevelMetadataRequest createLevelMetadataRequest)
    {
        var levelMetadata = await _levelMetadataService.Create(createLevelMetadataRequest);
        return Ok(new LevelMetadataResponse
        {
            LevelID = levelMetadata.LevelID,
            LevelName = levelMetadata.LevelName,
            LevelScriptId = levelMetadata.LevelScriptId,
            MusicId = levelMetadata.MusicId,
            Difficulty = levelMetadata.Difficulty
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var levelMetadataList = await _levelMetadataService.GetAll();
        var levelMetadataResponses = levelMetadataList.Select(levelMetadata => new LevelMetadataResponse
        {
            LevelID = levelMetadata.LevelID,
            LevelName = levelMetadata.LevelName,
            LevelScriptId = levelMetadata.LevelScriptId,
            MusicId = levelMetadata.MusicId,
            Difficulty = levelMetadata.Difficulty
        });
        return Ok(levelMetadataResponses);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLevelMetadataRequest updateLevelMetadataRequest)
    {
        var levelMetadata = await _levelMetadataService.Update(updateLevelMetadataRequest);
        return Ok(new LevelMetadataResponse
        {
            LevelID = levelMetadata.LevelID,
            LevelName = levelMetadata.LevelName,
            LevelScriptId = levelMetadata.LevelScriptId,
            MusicId = levelMetadata.MusicId,
            Difficulty = levelMetadata.Difficulty
        });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteLevelMetadataRequest deleteLevelMetadataRequest)
    {
        await _levelMetadataService.Delete(deleteLevelMetadataRequest);
        return Ok("Level metadata deleted.");
    }
}
