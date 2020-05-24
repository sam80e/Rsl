using Newtonsoft.Json;

namespace Rsl.Interview.Api.Models.Results
{
    public class SearchResult
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
        
        [JsonProperty("shortdef")]
        public string[] Shortdef { get; set; }        
    }
}
