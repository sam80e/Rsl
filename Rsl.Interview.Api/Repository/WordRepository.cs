using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Rsl.Interview.Api.Models;
using Rsl.Interview.Api.Models.Results;
using Rsl.Interview.Api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rsl.Interview.Api.Repository
{
    public class WordRepository : IWordRepository
    {
        private readonly string accessKey = ConfigurationManager.Configuration["ApiConnection:ApiKey"];
        private readonly InterviewContext _context;
        public WordRepository(InterviewContext context)
        {
            _context = context;
        }

        public async Task<List<SearchTermHistory>> GetSearchTermHistory(string searchTerm)
        {
            SearchTermHistory termHistory = new SearchTermHistory();
            try
            {
                List<SearchTermHistory> termHistoryList = await _context.SearchTermHistory.Where(x => x.SearchTerm == searchTerm).ToListAsync();
                return termHistoryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public async Task<SearchTermHistory> InsertSearchTermHistory(string searchTerm)
        {
            SearchTermHistory searchTermHistory = new SearchTermHistory();
            try
            {
                searchTermHistory.SearchedOn = DateTime.Now;
                searchTermHistory.SearchTerm = searchTerm;
                _context.SearchTermHistory.Add(searchTermHistory);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchTermHistory;
        }

        public async Task<SearchResultsHistory> InsertSearchResultsHistory(List<SearchResult> searchResults, int searchTermHistoryId)
        {
            SearchResultsHistory searchResultsHistory = new SearchResultsHistory();
            try
            {
                searchResultsHistory.SearchTermHistoryId = searchTermHistoryId;
                searchResultsHistory.Result = JsonConvert.SerializeObject(searchResults);
                _context.SearchResultsHistory.Add(searchResultsHistory);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchResultsHistory;
        }
        public async Task<List<SearchResultsHistory>> GetSearchResultHistory(int searchTermHistoryId)
        {
            try
            {
                List<SearchResultsHistory> resultHistory = await _context.SearchResultsHistory.Where(x => x.SearchTermHistoryId == searchTermHistoryId).ToListAsync();
                return resultHistory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SearchResult>> SearchResultsFromDictionaryApi(string searchTerm)
        {
            List<SearchResult> deserialisedSearchResults;
            try
            {
                string requestUrl = string.Format("https://www.dictionaryapi.com/api/v3/references/collegiate/json/{0}?key={1}", searchTerm, accessKey);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(new Uri(requestUrl));
                    var bodyContent = await response.Content.ReadAsStringAsync();
                    deserialisedSearchResults = JsonConvert.DeserializeObject<List<SearchResult>>(bodyContent);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deserialisedSearchResults;
        }
    }
}
