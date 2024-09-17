namespace ShmupCreator.Repositories.Queries;

public static class LevelMetadataQueries
{
    public static string GetLevelMetadataById => "SELECT * FROM level_metadata WHERE LevelID=@Id;";
    public static string GetLevelMetadataAll => "SELECT * FROM level_metadata;";
    public static string InsertLevelMetadataByName => "INSERT INTO level_metadata (LevelName) VALUES (@LevelName) RETURNING LevelID;";
    public static string UpdateLevelMetadata => "UPDATE level_metadata SET LevelName=@LevelName WHERE LevelID=@LevelID RETURNING LevelID;";
    public static string DeleteLevelMetadata => "DELETE FROM level_metadata WHERE LevelID=@LevelID";
}
