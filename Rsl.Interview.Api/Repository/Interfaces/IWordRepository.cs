using Rsl.Interview.Api.Models;
using Rsl.Interview.Api.Models.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rsl.Interview.Api.Repository.Interfaces
{
    public interface IWordRepository
    {
        Task<List<SearchTermHistory>> GetSearchTermHistory(string searchTerm);
        Task<SearchTermHistory> InsertSearchTermHistory(string searchTerm);
        Task<SearchResultsHistory> InsertSearchResultsHistory(List<SearchResult> searchResults, int searchTermHistoryId);
        Task<List<SearchResultsHistory>> GetSearchResultHistory(int searchTermHistoryId);
        Task<List<SearchResult>> SearchResultsFromDictionaryApi(string searchTerm);
    }
}
