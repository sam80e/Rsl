using System.ComponentModel.DataAnnotations;

namespace Rsl.Interview.Api.Models
{
    public class SearchResultsHistory
    {
        [Required]
        public int Id { get; set; }
        public int SearchTermHistoryId { get; set; }
        public string Result { get; set; }
    }
}
