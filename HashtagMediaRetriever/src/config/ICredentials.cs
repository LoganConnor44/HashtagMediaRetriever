using System.Collections.Generic;

namespace HashtagMediaRetriever.src.config {
    public interface ICredentials {
		Dictionary<string, string> Credentials {
			get;
		}
    }
}
