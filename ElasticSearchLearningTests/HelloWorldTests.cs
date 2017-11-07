using Elasticsearch.Net;
using ElasticSearchLearningTests.Model;
using Xunit;

namespace ElasticSearchLearningTests
{
    public class HelloWorldTests
    {
        [Fact]
        public void HelloWorld()
        {
            var lowlevelClient = new ElasticLowLevelClient();
            var person = new Person {FirstName = "Hello", LastName = "World"};
            var indexResponse = lowlevelClient.Index<byte[]>("people", "person", "1", person);
            var responseBody = indexResponse.Body;
            Assert.NotNull(responseBody);
        }
    }
}
