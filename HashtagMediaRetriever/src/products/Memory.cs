using System;
using System.Collections.Generic;
using System.Text;

namespace HashtagMediaRetriever.src.products {

    /// <summary>
    /// A class to define a Media object that can originate from any social media platform.
    /// </summary>
    public class Memory {

        /// <summary>
        /// An id that is set by the media entity itself.
        /// 
        /// May not be unique - need to create a new field specifically for database id.
        /// </summary>
        /// <value></value>
        public long? id { get; set; }

        public int MementoId { get; set; }
        public Memento Memento { get; set; }

        /// <summary>
        /// The direct url for a media entity.
        /// </summary>
        /// <value></value>
        public string mediaURL { get; set; }

        /// <summary>
        /// A security direct url for a media entity.
        /// </summary>
        /// <value></value>
        public string mediaURLHttps { get; set; }

        /// <summary>
        /// A url for the media entity.
        /// 
        /// May need to eliminate this and only use mediaURL
        /// </summary>
        /// <value></value>
        public string url { get; set; }

        /// <summary>
        /// A url for the Memento.
        /// </summary>
        /// <value></value>
        public string displayURL { get; set; }

        /// <summary>
        /// A url for a long url.
        /// </summary>
        /// <value></value>
        public string expandedURL { get; set; }

        /// <summary>
        /// The type of media stored.
        /// </summary>
        /// <value></value>
        public string mediaType { get; set; }
    }
}