using System;
using System.Collections.Generic;
using System.Text;

namespace HashtagMediaRetriever.src.config {
    interface ICredentials {
		Dictionary<string, string> Credentials { get; set; }
    }
}
