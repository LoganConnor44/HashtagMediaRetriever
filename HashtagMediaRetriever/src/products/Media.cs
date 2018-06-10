using System;
using System.Collections.Generic;
using System.Text;

namespace HashtagMediaRetriever.src.products {
    public class Media {
        public long? id { get; set; }
        public string mediaURL { get; set; }
        public string mediaURLHttps { get; set; }
        public string url { get; set; }
        public string displayURL { get; set; }
        public string expandedURL { get; set; }
        public string mediaType { get; set; }
    }
}