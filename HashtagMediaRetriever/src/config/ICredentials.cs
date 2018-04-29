using System.Collections.Generic;

namespace HashtagMediaRetriever.src.config {
    interface ICredentials {
		Dictionary<string, string> Credentials { get; set; }
    }
}
