using DOHackerNews.Core.Constants;
using DOHackerNews.HostedService.DTO;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace DOHackerNews.HostedService.Data
{

    public interface IBestStoriesDetailsRepository
    {
        Task SetBestStoriesDetails(IEnumerable<BestStorieDetailInputDTO> bestStories);
    }


    public class BestStoriesDetailsRepository : IBestStoriesDetailsRepository
    {
        private readonly IDatabase _redisDb;



        public BestStoriesDetailsRepository(IRedisConnection redisConnection)
        {
            _redisDb = redisConnection.Database();
        }

        public async Task SetBestStoriesDetails(IEnumerable<BestStorieDetailInputDTO> bestStories)
        {
            var rst = JsonSerializer.Serialize(bestStories);
            await _redisDb.StringSetAsync(BestStoriesDetailsConstant.Key, rst);
        }

    }

  
}
