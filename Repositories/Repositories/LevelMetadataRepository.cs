using Npgsql;
using ShmupCreator.Repositories.Models;

namespace ShmupCreator.Repositories;

public class LevelMetadataRepository
{
    //TODO ADD DI
    // TODO ADD DAPPER
    public static async Task CreateNew(NpgsqlCommand cmd, LevelMetadataCreate levelMetadataCreate)
    {
        cmd.CommandText = $"INSERT INTO level_metadata (level_name) VALUES ('{levelMetadataCreate.LevelName}');";
        await cmd.ExecuteNonQueryAsync();
    }

    public static async Task<NpgsqlDataReader> GetAll(NpgsqlCommand cmd)
    {
        cmd.CommandText = $"SELECT * FROM level_metadata";
        var reader = await cmd.ExecuteReaderAsync();
        return reader;
    }

    public static async Task Update(NpgsqlCommand cmd, LevelMetadataUpdate levelMetadataUpdate)
    {
        cmd.CommandText = $"UPDATE level_metadata SET level_name='{levelMetadataUpdate.LevelName}' WHERE level_id={levelMetadataUpdate.LevelID}";
        await cmd.ExecuteNonQueryAsync();
    }

    public static async Task Delete(NpgsqlCommand cmd, LevelMetadataDelete levelMetadataDelete)
    {
        cmd.CommandText = $"DELETE FROM level_metadata WHERE level_id={levelMetadataDelete.LevelID}";
        await cmd.ExecuteNonQueryAsync();
    }
}
