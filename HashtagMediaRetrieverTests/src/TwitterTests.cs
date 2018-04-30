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
    }
}