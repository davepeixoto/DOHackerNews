using DOHackerNews.Core.DomainObjects;
using DOHackerNews.Presentation.Data;
using DOHackerNews.Presentation.Services;
using DOHackerNews.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DOHackerNews.Presentation.Controllers
{
    public class HackerNewsController : MainController
    {
        private readonly IGetStoriesDetailsSerices _getStoriesDetailsSerices;

        public HackerNewsController(IGetStoriesDetailsSerices getStoriesDetailsSerices)
        {
            _getStoriesDetailsSerices = getStoriesDetailsSerices;
        }



        /// <summary>
        /// Get a List of Best Hacker News Stories
        /// </summary>
        /// <returns></returns>
        [ProducesDefaultResponseType(typeof(BestStoriesDetail))]

        [HttpGet]
        public async Task<IActionResult> GetBestStories()
        {

            return CustomResponse(await _getStoriesDetailsSerices.Execute());
        }
    }
}
