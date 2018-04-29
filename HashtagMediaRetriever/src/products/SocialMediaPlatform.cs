using System;
using System.Collections.Generic;
using System.Text;
using HashtagMediaRetriever.src.config;

namespace HashtagMediaRetriever.src.products {
    abstract class SocialMediaPlatform {
		protected string Name { get; set; }
		protected string Hashtag { get; set; }
		protected Dictionary<int, Media> Media { get; set; }
		protected ICredentials Authentication { get; set; }
    }
}