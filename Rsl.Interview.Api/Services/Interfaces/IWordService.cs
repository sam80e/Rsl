using Rsl.Interview.Api.Models;
using System.Threading.Tasks;

namespace Rsl.Interview.Api.Services.Interfaces
{
    public interface IWordService
    {
        Task<Word> Search(string searchTerm);
    }
}
