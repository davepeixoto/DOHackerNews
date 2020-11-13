using System.Collections.Generic;

namespace DOHackerNews.Adpater.DTO
{
    public class HackerNewDetailInputDTO
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public string Type { get; set; }
        public string By { get; set; }
        public double Time { get; set; }
        public string Text { get; set; }
        public bool Dead { get; set; }
        public int Parent { get; set; }
        public int Poll { get; set; }
        public IEnumerable<int> Kids { get; set; }
        public string Url { get; set; }
        public int Score { get; set; }
        public string Title { get; set; }
        public IEnumerable<int> Parts { get; set; }
        public int Descendants { get; set; }

    }

}
