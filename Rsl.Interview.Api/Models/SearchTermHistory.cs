using System;
using System.ComponentModel.DataAnnotations;

namespace Rsl.Interview.Api.Models
{
    public class SearchTermHistory
    {
        [Required]
        public int Id { get; set; }
        public DateTime SearchedOn { get; set; }
        public string SearchTerm { get; set; }
    }
}
