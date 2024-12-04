using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Json;
using ShmupCreator.Contracts;
using ShmupCreator.Controllers;
using ShmupCreator.Controllers.Mappers;
using ShmupCreator.Controllers.Validation;
using ShmupCreator.Repositories;
using ShmupCreator.Services;
using ShmupCreator.Services.Mappers;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().AddApplicationPart(
            typeof(LevelMetadataController).Assembly).AddControllersAsServices();
        services.AddScoped<ILevelMetadataService, LevelMetadataService>();
        services.AddScoped<ILevelMetadataRepository, LevelMetadataRepository>();

        services.AddScoped<ILevelMetadataControllerMapper, LevelMetadataControllerMapper>();
        services.AddScoped<ILevelMetadataServiceMapper, LevelMetadataServiceMapper>();

        services.AddScoped<IValidator<CreateLevelMetadataRequest>, CreateLevelMetadataValidator>();
        services.AddScoped<IValidator<UpdateLevelMetadataRequest>, UpdateLevelMetadataValidator>();
        services.AddScoped<IValidator<DeleteLevelMetadataRequest>, DeleteLevelMetadataValidator>();

        // services.AddLogging();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        ConfigureLogging();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    private void ConfigureLogging()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            // .WriteTo.File(formatter: new JsonFormatter(), "Logging/log.txt")
            .WriteTo.File("Logging/log.txt")
            .CreateLogger();
    }
}
