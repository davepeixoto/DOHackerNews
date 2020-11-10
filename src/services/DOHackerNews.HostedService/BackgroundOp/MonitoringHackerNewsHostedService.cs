using DOHackerNews.HostedService.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DOHackerNews.HostedService.BackgroundOp
{
    public class MonitoringHackerNewsHostedService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private IAdapterConsumerServices _adapterConsumerServices;
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }

        private async Task FeedingRedis()
        {
            using (var scope = _serviceProvider.CreateScope())
            {

                _adapterConsumerServices = scope.ServiceProvider.GetRequiredService<IAdapterConsumerServices>();

                var storiesIds = (await _adapterConsumerServices.GetBestStories()).ToArray();
                var bestStoriesDetails = new List<string>();
                var task = storiesIds[0..19].ToList().Select(async (storieId) =>
                {
                    var response = await _adapterConsumerServices.GetBestStoriesDetail(storieId);

                    bestStoriesDetails.Add(await _adapterConsumerServices.GetBestStoriesDetail(storieId));

                });
                await Task.WhenAll(task);

            }
        }
    }
}
