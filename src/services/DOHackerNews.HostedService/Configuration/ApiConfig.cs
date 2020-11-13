using DOHackerNews.HostedService.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DOHackerNews.HostedService.Configuration
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.Configure<AppSettings>(configuration);

            
        }

        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env){}
    }
}
