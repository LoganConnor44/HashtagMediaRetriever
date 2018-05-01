using System;
using Xunit;
using HashtagMediaRetriever.src.products;

namespace HashtagMediaRetrieverTests {
    public class TwitterTests {
        [Fact]
        public void TestInstantiation() {
			var twitter = new Twitter();
			Assert.Equal(typeof(Twitter), twitter.GetType());
		}

		[Fact]
		public void TestReturnString() {
			var twitter = new Twitter();
			var results = twitter.GetSearchFor("#InfinityWar");
			Assert.Equal(typeof(string), results.GetType());
		}
    }
}