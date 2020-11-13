using DOHackerNews.HostedService.BackgroundOp;
using DOHackerNews.HostedService.Data;
using DOHackerNews.HostedService.Extensions;
using DOHackerNews.HostedService.Services;
using DOHackerNews.WebAPI.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;

namespace DOHackerNews.HostedService.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpClient<IAdapterConsumerServices, AdapterConsumerServices>()
                .AddPolicyHandler(PollyExtensions.WaitAndTry())
                .AddTransientHttpErrorPolicy(
                    p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

            services.AddScoped<IBestStoriesDetailsRepository, BestStoriesDetailsRepository>();
            services.AddScoped<IRedisConnection, RedisContext>();
            services.AddHostedService<MonitoringHackerNewsHostedService>();


        }
    }
}
