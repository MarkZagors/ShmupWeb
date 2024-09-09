using System.Data;
using Dapper;

namespace ShmupCreator.Repositories.Helpers;

public class DbContext
{
    private const string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=FFtest4;Database=mydb;";

    // public IDbConnection CreateConnection() {
    // }
}
