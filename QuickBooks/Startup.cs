using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
public class Startup
{
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    
    // Extract QuickBooks configurations
    var clientId = Configuration["QuickBooks:ClientId"];
    var clientSecret = Configuration["QuickBooks:ClientSecret"];

    // Register QuickBooksService with HttpClient and configurations
    services.AddHttpClient<QuickBooksService>(client =>
    {
        // Optionally configure HttpClient here if needed
    })
    .ConfigureHttpClient((serviceProvider, httpClient) =>
    {
        // Get clientId and clientSecret from your configuration
        var quickBooksService = serviceProvider.GetRequiredService<IConfiguration>();
        var clientId = quickBooksService["QuickBooks:ClientId"];
        var clientSecret = quickBooksService["QuickBooks:ClientSecret"];
        return new QuickBooksService(httpClient, clientId, clientSecret);
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
