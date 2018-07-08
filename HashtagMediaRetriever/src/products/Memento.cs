using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi.Models;
using Tweetinvi.Logic.TwitterEntities;

namespace HashtagMediaRetriever.src.products {

    /// <summary>
    /// A class to define a Memento.
    /// </summary>
    public class Memento {

        /// <summary>
        /// Any text associated with a Memento.
        /// </summary>
        public string comment;

        /// <summary>
        /// A list of media that are associated with a Memento.
        /// </summary>
        public List<Media> memories;

        /// <summary>
        /// The person a Memento belongs to.
        /// </summary>
        public string owner;

        /// <summary>
        /// The social media a Memento was created from.
        /// </summary>
        public string type;

        /// <summary>
        /// The date of the Memento.
        /// </summary>
        public DateTime creation;

        /// <summary>
        /// The constructor for a Memento created by Twitter.
        /// 
        /// Sets:
        /// * the owner
        /// * the comment
        /// * the type
        /// * a list of memories
        /// </summary>
        /// <param name="tweet"></param>
        public Memento(ITweet tweet) {
            this.owner = tweet.CreatedBy.Name;
            this.comment = tweet.FullText;
            this.type = "twitter";
            this.memories = new List<Media>();

            foreach (MediaEntity media in tweet.Media) {
                this.memories.Add(this.GetMemory(media));
            }
        }

        /// <summary>
        /// Returns a memory and differentiates between videos/gifs and everything else.
        /// 
        /// Steps:
        /// * Creates a local memory and sets the id and media type
        /// * sets the media url
        /// </summary>
        /// <param name="media"></param>
        /// <returns></returns>
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