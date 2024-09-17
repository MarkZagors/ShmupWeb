using ShmupCreator.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShmupCreator.Services;
using ShmupCreator.Repositories;

namespace Main;

public class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddMvc().AddApplicationPart(
            typeof(LevelMetadataController).Assembly).AddControllersAsServices();

        builder.Services.AddScoped<ILevelMetadataService, LevelMetadataService>();
        builder.Services.AddScoped<ILevelMetadataRepository, LevelMetadataRepository>();
        builder.Services.AddScoped<ILevelMetadataControllerMapper, LevelMetadataControllerMapper>();
        builder.Services.AddScoped<ILevelMetadataServiceMapper, LevelMetadataServiceMapper>();
        // var builder = Host.CreateDefaultBuilder(args);
        // builder
        // .ConfigureServices((hostContext, services) =>
        // {
        //     services.AddMvc().AddApplicationPart(
        //         typeof(LevelMetadataController).Assembly).AddControllersAsServices();
        // });

        // builder.Services.AddSingleton<LevelMetadataService>();
        //Gets Controllers in the Api csproj

        var host = builder.Build();
        host.MapControllers();
        host.Run();
    }
}
