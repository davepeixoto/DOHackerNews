using DOHackerNews.HostedService.Data;
using DOHackerNews.HostedService.DTO;
using DOHackerNews.HostedService.Extensions;
using DOHackerNews.HostedService.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DOHackerNews.HostedService.BackgroundOp
{
    public class MonitoringHackerNewsHostedService : BackgroundService
    {
        // IOptions<AppSettings> settings
        private readonly IServiceProvider _serviceProvider;
        private IAdapterConsumerServices _adapterConsumerServices;
        private IBestStoriesDetailsRepository _bestStoriesDetailsRepository;
        private int _numberOfResults;

        public MonitoringHackerNewsHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                await DoWork(stoppingToken);
                await Task.Delay(TimeSpan.FromMinutes(1));

            }

        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {

                _numberOfResults = (scope.ServiceProvider.GetRequiredService<IOptions<AppSettings>>()).Value.NumberOfResults;
                _adapterConsumerServices = scope.ServiceProvider.GetRequiredService<IAdapterConsumerServices>();
                _bestStoriesDetailsRepository = scope.ServiceProvider.GetRequiredService<IBestStoriesDetailsRepository>();



                var storiesIds = (await _adapterConsumerServices.GetBestStories()).ToArray();
                var bestStoriesDetails = new List<BestStorieDetailInputDTO>();


                var task = storiesIds[.._numberOfResults].ToList().Select(async (storieId) =>
                {
                    var response = await _adapterConsumerServices.GetBestStoriesDetail(storieId);

                    bestStoriesDetails.Add(await _adapterConsumerServices.GetBestStoriesDetail(storieId));

                });
                await Task.WhenAll(task);

                await _bestStoriesDetailsRepository.SetBestStoriesDetails(bestStoriesDetails);

            }
        }


        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            await base.StopAsync(stoppingToken);
        }
    }
}
