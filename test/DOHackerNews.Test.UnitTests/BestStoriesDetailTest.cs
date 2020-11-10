using DOHackerNews.Core.DomainObjects;
using System;
using Xunit;

namespace DOHackerNews.Test.UnitTests
{
    public class BestStoriesDetailTest
    {
        [Fact]
        public void BestStoriesDetail_UnixDateTime_ShouldBeConvertedToUTC()
        {
            //Arrange
            var bestStoriesDetail = new BestStoriesDetail(
                time: 1604766347,
                title: "Biden wins White House, vowing new direction for divided U.S.",
                score: 3049,
                uri: "https://apnews.com/article/joe-biden-wins-white-house-ap-fd58df73aa677acb74fce2a69adb71f9",
                postedBy: "granzymes",
                commentCount: new int[] { 10, 50, 63 }
                );

            // Act

            Assert.Equal(Convert.ToDateTime("2020-11-07T16:25:47.0000000Z").ToUniversalTime(), bestStoriesDetail.Time);
            // Assert

        }
    }
}
