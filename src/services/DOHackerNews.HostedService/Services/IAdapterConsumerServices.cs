using DOHackerNews.HostedService.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOHackerNews.HostedService.Services
{
    public interface IAdapterConsumerServices
    {
        Task<IEnumerable<int>> GetBestStories();
        Task<BestStorieDetailInputDTO> GetBestStoriesDetail(int storiesIds);

    }

}
