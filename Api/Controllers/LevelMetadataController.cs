using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using ShmupCreator.Contracts;
using ShmupCreator.Services;

namespace ShmupCreator.Controllers;

[ApiController]
[Route("[controller]")]
public class LevelMetadataController : ControllerBase
{
    private readonly LevelMetadataService _levelMetadataService;

    public LevelMetadataController(LevelMetadataService levelMetadataService)
    {
        _levelMetadataService = levelMetadataService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNew([FromBody] LevelMetadata levelMetadata)
    {
        //TODO change request model to contract request model
        await _levelMetadataService.CreateNew(levelMetadata);
        return Ok("Created new level metadata.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var levelMetadataList = await _levelMetadataService.GetAll();
        return Ok(levelMetadataList);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] LevelMetadata levelMetadata)
    {
        // var updatedMetadata = TODO add return model for service and repo
        await _levelMetadataService.Update(levelMetadata);
        //TODO Return contract response model
        return Ok("Level metadata updated.");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] LevelMetadata levelMetadata)
    {
        await _levelMetadataService.Delete(levelMetadata);
        return Ok("Level metadata deleted.");
    }
}
