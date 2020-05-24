using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Rsl.Interview.Api.Models;
using Rsl.Interview.Api.Models.Results;
using Rsl.Interview.Api.Repository;
using Rsl.Interview.Api.Repository.Interfaces;
using Rsl.Interview.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rsl.Interview.Api.Services
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _repository;
        public WordService(IWordRepository repository)
        {
            _repository = repository;
        }
        public async Task<Word> Search(string searchTerm)
        {
            Word word = new Word();
            try
            {
                word.SearchTerm = searchTerm;

                List<SearchTermHistory> termHistory = await _repository.GetSearchTermHistory(searchTerm);
                if (termHistory == null || termHistory.Count <= 0)
                {
                    SearchTermHistory insertSearchTermHistory = await _repository.InsertSearchTermHistory(searchTerm);
                    word.SearchResults = await _repository.SearchResultsFromDictionaryApi(searchTerm);

                    if (word.SearchResults != null && word.SearchResults.Count > 0)
                    {
                        word.IsOffensive = word.SearchResults.FirstOrDefault().Meta.Offensive;
                        SearchResultsHistory insertSearchResultHistory = await _repository.InsertSearchResultsHistory(word.SearchResults, insertSearchTermHistory.Id);
                    }
                }
                else
                {
                    int searchTermHistoryId = termHistory.FirstOrDefault().Id;
                    List<SearchResultsHistory> resultHistory = await _repository.GetSearchResultHistory(searchTermHistoryId);
                    if (resultHistory.Count > 0)
                    {
                        var result = resultHistory.FirstOrDefault();
                        word.SearchResults = JsonConvert.DeserializeObject<List<SearchResult>>(result.Result);
                        word.IsOffensive = word.SearchResults.FirstOrDefault().Meta.Offensive;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return word;
        }
    }
}
