using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;
using HashtagMediaRetriever.src.config;

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

		public string GetSearchFor(string search) {
			var  result = Search.SearchTweets(search);
			if (result == null) {
				return ExceptionHandler.GetLastException().TwitterDescription;
			}
			return result.ToJson();
		}
    }
}