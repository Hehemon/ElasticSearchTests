using Elasticsearch.Net;
using ElasticSearchLearningTests.ElasticSearchConfigurations.Interfaces;
using ElasticSearchLearningTests.Models;
using Xunit;
using Xunit.Abstractions;

namespace ElasticSearchLearningTests.Tests
{
    /// <summary>
    /// For those test should be available ElasticSearch server
    /// </summary>
    public class HelloWorldTests : BaseDependencyResolutionTests
    {
        private const string DefaultIndex = "people";
        private const string DefaultType = "person";

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
            const string id = "1";
            var lowlevelClient = new ElasticLowLevelClient(_defaultConfiguration);
            var person = new Person {FirstName = "Hello", LastName = "World"};
            var indexResponse = lowlevelClient.Index<byte[]>(DefaultIndex, DefaultType, id, person);
            _output.WriteLine(indexResponse.DebugInformation);
            Assert.True(indexResponse.Success);
        }

        [Fact]
        public void WriteAndDeleteData()
        {
            const string id = "2";
            var lowlevelClient = new ElasticLowLevelClient(_defaultConfiguration);
            var person = new Person {FirstName = "John", LastName = "Doe"};
            var indexResponse = lowlevelClient.Index<string>(DefaultIndex, DefaultType, id, person);
            _output.WriteLine($"WriteRespose: {indexResponse.DebugInformation}");
            Assert.True(indexResponse.Success);

            var deleteResponse = lowlevelClient.Delete<string>(DefaultIndex, DefaultType, id);
            _output.WriteLine($"DeleteResponse: {deleteResponse.DebugInformation}");
            Assert.True(deleteResponse.Success);
        }

        [Fact]
        public async void WriteAsyncAndDeleteData()
        {
            const string id = "3";
            var lowlevelClient = new ElasticLowLevelClient(_defaultConfiguration);
            var person = new Person { FirstName = "John", LastName = "Doe" };
            var indexResponse = await lowlevelClient.IndexAsync<string>(DefaultIndex, DefaultType, id, person);
            _output.WriteLine($"WriteRespose: {indexResponse.DebugInformation}");
            Assert.True(indexResponse.Success);

            var deleteResponse = lowlevelClient.Delete<string>(DefaultIndex, DefaultType, id);
            _output.WriteLine($"DeleteResponse: {deleteResponse.DebugInformation}");
            Assert.True(deleteResponse.Success);
        }
    }
}
