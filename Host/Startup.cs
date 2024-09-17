using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
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
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
