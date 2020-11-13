using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace DOHackerNews.HostedService.Data
{
    public interface IRedisConnection
    {
        IDatabase Database();
    }

    public class RedisContext : IRedisConnection
    {
        private readonly IConfiguration _configuration;

        public RedisContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IDatabase Database()
        {
            var conexaoRedis = ConnectionMultiplexer.Connect(
            _configuration.GetConnectionString("RedisServer"));

            return conexaoRedis.GetDatabase();
        }
    }


}
