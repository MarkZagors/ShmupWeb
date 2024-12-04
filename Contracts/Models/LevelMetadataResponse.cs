namespace ShmupCreator.Contracts;

public class LevelMetadataResponse
{
    public int LevelID { get; set; }
    public String? LevelName { get; set; }
    // public required int CreatorAccountId { get; set; }
    public double? Difficulty { get; set; }
    public int? LevelScriptId { get; set; }
    public int? MusicId { get; set; }
}
