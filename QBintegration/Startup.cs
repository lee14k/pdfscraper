using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickBooksService.Services;

namespace QuickBooks {
    public class Startup{
        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }
        public IConfiguration Configuration {get;}
        public void ConfigureServies(IServiceCollection services){
            services.AddMvc();
            services.AddHttpClient<IQuickBooksService, QuickBooksService>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
         app.UseRouting();
         app.UseEndpoints(endpoints => {
             endpoints.MapControllers();
         });
        }
    }
}