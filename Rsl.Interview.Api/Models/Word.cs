using Rsl.Interview.Api.Models.Results;
using System.Collections.Generic;

namespace Rsl.Interview.Api.Models
{
    public class Word
    {
        public string SearchTerm { get; set; }
        public bool IsOffensive { get; set; }
        public List<SearchResult> SearchResults { get; set; }

        
    }
}
