using Microsoft.EntityFrameworkCore;
using Rsl.Interview.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rsl.Interview.Api.Repository
{
    public class InterviewContext : DbContext
    {
        public InterviewContext(DbContextOptions<InterviewContext> options) : base(options)
        {

        }
        public DbSet<SearchTermHistory> SearchTermHistory { get; set; }
        public DbSet<SearchResultsHistory> SearchResultsHistory { get; set; }
    }
}
