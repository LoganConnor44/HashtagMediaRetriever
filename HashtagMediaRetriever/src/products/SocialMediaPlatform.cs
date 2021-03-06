﻿using System;
using System.Collections.Generic;
using System.Text;
using HashtagMediaRetriever.src.config;

namespace HashtagMediaRetriever.src.products {
    public abstract class SocialMediaPlatform {
		protected string Name { get; set; }
		protected string Hashtag { get; set; }
		protected Dictionary<int, Memory> Media { get; set; }
		protected ICredentials Authentication { get; set; }
        public List<Memento> Mementos { get; set; }
    }
}