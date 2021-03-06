﻿using DOHackerNews.Core.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DOHackerNews.Presentation.Configuration
{
    public static class RedisConfig
    {
        public static void DistributedRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration =
                    configuration.GetConnectionString("ConexaoRedis");
                options.InstanceName = BestStoriesDetailsConstant.NoSqlInstance;
            });
        }
    }
}
