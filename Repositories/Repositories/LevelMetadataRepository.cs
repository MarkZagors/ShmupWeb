using Npgsql;
using Dapper;

using ShmupCreator.Repositories.Models;

namespace ShmupCreator.Repositories;

public class LevelMetadataRepository
{
    private const string connString = "Server=localhost;Port=5432;User Id=postgres;Password=FFtest4;Database=mydb;";

    private async Task<LevelMetadata> GetLevelMetadataById(NpgsqlConnection con, int id)
    {
        var sql = $"SELECT * FROM level_metadata WHERE LevelID={id}";
        return await con.QuerySingleAsync<LevelMetadata>(sql);
    }

    public async Task<LevelMetadata> Insert(LevelMetadata levelMetadata)
    {
        using (var con = new NpgsqlConnection(connString))
        {
            var sql = $"INSERT INTO level_metadata (LevelName) VALUES (@LevelName) RETURNING LevelID;";
            int levelID = await con.QuerySingleAsync<int>(sql, levelMetadata);
            return await GetLevelMetadataById(con, levelID);
        }
    }

    public async Task<IEnumerable<LevelMetadata>> GetAll()
    {
        using (var con = new NpgsqlConnection(connString))
        {
            var sql = $"SELECT * FROM level_metadata";
            return await con.QueryAsync<LevelMetadata>(sql);
        }
    }

    public async Task<LevelMetadata> Update(LevelMetadata levelMetadata)
    {
        using (var con = new NpgsqlConnection(connString))
        {
            var sql = $"UPDATE level_metadata SET LevelName=@LevelName WHERE LevelID=@LevelID RETURNING LevelID";
            int levelID = await con.QuerySingleAsync<int>(sql, levelMetadata);
            return await GetLevelMetadataById(con, levelID);
        }
    }

    public async Task Delete(LevelMetadata levelMetadata)
    {
        using (var con = new NpgsqlConnection(connString))
        {
            var sql = $"DELETE FROM level_metadata WHERE LevelID=@LevelID";
            await con.ExecuteAsync(sql, levelMetadata);
        }
    }
}
