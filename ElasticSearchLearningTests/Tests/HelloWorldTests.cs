using Elasticsearch.Net;
using ElasticSearchLearningTests.ElasticSearchConfigurations.Interfaces;
using ElasticSearchLearningTests.Models;
using Xunit;
using Xunit.Abstractions;

namespace ElasticSearchLearningTests.Tests
{
    public class HelloWorldTests : BaseDependencyResolutionTests
    {
        private readonly ConnectionConfiguration _defaultConfiguration;
        private readonly ITestOutputHelper _output;

        public HelloWorldTests(ITestOutputHelper output)
        {
            this._output = output;
            _defaultConfiguration = Container.GetInstance<IConnectionConfigurationResolver>().GetConnectionConfiguration();
        }

        [Fact]
        public void HelloWorld()
        {
            var lowlevelClient = new ElasticLowLevelClient(_defaultConfiguration);
            var person = new Person {FirstName = "Hello", LastName = "World"};
            var indexResponse = lowlevelClient.Index<byte[]>("people", "person", "1", person);
            _output.WriteLine(indexResponse.DebugInformation);
            var responseBody = indexResponse.Body;
            Assert.NotNull(responseBody);
        }
    }
}
