using FluentValidation;
using ShmupCreator.Contracts;

public class DeleteLevelMetadataValidator : AbstractValidator<DeleteLevelMetadataRequest>
{
    public DeleteLevelMetadataValidator()
    {
        RuleFor(levelMetadata => levelMetadata.LevelID).NotEmpty();
    }
}
