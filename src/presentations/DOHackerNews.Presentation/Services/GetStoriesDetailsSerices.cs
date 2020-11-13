using DOHackerNews.Presentation.Data;
using DOHackerNews.Presentation.DTO;
using DOHackerNews.WebAPI.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DOHackerNews.Presentation.Services
{
    public class GetStoriesDetailsSerices : BaseServices, IGetStoriesDetailsSerices
    {
        private readonly IBestStoriesDetailsRepository _bestStoriesDetailsRepository;

        public GetStoriesDetailsSerices(IBestStoriesDetailsRepository bestStoriesDetailsRepository)
        {
            _bestStoriesDetailsRepository = bestStoriesDetailsRepository;
        }

        public async Task<IEnumerable<BestStorieDetailOutputDTO>> Execute()
        {
            var DataResult = await _bestStoriesDetailsRepository.GetBestStoriesDetails();
            
            return DeserializeObjectResponse<IEnumerable<BestStorieDetailOutputDTO>>(DataResult)
             .ToList()
             .OrderByDescending(c => c.Score);
        }
    }
}
