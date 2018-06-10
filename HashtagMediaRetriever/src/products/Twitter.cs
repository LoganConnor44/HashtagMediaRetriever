using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;
using HashtagMediaRetriever.src.config;
using System.Linq;

namespace HashtagMediaRetriever.src.products {
    public class Twitter : SocialMediaPlatform {

		public Twitter() {
			this.Name = "twitter";
			this.Authentication = new TwitterCredentials();
			var appCreds = Auth.SetApplicationOnlyCredentials(
				this.Authentication.Credentials["TWITTER_KEY"],
				this.Authentication.Credentials["TWITTER_SECRET"],
				true
			);
			Auth.InitializeApplicationOnlyCredentials(appCreds);
		}

		public IEnumerable<Tweetinvi.Models.ITweet> GetSearchFor(string search) {
			var  results = Search.SearchTweets(search);
			return results;
		}

        public IEnumerable<Tweetinvi.Models.ITweet> GetTweetsWithMedia(IEnumerable<Tweetinvi.Models.ITweet> tweets) {
            var results = tweets.Where(tweet => tweet.Media.Count > 0);
            return results;
        }

        public void CreateMementos(IEnumerable<Tweetinvi.Models.ITweet> tweets) {
            this.Mementos = new List<Memento>();
            foreach (Tweetinvi.Models.ITweet tweet in tweets) {
                var memento = new Memento(tweet);
                this.Mementos.Add(memento);
            }
        }
    }
}