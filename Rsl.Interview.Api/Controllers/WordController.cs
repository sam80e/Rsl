using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rsl.Interview.Api.Models;
using Rsl.Interview.Api.Services.Interfaces;

namespace Rsl.Interview.Api.Controllers
{
    public class SearchController : Controller
    {
        private IWordService _wordService;

        public SearchController(IWordService wordService)
        {
            _wordService = wordService;
        }

        [Route("/api/Word/Search/{0}")]        
        [HttpGet]
        public async Task<Word> Search(string searchTerm)
        {
            Word result;
            try
            {
                result = await _wordService.Search(searchTerm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}