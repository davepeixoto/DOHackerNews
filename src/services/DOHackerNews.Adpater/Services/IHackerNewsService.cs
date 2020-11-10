using DOHackerNews.Core.DomainObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOHackerNews.Adpater.Services
{
    public interface IHackerNewsService
    {
        Task<IEnumerable<int>> GetBestStories();
        Task<BestStoriesDetail> GetBestStoriesDetail(int storiesIds);

    }

}
