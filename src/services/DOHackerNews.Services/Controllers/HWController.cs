using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace DOHackerNews.Services.Controllers
{
    [Route("api")]
    [ApiController]
    public class HWController : ControllerBase
    {

        private readonly IConfiguration _config;

        public HWController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("storiesDetails")]
        public async Task<IActionResult> GetStoriesDetails(

            )
        {
            var conexaoRedis = ConnectionMultiplexer.Connect(
           _config.GetConnectionString("RedisServer"));

            var dbRedis = conexaoRedis.GetDatabase();

            var rs = dbRedis.StringGet("bestStories");


            return Ok(rs);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {


            var conexaoRedis = ConnectionMultiplexer.Connect(
               _config.GetConnectionString("RedisServer"));
            string valorJSON = "";

            //            var bestStories =await _adapter.GetBestStoriesDetail(await _adapter.GetBestStories());



            //bestStories.ToList().ForEach(bestStore =>
            //{
            //    valorJSON += JsonSerializer.Serialize(bestStore);
            //});



            DistributedCacheEntryOptions opcoesCache =
                      new DistributedCacheEntryOptions();
            opcoesCache.SetAbsoluteExpiration(
                TimeSpan.FromMinutes(5));

            var dbRedis = conexaoRedis.GetDatabase();
            //cache.SetString("Cotacoes", valorJSON, opcoesCache);
            //}
            dbRedis.StringSet(
                  "bestStories",
                  JsonSerializer.Serialize(valorJSON),
                  expiry: null);

            return Content(valorJSON, "application/json");
        }


    }
}
