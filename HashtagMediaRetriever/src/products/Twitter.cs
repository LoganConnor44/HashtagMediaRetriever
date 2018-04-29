using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;
using HashtagMediaRetriever.src.config;

namespace HashtagMediaRetriever.src.products {
    class Twitter : SocialMediaPlatform {
		public Twitter() {
			this.Name = "twitter";
			this.Authentication = new TwitterCredentials();
			Auth.SetUserCredentials(
				this.Authentication.Credentials["TWITTER_TOKEN"],
				this.Authentication.Credentials["TWITTER_TOKEN_SECRET"],
				this.Authentication.Credentials["TWITTER_KEY"],
				this.Authentication.Credentials["TWITTER_SECRET"]
			);
		}
    }
}