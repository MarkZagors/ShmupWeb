namespace ShmupCreator.Contracts;

public class UpdateLevelMetadataRequest
{
    public required int LevelID { get; set; }
    public required String LevelName { get; set; }
}
