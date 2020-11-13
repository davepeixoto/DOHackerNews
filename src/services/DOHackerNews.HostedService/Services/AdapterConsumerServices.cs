using DOHackerNews.HostedService.DTO;
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

        public AdapterConsumerServices(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.AdapterApiUrl??"#");
        }

        public async Task<IEnumerable<int>> GetBestStories()
        {
            var response = await _httpClient.GetAsync("");

            ErrorHandlerResponse(response);

            return await DeserializeObjectResponse<IEnumerable<int>>(response);

        }

        public async Task<BestStorieDetailInputDTO> GetBestStoriesDetail(int storieId)
        {
            var response = await _httpClient.GetAsync($"/api/{storieId}");
            ErrorHandlerResponse(response);


            return await DeserializeObjectResponse<BestStorieDetailInputDTO>(response);
        }



    }




}
