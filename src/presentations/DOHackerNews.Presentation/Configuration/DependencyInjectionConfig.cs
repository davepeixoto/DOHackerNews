using DOHackerNews.Presentation.Data;
using Microsoft.Extensions.DependencyInjection;

namespace DOHackerNews.Presentation.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {

            services.AddScoped<IBestStoriesDetailsRepository, BestStoriesDetailsRepository>();
            services.AddScoped<IRedisConnection, RedisContext>();

           
        }
    }
}
