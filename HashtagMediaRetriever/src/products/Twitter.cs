﻿using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;
using HashtagMediaRetriever.src.config;
using System.Linq;

namespace HashtagMediaRetriever.src.products {

	/// <summary>
	/// A class for retrieving Mementos from Twitter.
	/// </summary>
    public class Twitter : SocialMediaPlatform {

		/// <summary>
		/// A constructor that sets:
		/// * the name
		/// * authentication credentials
		/// Registers a call to Twitter
		/// </summary>
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

		/// <summary>
		/// Returns a collection of tweets the match the given search parameter.
		/// </summary>
		/// <param name="search"></param>
		/// <returns></returns>
		public IEnumerable<Tweetinvi.Models.ITweet> GetSearchFor(string search) {
			var results = Search.SearchTweets(search);
			return results;
		}

		/// <summary>
		/// Only returns tweets that contain media.
		/// </summary>
		/// <param name="tweets"></param>
		/// <returns></returns>
        public IEnumerable<Tweetinvi.Models.ITweet> GetTweetsWithMedia(IEnumerable<Tweetinvi.Models.ITweet> tweets) {
            var results = tweets.Where(tweet => tweet.Media.Count > 0);
            return results;
        }

		/// <summary>
		/// Sets a list of Memento objects from the given tweet parameter.
		/// </summary>
		/// <param name="tweets"></param>
        public void CreateMementos(IEnumerable<Tweetinvi.Models.ITweet> tweets) {
            this.Mementos = new List<Memento>();
            foreach (Tweetinvi.Models.ITweet tweet in tweets) {
                var memento = new Memento(tweet);
                this.Mementos.Add(memento);
            }
        }
    }
}