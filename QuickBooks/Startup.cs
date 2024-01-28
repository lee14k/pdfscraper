using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    private readonly IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    var clientId = Configuration["QuickBooks:ClientId"];
    var clientSecret = Configuration["QuickBooks:ClientSecret"];

    // Register QuickBooksService with HttpClient and configurations
    services.AddHttpClient<QuickBooksService>()
            .ConfigureHttpClient(httpClient =>
            {
                // Optionally configure HttpClient here if needed
            });

    // Register clientId and clientSecret as singleton if they are needed in QuickBooksService
    services.AddSingleton(clientId);
    services.AddSingleton(clientSecret);
}

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
