using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi.Models;
using Tweetinvi.Logic.TwitterEntities;

namespace HashtagMediaRetriever.src.products {
    public class Memento {
        public string comment;
        public List<Media> memories;
        public string owner;
        public string type;
        public DateTime creation;

        public Memento(ITweet tweet) {
            this.owner = tweet.CreatedBy.Name;
            this.comment = tweet.FullText;
            this.type = "twitter";
            this.memories = new List<Media>();

            foreach (MediaEntity media in tweet.Media) {
                this.memories.Add(this.GetMemory(media));
            }
        }

        private Media GetMemory(MediaEntity media) {
            var tempMemory = new Media() {
                id = media.Id,
                mediaType = media.MediaType
            };
            if (tempMemory.mediaType.ToLower().Contains("video") ||
                tempMemory.mediaType.ToLower().Contains("gif")) {
                foreach (var vid in media.VideoDetails.Variants) {
                    if (vid.ContentType.ToLower().Contains("video")) {
                        tempMemory.url = vid.URL;
                        break;
                    }
                }
            } else {
                tempMemory.url = media.MediaURLHttps;
            }
            return tempMemory;
        }
    }
}