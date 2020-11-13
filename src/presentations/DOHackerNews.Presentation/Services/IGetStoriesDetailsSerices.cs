using DOHackerNews.Presentation.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOHackerNews.Presentation.Services
{
    public interface IGetStoriesDetailsSerices
    {
        Task<IEnumerable<BestStorieDetailOutputDTO>> Execute();
    }
}
