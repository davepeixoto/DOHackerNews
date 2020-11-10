using DOHackerNews.Core.DomainObjects;
using DOHackerNews.HostedService.Extensions;
using DOHackerNews.WebAPI.Core.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DOHackerNews.HostedService.Services
{

    public class AdapterConsumerServices : BaseServices, IAdapterConsumerServices
    {
        private readonly HttpClient _httpClient;
        private readonly string BestStoriesIds;
        private readonly string BestStorieDetail;

        public AdapterConsumerServices(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.HackerNewsUrl);
            BestStoriesIds = settings.Value.BestStoriesIds;
            BestStorieDetail = settings.Value.BestStorieDetail;
        }

        public async Task<IEnumerable<int>> GetBestStories()
        {
            var response = await _httpClient.GetAsync(BestStoriesIds);

            ErrorHandlerResponse(response);

            return await DeserializeObjectResponse<IEnumerable<int>>(response);

        }

        public async Task<string> GetBestStoriesDetail(int storieId)
        {
            var response = await _httpClient.GetAsync(BestStorieDetail.Replace("{idStorie}", storieId.ToString()));
            ErrorHandlerResponse(response);

//            var hackerNewDetailDto = await DeserializeObjectResponse<HackerNewDetailDto>(response);

            return "";
        }



    }




}
