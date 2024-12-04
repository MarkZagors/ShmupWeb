using FluentValidation;
using ShmupCreator.Contracts;

namespace ShmupCreator.Controllers.Validation;

public class DeleteLevelMetadataValidator : AbstractValidator<DeleteLevelMetadataRequest>
{
    public DeleteLevelMetadataValidator()
    {
        RuleFor(levelMetadata => levelMetadata.LevelID).NotEmpty();
    }
}
