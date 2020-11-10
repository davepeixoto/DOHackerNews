using DOHackerNews.Adpater.Services;
using DOHackerNews.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace DOHackerNews.Adpater.Controllers
{
    public class AdapterController : MainController
    {
        private readonly IHackerNewsService _hackerNewsService;

        public AdapterController(IHackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
        }

        /// <summary>
        ///  Go to Hacker News Portal and Get Ids of Best stories
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> Get()
        {

            return CustomResponse(await _hackerNewsService.GetBestStories());
        }


        /// <summary>
        /// Go to Hacker News Portal and get details from the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return CustomResponse(await _hackerNewsService.GetBestStoriesDetail(id));
        }


    }
}
