using Npgsql;
using Dapper;

using ShmupCreator.Repositories.Models;
using ShmupCreator.Repositories.Queries;

namespace ShmupCreator.Repositories;

public interface ILevelMetadataRepository
{
    Task Delete(LevelMetadata levelMetadata);
    Task<IEnumerable<LevelMetadata>> GetAll();
    Task<LevelMetadata> Insert(LevelMetadata levelMetadata);
    Task<LevelMetadata> Update(LevelMetadata levelMetadata);
}

public class LevelMetadataRepository : ILevelMetadataRepository
{
    private const string connString = "Server=localhost;Port=5432;User Id=postgres;Password=FFtest4;Database=mydb;";

    private async Task<LevelMetadata> GetLevelMetadataById(NpgsqlConnection con, int id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);
        var sql = LevelMetadataQueries.GetLevelMetadataById;
        return await con.QuerySingleAsync<LevelMetadata>(sql, parameters);
    }

    public async Task<LevelMetadata> Insert(LevelMetadata levelMetadata)
    {
        using (var con = new NpgsqlConnection(connString))
        {
            var sql = LevelMetadataQueries.InsertLevelMetadataByName;
            int levelID = await con.QuerySingleAsync<int>(sql, levelMetadata);
            return await GetLevelMetadataById(con, levelID);
        }
    }

    public async Task<IEnumerable<LevelMetadata>> GetAll()
    {
        using (var con = new NpgsqlConnection(connString))
        {
            var sql = LevelMetadataQueries.GetLevelMetadataAll;
            return await con.QueryAsync<LevelMetadata>(sql);
        }
    }

    public async Task<LevelMetadata> Update(LevelMetadata levelMetadata)
    {
        using (var con = new NpgsqlConnection(connString))
        {
            var sql = LevelMetadataQueries.UpdateLevelMetadata;
            int levelID = await con.QuerySingleAsync<int>(sql, levelMetadata);
            return await GetLevelMetadataById(con, levelID);
        }
    }

    public async Task Delete(LevelMetadata levelMetadata)
    {
        using (var con = new NpgsqlConnection(connString))
        {
            var sql = LevelMetadataQueries.DeleteLevelMetadata;
            await con.ExecuteAsync(sql, levelMetadata);
        }
    }
}
