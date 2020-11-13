using DOHackerNews.Presentation.Data;
using DOHackerNews.Presentation.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DOHackerNews.Presentation.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Data
            services.AddScoped<IBestStoriesDetailsRepository, BestStoriesDetailsRepository>();
            services.AddScoped<IRedisConnection, RedisContext>();


            //Services
            services.AddScoped<IGetStoriesDetailsSerices, GetStoriesDetailsSerices>();


        }
    }
}
