using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YourNamespace.Services; // Replace 'YourNamespace' with your actual namespace

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

        // Extract QuickBooks configurations
        var clientId = Configuration["QuickBooks:ClientId"];
        var clientSecret = Configuration["QuickBooks:ClientSecret"];

        // Register QuickBooksService with HttpClient and configurations
        services.AddHttpClient<QuickBooksService>()
                .ConfigureHttpClient((serviceProvider, httpClient) =>
                {
                    var quickBooksService = new QuickBooksService(httpClient, clientId, clientSecret);
                    return quickBooksService;
                });
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
