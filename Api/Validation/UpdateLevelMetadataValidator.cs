using FluentValidation;
using ShmupCreator.Contracts;

namespace ShmupCreator.Controllers.Validation;

public class UpdateLevelMetadataValidator : AbstractValidator<UpdateLevelMetadataRequest>
{
    public UpdateLevelMetadataValidator()
    {
        RuleFor(levelMetadata => levelMetadata.LevelID).NotEmpty();
        RuleFor(levelMetadata => levelMetadata.LevelName).NotEmpty();
        RuleFor(levelMetadata => levelMetadata.LevelName).Length(1, 20);
    }
}
