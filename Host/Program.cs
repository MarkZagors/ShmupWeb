using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace Main;

public class Program
{
    static void Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args);
        builder.ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
        builder.Build().Run();
    }
}
