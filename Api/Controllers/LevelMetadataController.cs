using FluentValidation;
using FluentValidation.Results;
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
    private readonly IValidator<CreateLevelMetadataRequest> _createValidator;
    private readonly IValidator<UpdateLevelMetadataRequest> _updateValidator;
    private readonly IValidator<DeleteLevelMetadataRequest> _deleteValidator;

    public LevelMetadataController(
        ILevelMetadataService levelMetadataService,
        ILevelMetadataControllerMapper mapper,
        IValidator<CreateLevelMetadataRequest> createValidator,
        IValidator<UpdateLevelMetadataRequest> updateValidator,
        IValidator<DeleteLevelMetadataRequest> deleteValidator
        )
    {
        _levelMetadataService = levelMetadataService;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
        _deleteValidator = deleteValidator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNew([FromBody] CreateLevelMetadataRequest createLevelMetadataRequest)
    {
        ValidationResult validationResult = await _createValidator.ValidateAsync(createLevelMetadataRequest);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
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
        ValidationResult validationResult = await _updateValidator.ValidateAsync(updateLevelMetadataRequest);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var levelMetadata = await _levelMetadataService.Update(updateLevelMetadataRequest);
        return Ok(_mapper.MapToLevelMetadataResponse(levelMetadata));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteLevelMetadataRequest deleteLevelMetadataRequest)
    {
        ValidationResult validationResult = await _deleteValidator.ValidateAsync(deleteLevelMetadataRequest);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        await _levelMetadataService.Delete(deleteLevelMetadataRequest);
        return Ok("Level metadata deleted.");
    }
}
