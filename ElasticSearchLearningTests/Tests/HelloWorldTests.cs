using Elasticsearch.Net;
using ElasticSearchLearningTests.ElasticSearchConfigurations.Interfaces;
using ElasticSearchLearningTests.Logging.Interfaces;
using ElasticSearchLearningTests.Models;
using log4net;
using Xunit;

namespace ElasticSearchLearningTests.Tests
{
    public class HelloWorldTests : BaseDependencyResolutionTests
    {
        private readonly ConnectionConfiguration _defaultConfiguration;
        private readonly ILog _logger;

        public HelloWorldTests()
        {
            _defaultConfiguration = Container.GetInstance<IConnectionConfigurationResolver>().GetConnectionConfiguration();
            _logger = Container.GetInstance<ILoggerResolver>().GetLogger(GetType());
        }

        [Fact]
        public void HelloWorld()
        {
            var lowlevelClient = new ElasticLowLevelClient(_defaultConfiguration);
            var person = new Person {FirstName = "Hello", LastName = "World"};
            var indexResponse = lowlevelClient.Index<byte[]>("people", "person", "1", person);
            _logger.Debug(indexResponse.DebugInformation);
            var responseBody = indexResponse.Body;
            Assert.NotNull(responseBody);
        }
    }
}
