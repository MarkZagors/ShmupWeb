using Npgsql;
using Dapper;
// using ShmupCreator.Repositories.Models;
using ShmupCreator.Contracts;

namespace ShmupCreator.Repositories;

public class LevelMetadataRepository
{
    private const string connString = "Server=localhost;Port=5432;User Id=postgres;Password=FFtest4;Database=mydb;";

    public async Task CreateNew(LevelMetadata levelMetadata)
    {
        using (var con = new NpgsqlConnection(connString))
        {
            var sql = $"INSERT INTO level_metadata (level_name) VALUES (@LevelName);";
            await con.ExecuteAsync(sql, levelMetadata);
        }
    }

    public async Task<IEnumerable<LevelMetadata>> GetAll()
    {
        using (var con = new NpgsqlConnection(connString))
        {
            var sql = $"SELECT level_id AS LevelID, level_name AS LevelName FROM level_metadata";
            return await con.QueryAsync<LevelMetadata>(sql);
        }
    }

    public async Task Update(LevelMetadata levelMetadata)
    {
        using (var con = new NpgsqlConnection(connString))
        {
            var sql = $"UPDATE level_metadata SET level_name=@LevelName WHERE level_id=@LevelID";
            await con.ExecuteAsync(sql, levelMetadata);
        }
    }

    public async Task Delete(LevelMetadata levelMetadata)
    {
        using (var con = new NpgsqlConnection(connString))
        {
            var sql = $"DELETE FROM level_metadata WHERE level_id=@LevelID";
            await con.ExecuteAsync(sql, levelMetadata);
        }
    }
}
