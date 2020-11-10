using DOHackerNews.Core.Constants;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace DOHackerNews.Presentation.Data
{
    public class BestStoriesDetailsRepository : IBestStoriesDetailsRepository
    {
        private readonly IDatabase _redisDb;

        public BestStoriesDetailsRepository(IRedisConnection redisConnection)
        {
            _redisDb = redisConnection.Database();
        }

        public async Task<string> GetBestStoriesDetails()
        {
            return await _redisDb.StringGetAsync(BestStoriesDetailsConstant.Key);
        }

    }

    public interface IBestStoriesDetailsRepository
    {
        Task<string> GetBestStoriesDetails();
    }
}
