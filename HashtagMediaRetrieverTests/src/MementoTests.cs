using System;
using Xunit;
using HashtagMediaRetriever.src.products;
using System.Collections.Generic;
using System.Linq;

namespace HashtagMediaRetrieverTests.src {
    public class MementoTests {

        [Fact]
        public void TestCreateMemento() {
            List<Memento> mementos = new List<Memento>();
            var twitter = new Twitter();
            var tweets = twitter.GetSearchFor("#InfinityWar");
            var mediaOnly = twitter.GetTweetsWithMedia(tweets);

            foreach (Tweetinvi.Models.ITweet tweet in mediaOnly) {
                var memento = new Memento(tweet);
                mementos.Add(memento);
            }
            Assert.Equal(typeof(List<Memento>), mementos.GetType());
            Assert.True(mementos.Count() > 0);
        }

        [Fact]
        ///not really a test - just development code
        public void TestIdentifyMediaTypes() {
            var twitter = new Twitter();
            var results = twitter.GetSearchFor("#InfinityWar");
            var mediaOnly = twitter.GetTweetsWithMedia(results);
            twitter.CreateMementos(mediaOnly);

            List<string> typesOfMedia = new List<string>();
            List<string> mediaUrl = new List<string>();
            foreach (var memory in mediaOnly) {
                foreach (var med in memory.Media) {
                    if (med.MediaType.ToLower() != "photo" && !typesOfMedia.Contains(med.MediaType)) {
                        typesOfMedia.Add(med.MediaType);
                        mediaUrl.Add(med.MediaURL);
                    }
                }
            }

            List<string> typesOfMedia2 = new List<string>();
            List<string> mediaUrl2 = new List<string>();
            foreach (var memento in twitter.Mementos) {
                foreach (var mem in memento.memories) {
                    if (mem.mediaType.ToLower() != "photo" && !typesOfMedia2.Contains(mem.mediaType)) {
                        typesOfMedia2.Add(mem.mediaType);
                        mediaUrl2.Add(mem.url);
                    }
                }
            }
        }
    }
}
