using System;
using System.Collections.Generic;
using System.Linq;

namespace DOHackerNews.Core.DomainObjects
{
    public class BestStoriesDetail
    {
        private readonly string uri;
        public BestStoriesDetail(string title, string uri, string postedBy, double? time, int? score, IEnumerable<int> commentCount)
        {
            Title = title;
            this.uri = uri;
            PostedBy = postedBy;
            Score = score;
            CommentCount = commentCount.Count();
            if (time != null) { Time = UnixTimeStampToDateTime((double)time); }


        }


        public string Title { get; set; }
        public string Uri { get => uri is null ? "" : new Uri(uri).ToString(); }
        public string PostedBy { get; set; }
        public DateTime? Time { get; set; }
        public int? Score { get; set; }
        public int? CommentCount { get; set; }


        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();

            return dtDateTime;
        }
    }
}
