using DOHackerNews.Adpater.DTO;
using DOHackerNews.Adpater.Extensions;
using DOHackerNews.Core.DomainObjects;
using DOHackerNews.WebAPI.Core.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DOHackerNews.Adpater.Services
{

    public class HackerNewsService : BaseServices, IHackerNewsService
    {
        private readonly HttpClient _httpClient;
        private readonly string BestStoriesIds;
        private readonly string BestStorieDetail;

        public HackerNewsService(HttpClient httpClient, IOptions<AppSettings> settings)
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

        public async Task<BestStoriesDetail> GetBestStoriesDetail(int storieId)
        {
            var response = await _httpClient.GetAsync(BestStorieDetail.Replace("{idStorie}", storieId.ToString()));
            ErrorHandlerResponse(response);

            var hackerNewDetailDto = await DeserializeObjectResponse<HackerNewDetailInputDTO>(response);

            return Mapper_HackerNewDetailDto_to_BestStoriesDetail(hackerNewDetailDto);
        }


        private BestStoriesDetail Mapper_HackerNewDetailDto_to_BestStoriesDetail(HackerNewDetailInputDTO hackerNewDetailDto)
        {
            return new BestStoriesDetail(
                time: hackerNewDetailDto.Time,
                title: hackerNewDetailDto.Title,
                score: hackerNewDetailDto.Score,
                uri: hackerNewDetailDto.Url,
                postedBy: hackerNewDetailDto.By,
                commentCount: hackerNewDetailDto.Kids
                );
        }

    }


}
