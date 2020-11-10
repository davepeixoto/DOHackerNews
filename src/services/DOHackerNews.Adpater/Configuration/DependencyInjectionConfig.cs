using DOHackerNews.Adpater.Services;
using DOHackerNews.WebAPI.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;

namespace DOHackerNews.Adpater.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpClient<IHackerNewsService, HackerNewsService>()
                .AddPolicyHandler(PollyExtensions.WaitAndTry())
                .AddTransientHttpErrorPolicy(
                    p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

        }
    }
}
