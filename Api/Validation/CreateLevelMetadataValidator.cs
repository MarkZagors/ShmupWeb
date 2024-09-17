using FluentValidation;
using ShmupCreator.Contracts;

namespace ShmupCreator.Controllers.Validation;

public class CreateLevelMetadataValidator : AbstractValidator<CreateLevelMetadataRequest>
{
    public CreateLevelMetadataValidator()
    {
        RuleFor(levelMetadata => levelMetadata.LevelName).NotEmpty();
        RuleFor(levelMetadata => levelMetadata.LevelName).Length(1, 20);
    }
}

