namespace ShmupCreator.Services;

using Npgsql;
using ShmupCreator.Contracts;
using ShmupCreator.Repositories;
using ShmupCreator.Services.Models;

public class LevelMetadataService
{
    private const string connString = "Server=localhost;Port=5432;User Id=postgres;Password=FFtest4;Database=mydb;";

    public async Task CreateNew(LevelMetadataCreate levelMetadataCreate)
    {
        //One line service
        //TODO move to repo
        using (var con = new NpgsqlConnection(connString))
        {
            con.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            await LevelMetadataRepository.CreateNew(cmd, new Repositories.Models.LevelMetadataCreate
            {
                LevelName = levelMetadataCreate.LevelName
            });
            con.Close();
        }
    }

    // TODO change to metadata service model
    public async Task<ICollection<LevelMetadata>> GetAll()
    {
        var con = new NpgsqlConnection(connString);
        con.Open();
        var cmd = new NpgsqlCommand();
        cmd.Connection = con;
        var reader = await LevelMetadataRepository.GetAll(cmd);
        var result = new List<LevelMetadata>();
        while (await reader.ReadAsync())
        {
            result.Add(new LevelMetadata
            {
                LevelID = (int)reader["level_id"],
                LevelName = (string)reader["level_name"],
            });
        }
        con.Close();
        return result;
    }

    public async Task Update(LevelMetadataUpdate levelMetadataUpdate)
    {
        // var requestBody = await Request.ReadFromJsonAsync
        var con = new NpgsqlConnection(connString);
        con.Open();
        var cmd = new NpgsqlCommand();
        cmd.Connection = con;
        await LevelMetadataRepository.Update(cmd, new Repositories.Models.LevelMetadataUpdate
        {
            LevelID = levelMetadataUpdate.LevelID,
            LevelName = levelMetadataUpdate.LevelName
        });
        con.Close();
    }

    public async Task Delete(LevelMetadataDelete levelMetadataDelete)
    {
        // var requestBody = await Request.ReadFromJsonAsync
        var con = new NpgsqlConnection(connString);
        con.Open();
        var cmd = new NpgsqlCommand();
        cmd.Connection = con;
        await LevelMetadataRepository.Delete(cmd, new Repositories.Models.LevelMetadataDelete
        {
            LevelID = levelMetadataDelete.LevelID
        });
        con.Close();
    }
}
