using Moq;
using Rsl.Interview.Api.Repository.Interfaces;
using Rsl.Interview.Api.Services;
using Xunit;

namespace Rsl.Service.Test
{
    public class WordServiceTest
    {       
        [Fact]
        public void TestSearchMethod_IsNotNull()
        {
            string searchTerm = "bingo";
            var mockrepository = new Mock<IWordRepository>();
            var service = new WordService(mockrepository.Object);

            var result = service.Search(searchTerm).Result;
            Assert.NotNull(result);
        }      
    }
}
