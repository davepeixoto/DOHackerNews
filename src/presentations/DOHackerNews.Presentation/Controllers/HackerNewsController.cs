using DOHackerNews.Core.DomainObjects;
using DOHackerNews.Presentation.Data;
using DOHackerNews.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DOHackerNews.Presentation.Controllers
{
    public class HackerNewsController : MainController
    {
        private readonly IBestStoriesDetailsRepository _bestStoriesDetailsRepository;

        public HackerNewsController(IBestStoriesDetailsRepository bestStoriesDetailsRepository)
        {
            _bestStoriesDetailsRepository = bestStoriesDetailsRepository;
        }



        /// <summary>
        /// Get a List of Best Hacker News Stories
        /// </summary>
        /// <returns></returns>
        [ProducesDefaultResponseType(typeof(BestStoriesDetail))]

        [HttpGet]
        public async Task<IActionResult> GetBestStories()
        {
            return CustomResponse(await _bestStoriesDetailsRepository.GetBestStoriesDetails());
        }
    }
}
